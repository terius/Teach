using Common;
using Cowboy.Sockets;
using DirectShowLib;
using Helpers;
using Model;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MyTCP
{
    public class MyTcpClient
    {
        AsyncTcpSocketClient _client;
        readonly string serverIP = System.Configuration.ConfigurationManager.AppSettings["serverIP"];
        readonly int serverPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["serverPort"]);

        public string LocalIP { get { return this._client.LocalEndPoint.Address.ToString(); } }
        public SimpleMessageDispatcher messageDue { get; private set; }
        ScreenInteract _screenInteract;
        public delegate void receHandle(ReceieveMessage message);
        public event receHandle OnReveieveData;


        public MyTcpClient()
        {
            messageDue = new SimpleMessageDispatcher();
            messageDue.OnReceieveMessage += MessageDue_OnReceieveMessage; ;
            var config = new AsyncTcpSocketClientConfiguration();
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            _client = new AsyncTcpSocketClient(remoteEP, messageDue, config);
            _client.Connect().Wait();
        }

        public async Task Close()
        {
            StopScreenInteract();
            if (_client == null)
            {
                await Task.CompletedTask;
            }
            if (_client.State == TcpSocketConnectionState.Connected || _client.State == TcpSocketConnectionState.Connecting)
            {
                await _client.Close();
            }



        }


        public string GetAudioName()
        {
            DsDevice[] audioRenderers;
            audioRenderers = DsDevice.GetDevicesOfCat(FilterCategory.AudioRendererCategory);
            foreach (DsDevice device in audioRenderers)
            {
                Loger.LogMessage(JsonHelper.SerializeObj(device));
            }
            return "";
        }

        private void MessageDue_OnReceieveMessage(ReceieveMessage message)
        {
            Loger.LogMessage("收到命令：" + JsonHelper.SerializeObj(message));
            OnReveieveData(message);
        }

        public void CreateScreenInteract()
        {
            string localIP = this._client.LocalEndPoint.Address.ToString();
            int localPort = this._client.LocalEndPoint.Port;
            _screenInteract = new ScreenInteract(serverIP, localIP, localPort);
        }

        public void StopScreenInteract()
        {
            if (_screenInteract == null)
            {
                return;
            }
            _screenInteract.stopScreenInteract();
        }


        public async Task SendMessage<T>(SendMessage<T> message) where T : class, new()
        {

            Loger.LogMessage("发送命令：" + JsonHelper.SerializeObj(message));
            await TcpHelper.SendMessage(message, _client);

        }

        //  private volatile static MyTcpClient _instance = null;
        // private static readonly object lockHelper = new object();
        //public static MyTcpClient CreateInstance()
        //{
        //    if (_instance == null)
        //    {
        //        lock (lockHelper)
        //        {
        //            if (_instance == null)
        //                _instance = new MyTcpClient();
        //        }
        //    }
        //    return _instance;
        //}
        #region 发送命令
        public async Task Send_UserLogin(string userName, string nickName, string password, ClientRole clientRole)
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
            await SendMessage(message);

            //Task.Run(async () =>
            //{
            //    await this.SendMessage(message);
            //});
        }

        public void Send_OnlineList()
        {
            SendMessage<object> message = new SendMessage<object>();
            message.Action = (int)CommandType.OnlineList;
            Task.Run(async () =>
            {

                await this.SendMessage(message);
            });
        }

        public void Send_ScreenInteract()
        {
            string rtspAddress = _screenInteract.beginScreenInteract();
            SendMessage<ScreenInteract_Request> message = new SendMessage<ScreenInteract_Request>();
            message.Action = (int)CommandType.ScreenInteract;
            message.Data = new ScreenInteract_Request { url = rtspAddress };
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        public void Send_StopScreenInteract()
        {

            SendMessage<StopLockScreenRequest> message = new SendMessage<StopLockScreenRequest>();
            message.Action = (int)CommandType.StopScreenInteract;
            message.Data = new StopLockScreenRequest();
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }

        public void Send_LockScreen(string userName)
        {

            SendMessage<LockScreenRequest> message = new SendMessage<LockScreenRequest>();
            message.Action = (int)CommandType.LockScreen;
            message.Data = new LockScreenRequest { receivename = userName };
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        public void Send_StopLockScreen(string userName)
        {

            SendMessage<StopLockScreenRequest> message = new SendMessage<StopLockScreenRequest>();
            message.Action = (int)CommandType.StopLockScreen;
            message.Data = new StopLockScreenRequest { receivename = userName };
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        public void Send_Quiet()
        {

            SendMessage<QuietRequest> message = new SendMessage<QuietRequest>();
            message.Action = (int)CommandType.Quiet;
            message.Data = new QuietRequest();
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        public void Send_StopQuiet()
        {
            SendMessage<StopQuietRequest> message = new SendMessage<StopQuietRequest>();
            message.Action = (int)CommandType.StopQuiet;
            message.Data = new StopQuietRequest();
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        public void Send_PrivateChat(PrivateChatRequest request)
        {

            SendMessage<PrivateChatRequest> message = new SendMessage<PrivateChatRequest>();
            message.Action = (int)CommandType.PrivateChat;
            message.Data = request;
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        public void SendMessage<T>(T t, CommandType cmdType) where T : class, new()
        {
            SendMessage<T> message = new SendMessage<T>();
            message.Action = (int)cmdType;
            message.Data = t;
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }

        public void Send_TeamChat(TeamChatRequest request)
        {

            SendMessage<TeamChatRequest> message = new SendMessage<TeamChatRequest>();
            message.Action = (int)CommandType.TeamChat;
            message.Data = request;
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
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

            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }

        public void Send_CreateTeam(TeamChatCreateOrUpdateRequest request)
        {
            SendMessage<TeamChatCreateOrUpdateRequest> message = new SendMessage<TeamChatCreateOrUpdateRequest>();
            message.Action = (int)CommandType.CreateTeam;
            message.Data = request;

            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
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

            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });

        }

        /// <summary>
        /// 结束课堂点名
        /// </summary>
        public void Send_EndCall()
        {
            var message = new SendMessage<BaseRequest>();
            message.Action = (int)CommandType.EndCall;
            message.Data = new BaseRequest();

            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });

        }

        /// <summary>
        /// 学生提交点名信息
        /// </summary>
        public void Send_StudentCall(string no, string name, string userName)
        {
            var message = new SendMessage<StuCallRequest>();
            message.Action = (int)CommandType.StudentCall;
            message.Data = new StuCallRequest { name = name, no = no, username = userName };

            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });

        }

        #endregion
    }


}
