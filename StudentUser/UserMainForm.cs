using Common;
using DevExpress.XtraEditors;
using Helpers;
using Model;
using MySocket;
using SharedForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace StudentUser
{
    public partial class UserMainForm : XtraForm
    {
        BlackScreen bsForm = null;
        // VLCPlayer videoPlayer;
        ChatForm chatForm = new ChatForm();
        ViewRtsp videoPlayer2;
        CallForm callForm;
        volatile bool isRunScreen = false;
        public UserMainForm()
        {
            InitializeComponent();
            Text = GlobalVariable.LoginUserInfo.DisplayName;
            tuopan.Text = Text;
            GlobalVariable.client.OnBeginCall = (message) =>
            {
                DoAction(() =>
                {
                    OpenCallForm();

                });


            };
            GlobalVariable.client.DueLostMessage();

          //  GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            GlobalVariable.client.Send_StudentInMainForm();
        }
        private void UserMainForm_Load(object sender, System.EventArgs e)
        {
            //ThreadStart ts = new ThreadStart(GetScreenCapture);
            //Thread t = new Thread(ts);
            //t.IsBackground = true;
            //t.Start();
            //string pluginPath = Environment.CurrentDirectory + "\\plugins\\";  //插件目录
            //var player = new VlcPlayerBase(pluginPath);
            //player.SetRenderWindow((int)this.Handle);//panel
            // player.LoadFile("d:\\1.mkv");//视频文件路径
            CreateUDPReceive();
            CreateUDPConnect();
        }

        private void CreateUDPReceive()
        {
            Thread t = new Thread(new ThreadStart(CreateUDPServer));
            t.IsBackground = true;
            t.Start();
        }


        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private void CreateUDPServer()
        {

            var receieveUdpClient = new UdpClient(10887);


            Byte[] receiveBytes = receieveUdpClient.Receive(ref RemoteIpEndPoint);
            var str = Encoding.UTF8.GetString(receiveBytes);
            
        }

        private void CreateUDPConnect()
        {
            Thread t = new Thread(new ThreadStart(CreateUDP));
            t.IsBackground = true;
            t.Start();
        }

        private void CreateUDP()
        {
            GlobalVariable.client.CreateUDPStudentHole();
        }

        private void DoAction(Action action)
        {
            this.InvokeOnUiThreadIfRequired(action);
        }




        Thread theadScreen;
        private void Client_OnReveieveData(ReceieveMessage message)
        {
            //DoAction(() => {
            //    this.richTextBox1.AppendText(JsonHelper.SerializeObj(message) + "\r\n");
            //});
            switch (message.Action)
            {
                case (int)CommandType.TeacherLoginIn://教师端登录

                    DoAction(() =>
                    {
                        if (theadScreen == null || theadScreen.ThreadState != ThreadState.Running)
                        {
                            TeacherLoginInResponse teachRes = JsonHelper.DeserializeObj<TeacherLoginInResponse>(message.DataStr);
                            GlobalVariable.TeacherIP = teachRes.teachIP;
                            theadScreen = new Thread(new ThreadStart(GetScreenCapture));

                            theadScreen.IsBackground = true;
                            theadScreen.Start();
                        }

                    });
                    break;
                case (int)CommandType.TeacherLoginOut://教师端登出
                    if (theadScreen != null && theadScreen.ThreadState == ThreadState.Background)
                    {
                        isRunScreen = false;
                        Thread.Sleep(200);
                        theadScreen.Abort();
                    }
                    break;
                case (int)CommandType.ScreenInteract://收到视频流
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    DoAction(() =>
                    {
                        ShowViewRtsp2(resp.url);

                    });
                    break;
                case (int)CommandType.StopScreenInteract://收到视频流停止
                    DoAction(() =>
                    {
                        StopPlay();

                    });

                    break;
                case (int)CommandType.LockScreen://锁屏
                    LockScreen(false);
                    break;
                case (int)CommandType.StopLockScreen://终止锁屏
                    StopLockScreen();
                    break;
                case (int)CommandType.Quiet://屏幕肃静
                    LockScreen(true);
                    break;
                case (int)CommandType.StopQuiet://终止屏幕肃静
                    StopLockScreen();
                    break;

                case (int)CommandType.PrivateChat://收到私聊信息
                    var chatResponse = JsonHelper.DeserializeObj<PrivateChatRequest>(message.DataStr);
                    DoAction(() =>
                    {
                        var chatMessage = chatResponse.ToChatMessage();
                        OpenChatForm(chatMessage);
                    });
                    break;
                case (int)CommandType.TeamChat://收到群聊信息
                    var teamChatResponse = JsonHelper.DeserializeObj<TeamChatRequest>(message.DataStr);

                    DoAction(() =>
                    {
                        var request = teamChatResponse.ToChatMessage();
                        OpenChatForm(request);
                    });
                    break;
                case (int)CommandType.GroupChat://收到群聊信息
                    var groupChatResponse = JsonHelper.DeserializeObj<GroupChatRequest>(message.DataStr);

                    DoAction(() =>
                    {
                        var request = groupChatResponse.ToChatMessage();
                        OpenChatForm(request);
                    });
                    break;
                case (int)CommandType.BeginCall://开始点名
                    DoAction(() =>
                    {
                        OpenCallForm();

                    });

                    break;
                case (int)CommandType.EndCall://结束点名
                    DoAction(() =>
                    {
                        CloseCallForm();

                    });

                    break;
                case (int)CommandType.CreateTeam://收到创建群组信息
                    var teamInfo = JsonHelper.DeserializeObj<TeamChatCreateOrUpdateRequest>(message.DataStr);
                    GlobalVariable.RefleshTeamList(teamInfo);
                    DoAction(() =>
                    {
                        chatForm.BringToFront();
                        chatForm.Show();
                        chatForm.ReflashTeamChat();


                    });

                    break;
                case (int)CommandType.CallStudentShow://收到请求学生演示
                    DoAction(() =>
                    {
                        GlobalVariable.client.CreateScreenInteract();
                        GlobalVariable.client.Send_ScreenInteract();

                    });
                    break;
                case (int)CommandType.StopStudentShow://停止演示
                    DoAction(() =>
                    {
                        GlobalVariable.client.StopScreenInteract();
                        GlobalVariable.client.Send_StopScreenInteract();

                    });
                    break;
                case (int)CommandType.ForbidPrivateChat://收到禁止私聊
                    GlobalVariable.LoginUserInfo.AllowPrivateChat = false;
                    ChangeChatAllowOrForbit(ChatType.PrivateChat, false);
                    break;
                case (int)CommandType.ForbidTeamChat://收到禁止群聊
                    GlobalVariable.LoginUserInfo.AllowTeamChat = false;
                    ChangeChatAllowOrForbit(ChatType.TeamChat, false);
                    break;
                case (int)CommandType.AllowPrivateChat://收到允许私聊
                    GlobalVariable.LoginUserInfo.AllowPrivateChat = true;
                    ChangeChatAllowOrForbit(ChatType.PrivateChat, true);
                    break;
                case (int)CommandType.AllowTeamChat://收到允许群聊
                    GlobalVariable.LoginUserInfo.AllowTeamChat = true;
                    ChangeChatAllowOrForbit(ChatType.TeamChat, true);
                    break;
                default:
                    break;
            }
        }


        private void ChangeChatAllowOrForbit(ChatType chatType, bool isAllow)
        {
            DoAction(() =>
            {
                if (chatForm != null && !chatForm.IsDisposed)
                {
                    chatForm.ChangeAllowChat(chatType, isAllow);
                }

            });
        }




        private void CloseCallForm()
        {
            if (callForm != null)
            {
                callForm.Close();
            }
        }

        private void OpenCallForm()
        {
            if (callForm == null || callForm.IsDisposed)
            {
                callForm = new CallForm();
            }
            callForm.BringToFront();
            callForm.ShowDialog();
        }

        private bool CheckChatFormIsOpen()
        {
            if (chatForm == null)
            {
                return false;
            }
            return !chatForm.IsHide;
            //  return Application.OpenForms.OfType<ChatForm>().Any();
        }



        //private void OpenChatForm(AddChatRequest request)
        //{
        //    GlobalVariable.AddNewChat(request);
        //    chatForm.BringToFront();
        //    chatForm.Show();
        //    chatForm.CreateChatItems(request, true);
        //}

        private void OpenChatForm(ChatMessage message)
        {
            GlobalVariable.AddNewChat(message);
            chatForm.BringToFront();
            chatForm.Show();
            chatForm.CreateChatItems(message, true);
        }


        ///// <summary>
        ///// 窗体隐藏（重载此方法后onload事件不会执行)
        ///// </summary>
        ///// <param name="value"></param>
        //protected override void SetVisibleCore(bool value)
        //{
        //    base.SetVisibleCore(false);
        //}


        //最小化窗体
        private bool windowCreate = true;
        protected override void OnActivated(EventArgs e)
        {
            if (windowCreate)
            {
                base.Visible = false;
                windowCreate = false;
            }

            base.OnActivated(e);
        }




        private void ShowViewRtsp2(string rtsp)
        {

            if (videoPlayer2 == null || videoPlayer2.IsDisposed)
            {
                videoPlayer2 = new ViewRtsp(rtsp);
            }
            videoPlayer2.Show();
            //  videoPlayer = f;
            videoPlayer2.startPlay();

        }




        private void StopPlay()
        {
            if (videoPlayer2 != null)
            {
                videoPlayer2.Close();
                videoPlayer2 = null;
            }

        }

        /// <summary>
        /// 锁屏（禁止鼠标和键盘)
        /// </summary>
        private void LockScreen(bool isSlient)
        {
            // BlockInput(true);
            // actHook = new Cls.UserActivityHook();
            //actHook.OnMouseActivity += ActHook_OnMouseActivity;
            //actHook.KeyDown += ActHook_KeyDown;
            //actHook.KeyPress += ActHook_KeyPress;
            //actHook.KeyUp += ActHook_KeyUp;
            //     actHook.Start();
            DoAction(() =>
            {
                if (bsForm == null)
                {
                    BlackScreen frm = new BlackScreen(isSlient);
                    frm.Show();
                    bsForm = frm;
                }
            });


        }

        /// <summary>
        /// 撤销锁屏
        /// </summary>
        private void StopLockScreen()
        {
            //   BlockInput(false);
            //if (actHook != null)
            //{
            //    actHook.Stop();
            //}
            DoAction(() =>
            {
                if (bsForm != null)
                {
                    bsForm.EnableMouseAndKeyboard();
                    bsForm.Close();
                    bsForm = null;
                }
                //FormCollection fc = Application.OpenForms;
                //foreach (Form frm in fc)
                //{
                //    if (frm.Name == "BlackScreen")
                //    {
                //        frm
                //        frm.Close();
                //        break;
                //    }
                //}

            });
        }


        private void btnLockScreen_Click(object sender, EventArgs e)
        {

            LockScreen(true);
        }

        private void btnStopLockScreen_Click(object sender, EventArgs e)
        {
            StopLockScreen();
        }



        private void UserMainForm_Shown(object sender, EventArgs e)
        {
            // this.Hide();
        }




        #region 右键菜单

        //签到
        private void mSignIn_Click(object sender, EventArgs e)
        {
            OpenCallForm();
        }
        private void mChat_Click(object sender, EventArgs e)
        {
            chatForm.BringToFront();
            chatForm.Show();
        }

        private void mHandUp_Click(object sender, EventArgs e)
        {

        }

        private void mPrivateSMS_Click(object sender, EventArgs e)
        {

        }

        private void mFileShare_Click(object sender, EventArgs e)
        {

        }

        private void mExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var url = "rtsp://184.72.239.149/vod/mp4://BigBuckBunny_175k.mov";
            ShowViewRtsp2(url);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopPlay();
        }

        private void btnScreenCapture_Click(object sender, EventArgs e)
        {


        }
        ScreenCapture sc = new ScreenCapture();
        object obLock = new object();
        private void GetScreenCapture()
        {

            //  sc = new ScreenCapture();
            //// capture entire screen, and save it to a file
            ////  Image img = sc.CaptureScreen();
            //// display image in a Picture control named imageDisplay
            ////  this.pictureBox1.Image = img;
            //// capture this window, and save it
            //string pathPerc = @"Send.png";
            //string source = @"Capture.png";
            //sc.CaptureScreenToFile(source, ImageFormat.Png);
            //getThumImage(source, 40, 5, pathPerc);
            //string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathPerc);
            //GlobalVariable.client.SendDesktopPic(fullPath);
            isRunScreen = true;
            while (isRunScreen)
            {
                lock (obLock)
                {
                    try
                    {
                        Image img = sc.CaptureScreen();
                        var thumImg = getThumImage(img, 40, 5);

                        ScreenCaptureInfo info = new ScreenCaptureInfo();
                        info.DisplayName = GlobalVariable.LoginUserInfo.DisplayName;
                        info.UserName = GlobalVariable.LoginUserInfo.UserName;

                        var userJson = JsonHelper.SerializeObj(info);
                        byte[] userBytes = Encoding.UTF8.GetBytes(userJson);
                        byte[] userLengthBytes = BitConverter.GetBytes(userBytes.Length);
                        byte[] imgBytes = FileHelper.ImageToByteArray(thumImg);
                        byte[] imgLengthBytes = BitConverter.GetBytes(imgBytes.Length);
                        byte[] allLengtBytes = BitConverter.GetBytes(userBytes.Length + userLengthBytes.Length + imgBytes.Length + imgLengthBytes.Length);


                        List<byte> byteSource = new List<byte>();
                        byteSource.AddRange(allLengtBytes);
                        byteSource.AddRange(userLengthBytes);
                        byteSource.AddRange(userBytes);
                        byteSource.AddRange(imgLengthBytes);
                        byteSource.AddRange(imgBytes);
                        var sendBytes = byteSource.ToArray();

                        GlobalVariable.client.SendDesktopPic(sendBytes, GlobalVariable.TeacherIP);
                        GlobalVariable.client.StopUdp();
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Loger.LogMessage(ex);
                    }

                }
            }


        }




        private Image getThumImage(Image image, long quality, int multiple)

        {
            Bitmap newImage = null;
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(image);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/png");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                //   newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                sourceImage.Dispose();

            }
            catch (Exception ex)
            {
                Loger.LogMessage(ex);
            }
            return newImage;
        }

        /// <param name="sourceFile">原始图片文件</param>  
        /// <param name="quality">质量压缩比</param>  
        /// <param name="multiple">收缩倍数</param>  
        /// <param name="outputFile">输出文件名</param>  
        /// <returns>成功返回true,失败则返回false</returns> 
        private bool getThumImage(String sourceFile, long quality, int multiple, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/png");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;

                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                sourceImage.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // 获取图片编码信息  
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private void UserMainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            GlobalVariable.client.Send_StudentLoginOut();
        }
    }



    public class ScreenCapture
    {
        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns></returns>
        public Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }
        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return img;
        }
        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }
        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            Image img = CaptureScreen();
            img.Save(filename, format);
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
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

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
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
    }
}
