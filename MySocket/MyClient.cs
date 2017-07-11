using Common;
using Helpers;
using Model;
using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyVideo;
using System.Net.Sockets;

namespace MySocket
{
    public class MyClient
    {
        //   readonly string terminator = "|||";
        EasyClient client;
        public delegate void ReceiveHandle(ReceieveMessage message);
        // internal ReceiveHandle _delegate;
        public event ReceiveHandle OnReveieveData;
        //{
        //    add { _delegate += value; }
        //    remove { _delegate -= value; }
        //}
        readonly string serverIP = System.Configuration.ConfigurationManager.AppSettings["serverIP"];
        readonly int serverPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["serverPort"]);

        bool _connected;
        ScreenInteract _screenInteract;

        public bool Connected
        {
            get
            {
                return _connected;
            }

            set
            {
                _connected = value;
            }
        }

        public MyClient()
        {
            client = new EasyClient();
            client.Initialize(new MyReceiveFilter(), (response) =>
            {
                try
                {
                    Loger.LogMessage("收到消息：" + JsonHelper.SerializeObj(response));
                    OnReveieveData(response);
                }
                catch (Exception ex)
                {
                    Loger.LogMessage(ex.ToString());
                }

            });

            _connected = client.ConnectAsync(new IPEndPoint(IPAddress.Parse(serverIP), serverPort)).Result;
        }



        //public bool IsEventHandlerRegistered(Delegate prospectiveHandler)
        //{
        //    if (this.OnReveieveData != null)
        //    {
        //        foreach (Delegate existingHandler in this.OnReveieveData.GetInvocationList())
        //        {
        //            if (existingHandler == prospectiveHandler)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}


        public void SendMessage<T>(SendMessage<T> message) where T : class, new()
        {
            if (client.IsConnected)
            {
                Loger.LogMessage("发送信息：" + JsonHelper.SerializeObj(message));
                var messageByte = CreateSendMessageByte(message);
                client.Send(messageByte);
            }
            else
            {
                throw new Exception("客户端未连接到服务器");
            }

        }

        public async Task<bool> Close()
        {
            return await client.Close();
        }

        public void CreateScreenInteract()
        {
            var local = (IPEndPoint)client.LocalEndPoint;
            var ipv4 = local.Address.ToString();
            string localIP = ipv4.Substring(ipv4.LastIndexOf(':') + 1);// this.client.LocalEndPoint
            int localPort = local.Port;// local.Port;// this.client.LocalEndPoint.AddressFamily.;
            _screenInteract = new ScreenInteract(serverIP, localIP, localPort);
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        public void StopScreenInteract()
        {
            if (_screenInteract == null)
            {
                return;
            }
            _screenInteract.stopScreenInteract();
        }

        private byte[] CreateSendMessageByte<T>(SendMessage<T> message) where T : class, new()
        {
            string jsonString = JsonHelper.SerializeObj(message.Data);
            byte[] dataBytes = Encoding.UTF8.GetBytes(jsonString);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            byte[] timeBytes = Encoding.UTF8.GetBytes(time);
            var actionBytes = BitConverter.GetBytes(message.Action);
            var lengthByte = BitConverter.GetBytes(dataBytes.Length + timeBytes.Length + actionBytes.Length);// StringHelper.ConvertIntToByteArray4(dataBytes.Length + 18, ref buf);

            List<byte> byteSource = new List<byte>();
            byteSource.AddRange(lengthByte);
            byteSource.AddRange(timeBytes);
            byteSource.AddRange(actionBytes);
            byteSource.AddRange(dataBytes);
            return byteSource.ToArray();
        }


        #region 发送命令
        public void Send_UserLogin(string userName, string nickName, string password, ClientRole clientRole)
        {
            // GetAudioName();
            var loginInfo = new LoginInfo();
            if (clientRole == ClientRole.Teacher || clientRole == ClientRole.Assistant)
            {
                loginInfo.username = nickName;
                loginInfo.nickname = "老师";
                loginInfo.password = password;
            }
            else
            {
                loginInfo.username = userName;
                loginInfo.nickname = nickName;
                loginInfo.no = password;
            }
            loginInfo.clientRole = clientRole;
            loginInfo.clientStyle = ClientStyle.PC;
            SendMessage<LoginInfo> message = new SendMessage<LoginInfo>();
            message.Action = (int)CommandType.UserLogin;
            message.Data = loginInfo;
            SendMessage(message);

            //Task.Run(async () =>
            //{
            //    await this.SendMessage(message);
            //});
        }

        public void Send_OnlineList()
        {
            SendMessage<object> message = new SendMessage<object>();
            message.Action = (int)CommandType.OnlineList;
            SendMessage(message);

        }

        public void Send_ScreenInteract()
        {
            string rtspAddress = _screenInteract.beginScreenInteract();
            SendMessage<ScreenInteract_Request> message = new SendMessage<ScreenInteract_Request>();
            message.Action = (int)CommandType.ScreenInteract;
            message.Data = new ScreenInteract_Request { url = rtspAddress };

            SendMessage(message);

        }

        public void Send_VideoInteract()
        {
            string rtspAddress = _screenInteract.beginVideoInteract();
            SendMessage<ScreenInteract_Request> message = new SendMessage<ScreenInteract_Request>();
            message.Action = (int)CommandType.VideoInteract;
            message.Data = new ScreenInteract_Request { url = rtspAddress };

            SendMessage(message);

        }


        public void Send_StopScreenInteract()
        {

            SendMessage<StopLockScreenRequest> message = new SendMessage<StopLockScreenRequest>();
            message.Action = (int)CommandType.StopScreenInteract;
            message.Data = new StopLockScreenRequest();

            SendMessage(message);

        }

        public void Send_StopVideoInteract()
        {

            SendMessage<StopLockScreenRequest> message = new SendMessage<StopLockScreenRequest>();
            message.Action = (int)CommandType.StopVideoInteract;
            message.Data = new StopLockScreenRequest();

            SendMessage(message);

        }

        public void Send_LockScreen(string userName)
        {

            SendMessage<LockScreenRequest> message = new SendMessage<LockScreenRequest>();
            message.Action = (int)CommandType.LockScreen;
            message.Data = new LockScreenRequest { receivename = userName };

            SendMessage(message);

        }


        public void Send_StopLockScreen(string userName)
        {

            SendMessage<StopLockScreenRequest> message = new SendMessage<StopLockScreenRequest>();
            message.Action = (int)CommandType.StopLockScreen;
            message.Data = new StopLockScreenRequest { receivename = userName };

            SendMessage(message);

        }


        public void Send_Quiet()
        {

            SendMessage<QuietRequest> message = new SendMessage<QuietRequest>();
            message.Action = (int)CommandType.Quiet;
            message.Data = new QuietRequest();

            SendMessage(message);

        }


        public void Send_StopQuiet()
        {
            SendMessage<StopQuietRequest> message = new SendMessage<StopQuietRequest>();
            message.Action = (int)CommandType.StopQuiet;
            message.Data = new StopQuietRequest();
            SendMessage(message);
        }


        public void Send_PrivateChat(PrivateChatRequest request)
        {

            SendMessage<PrivateChatRequest> message = new SendMessage<PrivateChatRequest>();
            message.Action = (int)CommandType.PrivateChat;
            message.Data = request;
            SendMessage(message);
        }


        public void SendMessage<T>(T t, CommandType cmdType) where T : class, new()
        {
            SendMessage<T> message = new SendMessage<T>();
            message.Action = (int)cmdType;
            message.Data = t;
            SendMessage(message);
        }

        public void Send_TeamChat(TeamChatRequest request)
        {

            SendMessage<TeamChatRequest> message = new SendMessage<TeamChatRequest>();
            message.Action = (int)CommandType.TeamChat;
            message.Data = request;
            SendMessage(message);
        }


        public void Send_GroupChat(string sendName, string msg)
        {
            SendMessage<GroupChatRequest> message = new SendMessage<GroupChatRequest>();
            message.Action = (int)CommandType.GroupChat;
            message.Data = new GroupChatRequest
            {
                sendname = sendName,
                msg = msg
            };
            SendMessage(message);
        }

        public void Send_CreateTeam(TeamChatCreateOrUpdateRequest request)
        {
            SendMessage<TeamChatCreateOrUpdateRequest> message = new SendMessage<TeamChatCreateOrUpdateRequest>();
            message.Action = (int)CommandType.CreateTeam;
            message.Data = request;
            SendMessage(message);
        }
        /// <summary>
        /// 课堂点名
        /// </summary>
        /// <param name="sendName"></param>
        /// <param name="msg"></param>
        public void Send_Call()
        {
            var message = new SendMessage<BaseRequest>();
            message.Action = (int)CommandType.BeginCall;
            message.Data = new BaseRequest();
            SendMessage(message);

        }

        /// <summary>
        /// 结束课堂点名
        /// </summary>
        public void Send_EndCall()
        {
            var message = new SendMessage<BaseRequest>();
            message.Action = (int)CommandType.EndCall;
            message.Data = new BaseRequest();
            SendMessage(message);

        }

        /// <summary>
        /// 学生提交点名信息
        /// </summary>
        public void Send_StudentCall(string no, string name, string userName)
        {
            var message = new SendMessage<StuCallRequest>();
            message.Action = (int)CommandType.StudentCall;
            message.Data = new StuCallRequest { name = name, no = no, username = userName };
            SendMessage(message);

        }


        public void Send_StudentInMainForm()
        {
            var message = new SendMessage<BaseRequest>();
            message.Action = (int)CommandType.StudentInMainForm;
            message.Data = new BaseRequest();
            SendMessage(message);
        }

        #endregion
    }

    class MyReceiveFilter : FixedHeaderReceiveFilter<ReceieveMessage>
    {
        public MyReceiveFilter()
        : base(4) // two vertical bars as package terminator
        {
        }

        public override ReceieveMessage ResolvePackage(IBufferStream bs)
        {
            ReceieveMessage message = new ReceieveMessage();
            var lenBytes = new byte[4];
            bs.Read(lenBytes, 0, 4);
            message.Length = BitConverter.ToInt32(lenBytes, 0);
            var timeBytes = new byte[14];
            bs.Read(timeBytes, 0, 14);
            message.TimeStamp = Encoding.UTF8.GetString(timeBytes);
            var actionBytes = new byte[4];
            bs.Read(actionBytes, 0, 4);
            message.Action = BitConverter.ToInt32(actionBytes, 0);
            var dataLength = message.Length - 18;
            var dataBytes = new byte[dataLength];
            bs.Read(dataBytes, 0, dataLength);
            message.DataStr = Encoding.UTF8.GetString(dataBytes);
            return message;
        }


        protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
        {
            var lenBytes = new byte[length];
            bufferStream.Read(lenBytes, 0, length);
            return BitConverter.ToInt32(lenBytes, 0);
        }
    }


    public class ReceieveMessage : IPackageInfo
    {
        public int Length { get; set; }
        public string TimeStamp { get; set; }

        public string DataStr { get; set; }

        public int Action { get; set; }
    }

}
