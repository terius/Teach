using Common;
using DevExpress.XtraEditors;
using Helpers;
using Model;
using MySocket;
using SharedForms;
using System;

namespace StudentUser
{
    public partial class UserMainForm : XtraForm
    {
        private BlackScreen bsForm = null;
        // VLCPlayer videoPlayer;
        ChatForm chatForm = new ChatForm();
        ViewRtsp videoPlayer2;
        CallForm callForm;
        public UserMainForm()
        {
            InitializeComponent();
            Text = GlobalVariable.LoginUserInfo.DisplayName;
            tuopan.Text = Text;
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            GlobalVariable.client.Send_StudentInMainForm();
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
                        AddChatRequest request = chatResponse.ToAddChatRequest();
                        OpenChatForm(request);
                    });
                    break;
                case (int)CommandType.TeamChat://收到群聊信息
                    var teamChatResponse = JsonHelper.DeserializeObj<TeamChatRequest>(message.DataStr);

                    DoAction(() =>
                    {
                        AddChatRequest request = teamChatResponse.ToAddChatRequest();
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


        private void ChangeChatAllowOrForbit(ChatType chatType,bool isAllow)
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



        private void OpenChatForm(AddChatRequest request)
        {
            GlobalVariable.AddNewChat(request);
            chatForm.BringToFront();
            chatForm.Show();
            chatForm.CreateChatItems(request, true);
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
            var url = "rtsp://184.72.239.149/vod/mp4://BigBuckBunny_175k.mov";
            ShowViewRtsp2(url);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopPlay();
        }
    }
}
