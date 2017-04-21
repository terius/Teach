using CCWin;
using Common;
using Helpers;
using Model;
using SharedForms;
using System;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class UserMainForm : CSkinBaseForm
    {

        Cls.UserActivityHook actHook;
        private BlackScreen bsForm = null;
        private delegate void DoSomething();
        // MyTcpClient client;
        ViewRtsp videoPlayer;
        ChatForm chatForm = new ChatForm();
        Form1 tform;

        public UserMainForm()
        {
            InitializeComponent();

        }



        private void UserMainForm_Load(object sender, System.EventArgs e)
        {

            Text = GlobalVariable.LoginUserInfo.DisplayName;
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            tform = new Form1();
            //  chatForm.Show();
            //string pluginPath = Environment.CurrentDirectory + "\\plugins\\";  //插件目录
            //var player = new VlcPlayerBase(pluginPath);
            //player.SetRenderWindow((int)this.Handle);//panel
            //player.LoadFile("d:\\1.mkv");//视频文件路径
        }





        private void Client_OnReveieveData(ReceieveMessage message)
        {
            appendMsg(JsonHelper.SerializeObj(message));
            switch (message.Action)
            {
                case (int)CommandType.ScreenInteract:
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    showViewRtsp(resp.url);
                    break;
                case (int)CommandType.LockScreen:
                    // LockScreenReponse lsresp = JsonHelper.DeserializeObj<LockScreenReponse>(message.DataStr);
                    // BlockInput(true);
                    LockScreen();
                    break;
                case (int)CommandType.StopLockScreen:
                    StopLockScreen();
                    break;

                case (int)CommandType.PrivateChat:
                    var chatResponse = JsonHelper.DeserializeObj<PrivateChatRequest>(message.DataStr);

                    this.InvokeOnUiThreadIfRequired(() =>
                    {
                        AddChat(chatResponse);
                    });
                    break;
                default:
                    break;
            }
        }

        private void AddChat(PrivateChatRequest chatResponse)
        {
            AddChatRequest request = new AddChatRequest();
            request.ChatDisplayName = chatResponse.sendname;
            request.ChatType = ChatType.PrivateChat;
            request.ChatUserName = chatResponse.sendname;
            GlobalVariable.AddNewChat(request);


            // tform.InvokeOnUiThreadIfRequired(() =>
            //  {
            tform.Show();
            //chatForm.BringToFront();
            //chatForm.CreateChatItems(request, false);
            //chatForm.Show();

            //  });





        }

        private void appendMsg(string msg)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.richTextBox1.AppendText(msg + "\r\n");

                }));
            }
            else
            {
                this.richTextBox1.AppendText(msg + "\r\n");

            }
        }






        private void showViewRtsp(string rtsp)
        {
            // throw new NotImplementedException();
            this.Invoke(new Action(() =>
            {
                videoPlayer = new ViewRtsp(rtsp);
                videoPlayer.Show();
                //  videoPlayer = f;
                videoPlayer.startPlay();
            }));
        }

        /// <summary>
        /// 锁屏（禁止鼠标和键盘)
        /// </summary>
        private void LockScreen()
        {
            //  actHook = new Cls.UserActivityHook();
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            //actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            //actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            //actHook.KeyUp += new KeyEventHandler(MyKeyUp);
            //    actHook.Start();

            this.BeginInvoke(new Action(() =>
            {
                BlackScreen frm = new BlackScreen();
                frm.Show();
                bsForm = frm;
            }));

        }

        /// <summary>
        /// 撤销锁屏
        /// </summary>
        private void StopLockScreen()
        {
            if (actHook != null)
            {
                actHook.Stop();
            }
            this.BeginInvoke(new Action(() =>
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "BlackScreen")
                    {
                        frm.Close();
                        break;
                    }
                }
            }));
        }

        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            LockScreen();
        }

        private void btnStopLockScreen_Click(object sender, EventArgs e)
        {
            StopLockScreen();
        }



        private void UserMainForm_Shown(object sender, EventArgs e)
        {
         //   this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok");
        }

        private void mCloseForm_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void mChat_Click(object sender, EventArgs e)
        {
            OpenChatForm();
        }

        private void mHandUp_Click(object sender, EventArgs e)
        {

        }

        private void mFileShare_Click(object sender, EventArgs e)
        {

        }

        private void mLetter_Click(object sender, EventArgs e)
        {

        }

        private void OpenChatForm()
        {
            if (chatForm == null)
            {
                MessageBox.Show("当前未有聊天对象");
                return;
            }
            chatForm.Show();
        }
    }
}
