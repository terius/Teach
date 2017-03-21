using Common;
using Cowboy.Sockets;
using Helpers;
using Model;
using System;
using System.Net;
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
        public async Task Send_UserLogin(string userName,string nickName, string password, ClientRole clientRole)
        {
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


        public void Send_PrivateChat(string receieveName, string sendName, string msg)
        {

            SendMessage<PrivateChatRequest> message = new SendMessage<PrivateChatRequest>();
            message.Action = (int)CommandType.PrivateChat;
            message.Data = new PrivateChatRequest { receivename = receieveName, sendname = sendName, msg = msg };
            Task.Run(async () =>
            {
                await this.SendMessage(message);
            });
        }


        #endregion
    }


}
