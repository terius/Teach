using Common;
using Helpers;
using Model;
using MyVideo;
using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        readonly int udpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["UDPPort"]);

        bool _connected;
        ScreenInteract _screenInteract;
        UdpClient sendUdpClient;
        UdpClient receieveUdpClient;
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        ManualResetEvent sendDone = new ManualResetEvent(false);
        public void SendDesktopPic(byte[] fileBytes, string teacherIp)
        {
            if (sendUdpClient == null)
            {
                sendUdpClient = new UdpClient();
                var remoteEP = new IPEndPoint(IPAddress.Parse(teacherIp), 10888);
                sendUdpClient.Connect(remoteEP);
            }
            //var fileBytes = FileHelper.FileToByteArray(fileName);
            sendUdpClient.BeginSend(fileBytes, fileBytes.Length, (result) =>
            {
                if (result.IsCompleted)
                {
                    sendDone.Set();
                }
            }, null);
        }

        public void CreateUDPTeacherHole()
        {
            var uClient = new UdpClient();
            var remoteEP = new IPEndPoint(IPAddress.Parse(serverIP), udpPort);
            uClient.Connect(remoteEP);
            var bt = Encoding.UTF8.GetBytes("TEACHER");
            uClient.Send(bt, bt.Length);
        }

        public void CreateUDPStudentHole()
        {
            var uClient = new UdpClient();
            var remoteEP = new IPEndPoint(IPAddress.Parse(serverIP), udpPort);
            uClient.Connect(remoteEP);
            var bt = Encoding.UTF8.GetBytes("STUDENT");
            uClient.Send(bt, bt.Length);
        }

        public ScreenCaptureInfo GetReceieveDesktopInfo()
        {
            if (receieveUdpClient == null)
            {
                receieveUdpClient = new UdpClient(10888);
            }

            Byte[] receiveBytes = receieveUdpClient.Receive(ref RemoteIpEndPoint);
            return GetScreen(receiveBytes);
        }

        private ScreenCaptureInfo GetScreen(byte[] receiveBytes)
        {
            int tempOffset = 0;
            var lenBytes = new byte[4];
            Array.Copy(receiveBytes, tempOffset, lenBytes, 0, 4);
            int alllength = BitConverter.ToInt32(lenBytes, 0);
            tempOffset += 4;
            Array.Copy(receiveBytes, tempOffset, lenBytes, 0, 4);
            int userLength = BitConverter.ToInt32(lenBytes, 0);
            var userBytes = new byte[userLength];
            tempOffset += 4;
            Array.Copy(receiveBytes, tempOffset, userBytes, 0, userLength);
            string userString = Encoding.UTF8.GetString(userBytes);
            ScreenCaptureInfo info = JsonHelper.DeserializeObj<ScreenCaptureInfo>(userString);
            tempOffset += userLength;
            Array.Copy(receiveBytes, tempOffset, lenBytes, 0, 4);
            int imgLength = BitConverter.ToInt32(lenBytes, 0);
            var imgBytes = new byte[imgLength];
            tempOffset += 4;
            Array.Copy(receiveBytes, tempOffset, imgBytes, 0, imgLength);
            info.Image = FileHelper.ByteArrayToImage(imgBytes);
            return info;
        }


        public void StopUdp()
        {
            sendDone.WaitOne();
        }


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
            OnReveieveData += MyClient_OnReveieveData;
            _connected = client.ConnectAsync(new IPEndPoint(IPAddress.Parse(serverIP), serverPort)).Result;
        }

        public void DueLostMessage()
        {
            foreach (var lostMsg in UnDueMessages)
            {
                MyClient_OnReveieveData(lostMsg);
            }
            UnDueMessages.Clear();
        }



        private IList<ReceieveMessage> UnDueMessages = new List<ReceieveMessage>();
        public Action<ReceieveMessage> OnLoginIn;
        public Action<ReceieveMessage> OnTeacherLoginIn;
        public Action<ReceieveMessage> OnBeginCall;
        private void MyClient_OnReveieveData(ReceieveMessage message)
        {
            switch (message.Action)
            {
                case (int)CommandType.UserLoginRes:
                    if (OnLoginIn == null)
                    {
                        UnDueMessages.Add(message);
                        return;
                    }
                    OnLoginIn(message);
                    break;
                case (int)CommandType.TeacherLoginIn://教师端登录
                    if (OnTeacherLoginIn == null)
                    {
                        UnDueMessages.Add(message);
                        return;
                    }
                    OnTeacherLoginIn(message);
                    break;
                case (int)CommandType.BeginCall://开始点名
                    if (OnBeginCall == null)
                    {
                        UnDueMessages.Add(message);
                        return;
                    }
                    OnBeginCall(message);
                    break;
                default:
                    break;
            }

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
                throw new Exception("连接服务器失败");
            }

        }

        public async Task<bool> Close()
        {
            return await client.Close();
        }

        public void CreateScreenInteract()
        {
            if (_screenInteract == null)
            {
                var local = (IPEndPoint)client.LocalEndPoint;
                var ipv4 = local.Address.ToString();
                string localIP = ipv4.Substring(ipv4.LastIndexOf(':') + 1);// this.client.LocalEndPoint
                int localPort = local.Port;// local.Port;// this.client.LocalEndPoint.AddressFamily.;
                _screenInteract = new ScreenInteract(serverIP, localIP, localPort);
            }
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
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="nickName"></param>
        /// <param name="password"></param>
        /// <param name="clientRole"></param>
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
            SendMessage(loginInfo, CommandType.UserLogin);
        }

        /// <summary>
        /// 显示当前在线用户
        /// </summary>
        public void Send_OnlineList()
        {
            SendMessageNoPara(CommandType.OnlineList);
        }
        /// <summary>
        /// 屏幕广播
        /// </summary>
        public void Send_ScreenInteract()
        {
            string rtspAddress = _screenInteract.beginScreenInteract();
            var request = new ScreenInteract_Request { url = rtspAddress };
            SendMessage(request, CommandType.ScreenInteract);
        }

        /// <summary>
        /// 视频直播
        /// </summary>
        public void Send_VideoInteract()
        {
            string rtspAddress = _screenInteract.beginVideoInteract();
            var request = new ScreenInteract_Request { url = rtspAddress };
            SendMessage(request, CommandType.ScreenInteract);
        }

        /// <summary>
        /// 停止屏幕广播
        /// </summary>
        public void Send_StopScreenInteract()
        {
            SendMessageNoPara(CommandType.StopScreenInteract);

        }
        /// <summary>
        /// 停止视频直播
        /// </summary>
        public void Send_StopVideoInteract()
        {
            SendMessageNoPara(CommandType.StopScreenInteract);

        }
        /// <summary>
        /// 锁屏
        /// </summary>
        /// <param name="userName"></param>
        public void Send_LockScreen(string userName)
        {
            var request = new LockScreenRequest { receivename = userName };
            SendMessage(request, CommandType.LockScreen);

        }

        /// <summary>
        /// 停止锁屏
        /// </summary>
        /// <param name="userName"></param>
        public void Send_StopLockScreen(string userName)
        {
            var request = new LockScreenRequest { receivename = userName };
            SendMessage(request, CommandType.StopLockScreen);

        }

        /// <summary>
        /// 屏幕肃静
        /// </summary>
        public void Send_Quiet()
        {
            SendMessageNoPara(CommandType.Quiet);

        }

        /// <summary>
        /// 结束屏幕肃静
        /// </summary>
        public void Send_StopQuiet()
        {
            SendMessageNoPara(CommandType.StopQuiet);
        }

        /// <summary>
        /// 私聊
        /// </summary>
        /// <param name="request"></param>
        public void Send_PrivateChat(PrivateChatRequest request)
        {
            SendMessage(request, CommandType.PrivateChat);
        }


        /// <summary>
        /// 群组聊天
        /// </summary>
        /// <param name="request"></param>
        public void Send_TeamChat(TeamChatRequest request)
        {
            SendMessage(request, CommandType.TeamChat);
        }


        /// <summary>
        /// 全体成员聊天
        /// </summary>
        /// <param name="sendName"></param>
        /// <param name="msg"></param>
        public void Send_GroupChat(GroupChatRequest request)
        {

            SendMessage(request, CommandType.GroupChat);
        }
        /// <summary>
        /// 创建群组
        /// </summary>
        /// <param name="request"></param>
        public void Send_CreateTeam(TeamChatCreateOrUpdateRequest request)
        {
            SendMessage(request, CommandType.CreateTeam);
        }
        /// <summary>
        /// 课堂点名
        /// </summary>
        /// <param name="sendName"></param>
        /// <param name="msg"></param>
        public void Send_Call()
        {
            SendMessageNoPara(CommandType.BeginCall);

        }

        /// <summary>
        /// 结束课堂点名
        /// </summary>
        public void Send_EndCall()
        {
            SendMessageNoPara(CommandType.EndCall);

        }

        /// <summary>
        /// 学生提交点名信息
        /// </summary>
        public void Send_StudentCall(string no, string name, string userName)
        {
            var request = new StuCallRequest { name = name, no = no, username = userName };
            SendMessage(request, CommandType.StudentCall);

        }

        /// <summary>
        /// 学生登录完成已进入主页面
        /// </summary>
        public void Send_StudentInMainForm()
        {
            SendMessageNoPara(CommandType.StudentInMainForm);
        }

        /// <summary>
        /// 呼叫学生演示
        /// </summary>
        /// <param name="userName"></param>
        public void Send_CallStudentShow(string userName)
        {
            var request = new OnlyUserNameRequest { receivename = userName };
            SendMessage(request, CommandType.CallStudentShow);
        }

        /// <summary>
        /// 关闭学生演示
        /// </summary>
        /// <param name="userName"></param>
        public void Send_StopStudentShow(string userName)
        {
            var request = new OnlyUserNameRequest { receivename = userName };
            SendMessage(request, CommandType.StopStudentShow);
        }

        /// <summary>
        /// 禁止学生私聊
        /// </summary>
        /// <param name="userName"></param>
        public void Send_ForbidPrivateChat(string userName)
        {
            var request = new OnlyUserNameRequest { receivename = userName };
            SendMessage(request, CommandType.ForbidPrivateChat);
        }
        /// <summary>
        /// 允许学生私聊
        /// </summary>
        /// <param name="userName"></param>
        public void Send_AllowPrivateChat(string userName)
        {
            var request = new OnlyUserNameRequest { receivename = userName };
            SendMessage(request, CommandType.AllowPrivateChat);
        }
        /// <summary>
        /// 禁止群聊
        /// </summary>
        /// <param name="userName"></param>
        public void Send_ForbidTeamChat(string userName)
        {
            var request = new OnlyUserNameRequest { receivename = userName };
            SendMessage(request, CommandType.ForbidTeamChat);
        }

        /// <summary>
        /// 允许群聊
        /// </summary>
        /// <param name="userName"></param>
        public void Send_AllowTeamChat(string userName)
        {
            var request = new OnlyUserNameRequest { receivename = userName };
            SendMessage(request, CommandType.AllowTeamChat);
        }

        /// <summary>
        /// 学生端登出
        /// </summary>
        public void Send_StudentLoginOut()
        {
            SendMessageNoPara(CommandType.UserLoginOut);
        }

        #region 通用方法
        private void SendMessage<T>(T t, CommandType cmdType) where T : class, new()
        {
            SendMessage<T> message = new SendMessage<T>();
            message.Action = (int)cmdType;
            message.Data = t;
            SendMessage(message);
        }

        private void SendMessageNoPara(CommandType cmdType)
        {
            SendMessage<EmptyRequest> message = new SendMessage<EmptyRequest>();
            message.Action = (int)cmdType;
            message.Data = new EmptyRequest();
            SendMessage(message);
        }

        #endregion

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
