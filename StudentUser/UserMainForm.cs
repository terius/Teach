using Common;
using DevExpress.XtraEditors;
using Helpers;
using Model;
using MySocket;
using SharedForms;
using System;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class UserMainForm : XtraForm
    {
        private BlackScreen bsForm = null;
        VLCPlayer videoPlayer;
        ChatForm chatForm = new ChatForm();
        ViewRtsp videoPlayer2;
        CallForm callForm;
        public UserMainForm()
        {
            InitializeComponent();
            Text = GlobalVariable.LoginUserInfo.DisplayName;
            tuopan.Text = Text;
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;

        }
        private void UserMainForm_Load(object sender, System.EventArgs e)
        {



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
            switch (message.Action)
            {
                case (int)CommandType.ScreenInteract:
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    ShowViewRtsp2(resp.url);
                    break;
                case (int)CommandType.StopScreenInteract:
                    StopRtsp();
                    break;
                case (int)CommandType.LockScreen:
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

                    DoAction(() =>
                    {
                        AddChat(chatResponse);
                    });
                    break;
                case (int)CommandType.BeginCall:
                    OpenCallForm();
                    break;
                case (int)CommandType.EndCall:
                    CloseCallForm();
                    break;
                case (int)CommandType.CreateTeam:
                    var teamInfo = JsonHelper.DeserializeObj<TeamChatCreateOrUpdateRequest>(message.DataStr);
                    GlobalVariable.RefleshTeamList(teamInfo);
                    DoAction(() =>
                    {
                        chatForm.BringToFront();
                        chatForm.ReflashTeamChat();
                        chatForm.Show();

                    });

                    break;
                case (int)CommandType.TeamChat:

                    break;
                default:
                    break;
            }
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
            if (callForm == null)
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

        private void AddChat(PrivateChatRequest chatResponse)
        {
            bool isOpen = CheckChatFormIsOpen();
            AddChatRequest request = chatResponse.ToAddChatRequest();
            GlobalVariable.AddNewChat(request);
            chatForm.BringToFront();
            chatForm.CreateChatItems(request, isOpen);
            chatForm.Show();
        }


        ///// <summary>
        ///// 窗体隐藏（重载此方法后onload事件不会执行)
        ///// </summary>
        ///// <param name="value"></param>
        //protected override void SetVisibleCore(bool value)
        //{
        //    base.SetVisibleCore(false);
        //}
        //private bool windowCreate = true;
        //protected override void OnActivated(EventArgs e)
        //{
        //    if (windowCreate)
        //    {
        //        base.Visible = false;
        //        windowCreate = false;
        //    }

        //    base.OnActivated(e);
        //}


        private void ShowViewRtsp(string rtsp)
        {
            DoAction(() =>
            {
                if (videoPlayer == null)
                {
                    videoPlayer = new VLCPlayer();
                }
                videoPlayer.Show();
                //  videoPlayer = f;
                videoPlayer.StartPlayStream(rtsp);
            });
        }

        private void ShowViewRtsp2(string rtsp)
        {
            DoAction(() =>
            {
                if (videoPlayer2 == null)
                {
                    videoPlayer2 = new ViewRtsp(rtsp);
                }
                videoPlayer2.Show();
                //  videoPlayer = f;
                videoPlayer2.startPlay();
            });
        }

        private void StopRtsp()
        {
            DoAction(() =>
            {
                if (videoPlayer != null)
                {
                    videoPlayer.StopPlay();
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
            // BlockInput(true);
            // actHook = new Cls.UserActivityHook();
            //actHook.OnMouseActivity += ActHook_OnMouseActivity;
            //actHook.KeyDown += ActHook_KeyDown;
            //actHook.KeyPress += ActHook_KeyPress;
            //actHook.KeyUp += ActHook_KeyUp;
            //     actHook.Start();
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

        private void mSignIn_Click(object sender, EventArgs e)
        {

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
            if (videoPlayer == null)
            {
                videoPlayer = new VLCPlayer();
            }
            videoPlayer.Show();
            //  videoPlayer = f;
            videoPlayer.StartPlayLocation("e:\\terius\\hkdg.mkv");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopRtsp();
        }
    }
}
