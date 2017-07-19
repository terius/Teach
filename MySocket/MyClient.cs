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
using System.IO;
using System.Runtime.InteropServices;

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
        UdpClient udpClient;

        public void SendDesktopPic()
        {
            if (udpClient == null)
            {
                udpClient = new UdpClient();
                var remoteEP = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
                udpClient.Connect(remoteEP);
            }

        }

        private class GDI32
        {
            public const int CAPTUREBLT = 1073741824;
            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }

        //public void Get_pic(IntPtr handle)
        //{
        //    string pathPerc = @"Send.jpg";
        //    string source = @"Capture.jpg";
        //    //try
        //    //{
        //    //    Image myImg = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
        //    //    Graphics g = Graphics.FromImage(myImg);
        //    //    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
        //    //    myImg.Save(source, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //    g.Dispose();
        //    //    myImg.Dispose();
        //    //}
        //    //catch (Exception e){
        //    //    MessageBox.Show(e.ToString(),"截屏获取异常");
        //    //}
        //    try
        //    {
        //        // get te hDC of the target window
        //        IntPtr hdcSrc = User32.GetWindowDC(handle);
        //        // get the size
        //        User32.RECT windowRect = new User32.RECT();
        //        User32.GetWindowRect(handle, ref windowRect);
        //        int width = windowRect.right - windowRect.left;
        //        int height = windowRect.bottom - windowRect.top;
        //        // create a device context we can copy to
        //        IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
        //        // create a bitmap we can copy it to,
        //        // using GetDeviceCaps to get the width/height
        //        IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
        //        // select the bitmap object
        //        IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
        //        // bitblt over
        //        GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY | GDI32.CAPTUREBLT);
        //        // restore selection
        //        GDI32.SelectObject(hdcDest, hOld);
        //        // clean up 
        //        GDI32.DeleteDC(hdcDest);
        //        User32.ReleaseDC(handle, hdcSrc);
        //        // get a .NET image object for it
        //        Image img = Image.FromHbitmap(hBitmap);
        //        // free up the Bitmap object
        //        GDI32.DeleteObject(hBitmap);

        //        img.Save(source);
        //        img.Dispose();
        //        //return img;
        //    }
        //    catch (Exception)
        //    {
        //        // MessageBox.Show(e.ToString(), "截屏获取异常");
        //        //Thread.Sleep(400);
        //    }
        //    try
        //    {
        //        if (!File.Exists(pathPerc))
        //        {
        //            File.Create(pathPerc).Close();
        //        }
        //        else
        //        {
        //            File.Delete(pathPerc);
        //            File.Create(pathPerc).Close();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show(e.ToString(),"文件路径异常");
        //        //Thread.Sleep(400);
        //    }
        //    getThumImage(source, 40, 5, pathPerc);
        //}

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
