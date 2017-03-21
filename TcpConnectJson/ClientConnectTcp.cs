// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.ClientConnectTcp
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace TcpConnectJson
{
    public class ClientConnectTcp
    {
        private TcpClient _tcpclient = (TcpClient)null;
        private NetworkStream _networkstream = (NetworkStream)null;
        private string _userRole = "STUDENT";
        private string _cacheMsg = "";
        public bool _tcpConnectState = false;
        public string _screenstate = "SCREENNORMAL";
        private const string splitS = "Ψ";
        private IPEndPoint _iport;

        public event ClientConnectTcp.ServerConnectedEventHandler ServerConnected;

        public event ClientConnectTcp.ServerConnectFailedEventHandler ServerConnectFailed;

        public event ClientConnectTcp.MessageReceivedEventHandler MessageReceived;

        public event ClientConnectTcp.ConnectionLostEventHandler ServerLost;

        public void ConnectToServer(IPAddress ip, int tcpPort, string screenState)
        {
            this._tcpclient = new TcpClient(AddressFamily.InterNetwork);
            this._tcpclient.BeginConnect(ip, tcpPort, new AsyncCallback(this.Connected), (object)this._tcpclient);
            this._screenstate = screenState;
        }

        public void ConnectToServer(IPAddress ip, int tcpPort, string userRole, string screenState)
        {
            this._tcpclient = new TcpClient(AddressFamily.InterNetwork);
            this._userRole = userRole;
            this._tcpclient.BeginConnect(ip, tcpPort, new AsyncCallback(this.Connected), (object)this._tcpclient);
            this._screenstate = screenState;
        }

        protected void Connected(IAsyncResult result)
        {
            try
            {
                this._tcpclient = (TcpClient)result.AsyncState;
                this._networkstream = this._tcpclient.GetStream();
                this._iport = this._tcpclient.Client.LocalEndPoint as IPEndPoint;
                this._tcpclient.EndConnect(result);
            }
            catch (Exception ex)
            {
                this.ServerConnectFailed.BeginInvoke(ex.Message, (AsyncCallback)null, (object)null);
                this.ServiceClose();
                return;
            }
            this.SendMessage(new Messages()
            {
                clientStyle = this._userRole,
                order = "STUCLIENTTYPE",
                time = DateTime.Now.ToString(),
                content = this._userRole + ":COMPUTER:" + this._screenstate
            });
            this._tcpConnectState = true;
            this.ServerConnected.BeginInvoke(this._tcpclient, (AsyncCallback)null, (object)null);
            byte[] buffer = new byte[1000];
            this._networkstream.BeginRead(buffer, 0, 1000, new AsyncCallback(this.DataRec), (object)buffer);
        }

        protected void DataRec(IAsyncResult result)
        {
            int num;
            try
            {
                num = this._networkstream.EndRead(result);
            }
            catch
            {
                this._tcpConnectState = false;
                this.ServerLost.BeginInvoke(this._tcpclient, (AsyncCallback)null, (object)null);
                return;
            }
            if (num == 0)
            {
                this._tcpConnectState = false;
                this.ServiceClose();
                this.ServerLost.BeginInvoke(this._tcpclient, (AsyncCallback)null, (object)null);
            }
            else
            {
                List<byte> byteList = new List<byte>();
                byteList.AddRange((IEnumerable<byte>)(byte[])result.AsyncState);
                byteList.RemoveRange(num, byteList.Count - num);
                string msg = Encoding.UTF8.GetString(byteList.ToArray(), 0, num);
                Console.WriteLine("receive:before serialise" + msg);
                this.msgHandleSynchronized(msg);
                byte[] buffer = new byte[1000];
                this._networkstream.BeginRead(buffer, 0, 1000, new AsyncCallback(this.DataRec), (object)buffer);
            }
        }

        public void BeginSendMessage(Messages mess)
        {
            if (this._networkstream == null)
                return;
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)mess) + "Ψ");
            try
            {
                this._networkstream.BeginWrite(bytes, 0, bytes.Length, (AsyncCallback)null, (object)null);
            }
            catch
            {
            }
        }

        public bool SendMessage(Messages mess)
        {
            if (this._networkstream == null)
                return false;
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object)mess) + "Ψ");
            try
            {
                this._networkstream.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SerializeReceivedMessage(string mess, bool isClearCache)
        {
            if (isClearCache)
                this._cacheMsg = "";
            Messages msg;
            try
            {
                msg = JsonConvert.DeserializeObject<Messages>(mess);
            }
            catch
            {
                Console.WriteLine("serialized failed! " + mess);
                return;
            }
            if (msg == null)
                return;
            Console.WriteLine("serialized success! " + mess);
            this.MessageReceived.BeginInvoke(msg, (AsyncCallback)null, (object)null);
        }

        public void ServiceClose()
        {
            if (this._tcpclient == null)
                return;
            this._tcpclient.Close();
            if (this._networkstream != null)
                this._networkstream.Dispose();
            this._networkstream = (NetworkStream)null;
        }

        private void changeCacheMsg(string msg)
        {
            lock (this._cacheMsg)
            {
                this._cacheMsg = msg;
                Console.WriteLine("cache change:" + this._cacheMsg);
            }
        }

        private void msgHandleSynchronized(string msg)
        {
            lock (new object())
            {
                int local_1 = Regex.Matches(msg, "Ψ").Count;
                string[] local_2 = msg.Split("Ψ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                int local_3 = local_2.Length;
                Console.WriteLine("split msg:splitNum: " + (object)local_1 + ",stringNum: " + (object)local_3);
                for (int local_4 = 0; local_4 < local_2.Length; ++local_4)
                    Console.WriteLine("msg:" + local_2[local_4]);
                if (local_1 < local_3 && local_3 >= 1)
                {
                    Console.WriteLine("splitNum < stringNum");
                    if (local_3 == 1)
                    {
                        this._cacheMsg += local_2[0];
                    }
                    else
                    {
                        for (int local_4_1 = 0; local_4_1 < local_3 - 1; ++local_4_1)
                        {
                            if (local_4_1 == 0)
                            {
                                this._cacheMsg += local_2[0];
                                this.SerializeReceivedMessage(this._cacheMsg, true);
                                Console.WriteLine("clear cacheMsg");
                            }
                            else
                                this.SerializeReceivedMessage(local_2[local_4_1], false);
                        }
                        this._cacheMsg = local_2[local_3 - 1];
                    }
                }
                else if (local_1 == local_3)
                {
                    Console.WriteLine("splitNum = stringNum");
                    if (msg.IndexOf("Ψ") == 0)
                    {
                        Console.WriteLine("splitS=0");
                        for (int local_4_2 = 0; local_4_2 < local_3; ++local_4_2)
                        {
                            if (local_4_2 == local_3 - 1)
                                this._cacheMsg += local_2[local_4_2];
                            else
                                this.SerializeReceivedMessage(local_2[local_4_2], false);
                        }
                    }
                    else
                    {
                        Console.WriteLine("splitS>0");
                        for (int local_4_3 = 0; local_4_3 < local_3; ++local_4_3)
                        {
                            if (local_4_3 == 0)
                            {
                                this._cacheMsg += local_2[0];
                                this.SerializeReceivedMessage(this._cacheMsg, true);
                            }
                            else
                                this.SerializeReceivedMessage(local_2[local_4_3], false);
                        }
                    }
                }
                else
                {
                    if (local_3 >= local_1)
                        return;
                    Console.WriteLine("stringNum < splitNum");
                    for (int local_4_4 = 0; local_4_4 < local_3; ++local_4_4)
                        this.SerializeReceivedMessage(local_2[local_4_4], false);
                }
            }
        }

        public delegate void ServerConnectedEventHandler(TcpClient tclient);

        public delegate void ServerConnectFailedEventHandler(string error);

        public delegate void MessageReceivedEventHandler(Messages msg);

        public delegate void ConnectionLostEventHandler(TcpClient tclient);
    }
}
