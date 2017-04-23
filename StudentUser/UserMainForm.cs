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


        public UserMainForm()
        {
            InitializeComponent();

        }



        private void UserMainForm_Load(object sender, System.EventArgs e)
        {

            Text = GlobalVariable.LoginUserInfo.DisplayName;
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;

            //  chatForm.Show();
            //string pluginPath = Environment.CurrentDirectory + "\\plugins\\";  //插件目录
            //var player = new VlcPlayerBase(pluginPath);
            //player.SetRenderWindow((int)this.Handle);//panel
            // player.LoadFile("d:\\1.mkv");//视频文件路径
        }

        private void DoAction(Action action)
        {
            this.InvokeOnUiThreadIfRequired(action);
        }



        private void Client_OnReveieveData(ReceieveMessage message)
        {
            //DoAction(() => {
            //    this.richTextBox1.AppendText(JsonHelper.SerializeObj(message) + "\r\n");
            //});
            // appendMsg(JsonHelper.SerializeObj(message));
            switch (message.Action)
            {
                case (int)CommandType.ScreenInteract:
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    ShowViewRtsp(resp.url);
                    break;
                case (int)CommandType.StopScreenInteract:
                    StopRtsp();
                    break;
                case (int)CommandType.LockScreen:
                    // LockScreenReponse lsresp = JsonHelper.DeserializeObj<LockScreenReponse>(message.DataStr);
                    // BlockInput(true);
                    LockScreen(false);
                    break;
                case (int)CommandType.StopLockScreen:
                    StopLockScreen();
                    break;
                case (int)CommandType.Quiet:
                    LockScreen(true);
                    break;
                case (int)CommandType.StopQuiet:
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
            AddChatRequest request = chatResponse.ToAddChatRequest();
            GlobalVariable.AddNewChat(request);
            chatForm.BringToFront();
            chatForm.CreateChatItems(request, false);
            chatForm.Show();
        }


        private void ShowViewRtsp(string rtsp)
        {
            DoAction(() =>
            {
                videoPlayer = new ViewRtsp(rtsp);
                videoPlayer.Show();
                //  videoPlayer = f;
                videoPlayer.startPlay();
            });
        }

        private void StopRtsp()
        {
            DoAction(() =>
            {
                if (videoPlayer != null)
                {
                    videoPlayer.Close();
                    videoPlayer = null;
                }
            });
        }

        /// <summary>
        /// 锁屏（禁止鼠标和键盘)
        /// </summary>
        private void LockScreen(bool isSlient)
        {
            actHook = new Cls.UserActivityHook();
            //actHook.OnMouseActivity += ActHook_OnMouseActivity;
            //actHook.KeyDown += ActHook_KeyDown;
            //actHook.KeyPress += ActHook_KeyPress;
            //actHook.KeyUp += ActHook_KeyUp;
            actHook.Start();
            DoAction(() =>
            {
                BlackScreen frm = new BlackScreen(isSlient);
                frm.Show();
                bsForm = frm;
            });


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
            DoAction(() =>
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

            });
        }

        private void ActHook_KeyUp(object sender, KeyEventArgs e)
        {
            actHook.Start();
        }

        private void ActHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            actHook.Start();
        }

        private void ActHook_KeyDown(object sender, KeyEventArgs e)
        {
            actHook.Start();
        }

        private void ActHook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            actHook.Start();
        }

      

      

        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStopLockScreen_Click(object sender, EventArgs e)
        {
          
        }



        private void UserMainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok");
        }

        private void mCloseForm_Click(object sender, EventArgs e)
        {
            //  this.tuopan.Dispose();
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
