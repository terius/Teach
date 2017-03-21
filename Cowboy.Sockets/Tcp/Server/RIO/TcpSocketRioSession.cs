﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Cowboy.Buffer;
using Logrila.Logging;
using RioSharp;

namespace Cowboy.Sockets.Experimental
{
    public sealed class TcpSocketRioSession : IDisposable
    {
        #region Fields

        private static readonly ILog _log = Logger.Get<TcpSocketRioSession>();
        private readonly object _opsLock = new object();
        private readonly TcpSocketRioServerConfiguration _configuration;
        private readonly ISegmentBufferManager _bufferManager;
        private readonly ITcpSocketRioServerMessageDispatcher _dispatcher;
        private readonly TcpSocketRioServer _server;
        private RioSocket _socket;
        private Stream _stream;
        private string _sessionKey;
        private ArraySegment<byte> _receiveBuffer = default(ArraySegment<byte>);
        private int _receiveBufferOffset = 0;

        private int _state;
        private const int _none = 0;
        private const int _connecting = 1;
        private const int _connected = 2;
        private const int _disposed = 5;

        #endregion

        #region Constructors

        public TcpSocketRioSession(
            TcpSocketRioServerConfiguration configuration,
            ISegmentBufferManager bufferManager,
            RioSocket socket,
            ITcpSocketRioServerMessageDispatcher dispatcher,
            TcpSocketRioServer server)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");
            if (bufferManager == null)
                throw new ArgumentNullException("bufferManager");
            if (socket == null)
                throw new ArgumentNullException("socket");
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");
            if (server == null)
                throw new ArgumentNullException("server");

            _configuration = configuration;
            _bufferManager = bufferManager;
            _socket = socket;
            _dispatcher = dispatcher;
            _server = server;

            _sessionKey = Guid.NewGuid().ToString();
            this.StartTime = DateTime.UtcNow;

            if (_receiveBuffer == default(ArraySegment<byte>))
                _receiveBuffer = _bufferManager.BorrowBuffer();
            _receiveBufferOffset = 0;

            _stream = new RioStream(_socket);
        }

        #endregion

        #region Properties

        public string SessionKey { get { return _sessionKey; } }
        public DateTime StartTime { get; private set; }

        public RioSocket Socket { get { return _socket; } }
        public Stream Stream { get { return _stream; } }
        public TcpSocketRioServer Server { get { return _server; } }

        public TcpSocketConnectionState State
        {
            get
            {
                switch (_state)
                {
                    case _none:
                        return TcpSocketConnectionState.None;
                    case _connecting:
                        return TcpSocketConnectionState.Connecting;
                    case _connected:
                        return TcpSocketConnectionState.Connected;
                    case _disposed:
                        return TcpSocketConnectionState.Closed;
                    default:
                        return TcpSocketConnectionState.Closed;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("SessionKey[{0}]",
                this.SessionKey);
        }

        #endregion

        #region Process

        internal async Task Start()
        {
            int origin = Interlocked.CompareExchange(ref _state, _connecting, _none);
            if (origin == _disposed)
            {
                throw new ObjectDisposedException("This tcp socket session has been disposed when connecting.");
            }
            else if (origin != _none)
            {
                throw new InvalidOperationException("This tcp socket session is in invalid state when connecting.");
            }

            try
            {
                if (_receiveBuffer == default(ArraySegment<byte>))
                    _receiveBuffer = _bufferManager.BorrowBuffer();
                _receiveBufferOffset = 0;

                if (Interlocked.CompareExchange(ref _state, _connected, _connecting) != _connecting)
                {
                    await Close();
                    throw new ObjectDisposedException("This tcp socket session has been disposed after connected.");
                }

                _log.DebugFormat("Session started on [{0}] in dispatcher [{1}] with session count [{2}].",
                    this.StartTime.ToString(@"yyyy-MM-dd HH:mm:ss.fffffff"),
                    _dispatcher.GetType().Name,
                    this.Server.SessionCount);
                bool isErrorOccurredInUserSide = false;
                try
                {
                    await _dispatcher.OnSessionStarted(this);
                }
                catch (Exception ex)
                {
                    isErrorOccurredInUserSide = true;
                    HandleUserSideError(ex);
                }

                if (!isErrorOccurredInUserSide)
                {
                    await Process();
                }
                else
                {
                    await Close();
                }
            }
            catch (Exception ex)
            when (ex is TimeoutException)
            {
                _log.Error(string.Format("Session [{0}] exception occurred, [{1}].", this, ex.Message), ex);
                await Close();
            }
        }

        private async Task Process()
        {
            try
            {
                int frameLength;
                byte[] payload;
                int payloadOffset;
                int payloadCount;
                int consumedLength = 0;

                while (State == TcpSocketConnectionState.Connected)
                {
                    int receiveCount = await _stream.ReadAsync(_receiveBuffer.Array, _receiveBuffer.Offset + _receiveBufferOffset, _receiveBuffer.Count - _receiveBufferOffset);
                    if (receiveCount == 0)
                        break;

                    SegmentBufferDeflector.ReplaceBuffer(_bufferManager, ref _receiveBuffer, ref _receiveBufferOffset, receiveCount);
                    consumedLength = 0;

                    while (true)
                    {
                        frameLength = 0;
                        payload = null;
                        payloadOffset = 0;
                        payloadCount = 0;

                        if (_configuration.FrameBuilder.Decoder.TryDecodeFrame(
                            _receiveBuffer.Array, 
                            _receiveBuffer.Offset + consumedLength, 
                            _receiveBufferOffset - consumedLength,
                            out frameLength, out payload, out payloadOffset, out payloadCount))
                        {
                            try
                            {
                                await _dispatcher.OnSessionDataReceived(this, payload, payloadOffset, payloadCount);
                            }
                            catch (Exception ex)
                            {
                                HandleUserSideError(ex);
                            }
                            finally
                            {
                                consumedLength += frameLength;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    try
                    {
                        SegmentBufferDeflector.ShiftBuffer(_bufferManager, consumedLength, ref _receiveBuffer, ref _receiveBufferOffset);
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
            catch (Exception ex) when (!ShouldThrow(ex)) { }
            finally
            {
                await Close();
            }
        }

        public async Task Close()
        {
            if (Interlocked.Exchange(ref _state, _disposed) == _disposed)
            {
                return;
            }

            Clean();

            _log.DebugFormat("Session closed on [{0}] in dispatcher [{1}] with session count [{2}].",
                DateTime.UtcNow.ToString(@"yyyy-MM-dd HH:mm:ss.fffffff"),
                _dispatcher.GetType().Name,
                this.Server.SessionCount - 1);
            try
            {
                await _dispatcher.OnSessionClosed(this);
            }
            catch (Exception ex)
            {
                HandleUserSideError(ex);
            }
        }

        private void Clean()
        {
            try
            {
                try
                {
                    if (_stream != null)
                    {
                        _stream.Dispose();
                    }
                }
                catch { }
                try
                {
                    if (_socket != null)
                    {
                        _socket.Dispose();
                    }
                }
                catch { }
            }
            catch { }
            finally
            {
                _stream = null;
                _socket = null;
            }

            if (_receiveBuffer != default(ArraySegment<byte>))
                _configuration.BufferManager.ReturnBuffer(_receiveBuffer);
            _receiveBuffer = default(ArraySegment<byte>);
            _receiveBufferOffset = 0;
        }

        #endregion

        #region Exception Handler

        private bool IsSocketTimeOut(Exception ex)
        {
            return ex is IOException
                && ex.InnerException != null
                && ex.InnerException is SocketException
                && (ex.InnerException as SocketException).SocketErrorCode == SocketError.TimedOut;
        }

        private bool ShouldThrow(Exception ex)
        {
            if (IsSocketTimeOut(ex))
            {
                _log.Error(ex.Message, ex);
                return false;
            }

            if (ex is ObjectDisposedException
                || ex is InvalidOperationException
                || ex is SocketException
                || ex is IOException
                || ex is NullReferenceException
                )
            {
                if (ex is SocketException)
                    _log.Error(string.Format("Session [{0}] exception occurred, [{1}].", this, ex.Message), ex);

                return false;
            }

            _log.Error(string.Format("Session [{0}] exception occurred, [{1}].", this, ex.Message), ex);
            return true;
        }

        private void HandleUserSideError(Exception ex)
        {
            _log.Error(string.Format("Session [{0}] error occurred in user side [{1}].", this, ex.Message), ex);
        }

        #endregion

        #region Send

        public async Task SendAsync(byte[] data)
        {
            await SendAsync(data, 0, data.Length);
        }

        public async Task SendAsync(byte[] data, int offset, int count)
        {
            BufferValidator.ValidateBuffer(data, offset, count, "data");

            if (State != TcpSocketConnectionState.Connected)
            {
                throw new InvalidOperationException("This session has not connected.");
            }

            try
            {
                byte[] frameBuffer;
                int frameBufferOffset;
                int frameBufferLength;
                _configuration.FrameBuilder.Encoder.EncodeFrame(data, offset, count, out frameBuffer, out frameBufferOffset, out frameBufferLength);

                await _stream.WriteAsync(frameBuffer, frameBufferOffset, frameBufferLength);
            }
            catch (Exception ex) when (!ShouldThrow(ex)) { }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_stream")]
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    Close().Wait();
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, ex);
                }
            }
        }

        #endregion
    }
}
