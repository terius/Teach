using Common;
using Helpers;
using Model;
using SharedForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySocket;

namespace NewTeacher
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        #region 自定义字段
        //  private static bool beingCallTheRoll = false;//
        // private bool beingScreenBroadcast = false;//正在屏幕广播
        private static bool beingWatching = false;//正在查看学生端
                                                  // private string rtspAddress = null;
        private ChatForm chatForm;
        //  IList<OnlineListResult> userOnlineList;
        OnlineInfo onlineInfo;
       // bool chatFormIsShow;
        #endregion


        [DllImport("bin\\SceRecordSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 SceRecStartRecordV(string path);

        [DllImport("bin\\SceRecordSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 SceRecStopRecordV();

        string savePath;

        public BaseForm()
        {
            InitializeComponent();
            onlineInfo = new OnlineInfo();
            onlineInfo.OnLineChange += OnlineInfo_OnLineChange1;
            onlineInfo.AddOnLine += OnlineInfo_AddOnLine;
            onlineInfo.DelOnLine += OnlineInfo_DelOnLine;


        }

        private void OnlineInfo_DelOnLine(UserLogoutResponse delInfo)
        {
            DoAction(() =>
            {
                foreach (ListViewItem item in this.onlineList.Items)
                {
                    if (item.SubItems[2].Text == delInfo.username)
                    {
                        item.Remove();
                        break;
                    }
                }
            });
        }

        private void OnlineInfo_AddOnLine(object sender, OnlineEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => AddUserList(e.OnLines));
        }

        private void OnlineInfo_OnLineChange1(object sender, OnlineEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => userListShow(e.OnLines));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chatForm = new ChatForm();
            //  this.Icon = Resources.ter16;
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            GlobalVariable.client.Send_OnlineList();
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

        private void Client_OnReveieveData(ReceieveMessage message)
        {
            messageList.InvokeOnUiThreadIfRequired(() => messageList.AppendText(message.DataStr));
            switch (message.Action)
            {
                case (int)CommandType.OnlineList://在线用户
                    var userList2 = JsonHelper.DeserializeObj<List<OnlineListResult>>(message.DataStr);
                    onlineInfo.OnOnlineChange(userList2);
                    break;
                case (int)CommandType.PrivateChat://接收到学生私聊信息
                    var PrivateChatResponse = JsonHelper.DeserializeObj<PrivateChatRequest>(message.DataStr);
                    this.InvokeOnUiThreadIfRequired(() => { AppendToPrivateForm(PrivateChatResponse); });
                    break;
                case (int)CommandType.OneUserLogIn://某个学生登录
                    var newUser = JsonHelper.DeserializeObj<List<OnlineListResult>>(message.DataStr);

                    onlineInfo.OnNewUserLoginIn(newUser);
                    //  OnlineInfo_AddOnLine(onlineInfo, e2);
                    break;
                case (int)CommandType.StudentCall://课堂点名
                    var callInfo = JsonHelper.DeserializeObj<StuCallRequest>(message.DataStr);
                    UpdateOnLineStatus(callInfo);
                    break;
                case (int)CommandType.UserLoginOut:
                    var loginoutInfo = JsonHelper.DeserializeObj<UserLogoutResponse>(message.DataStr);
                    onlineInfo.OnUserLoginOut(loginoutInfo);
                    break;
                default:
                    break;
            }
        }



        private void DoAction(Action action)
        {
            this.InvokeOnUiThreadIfRequired(action);
        }

        private void UpdateOnLineStatus(StuCallRequest callInfo)
        {
            foreach (OnlineListResult item in onlineInfo.OnLineList)
            {
                if (item.username == callInfo.username)
                {
                    item.IsCalled = true;
                    break;
                }
            }
            DoAction(() =>
            {
                foreach (ListViewItem item in onlineList.Items)
                {
                    // string nickname = item.Text;
                    //   string no = item.SubItems[3].Text;
                    string userName = item.SubItems[2].Text;
                    if (userName == callInfo.username)
                    {
                        item.SubItems[1].Text = "是";
                        break;
                    }
                }

            });

        }

        public void startRecord()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\\Videos\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            savePath = path + "record_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4";
            // savePath = @"d:\video\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4";
            SceRecStartRecordV(savePath);

        }


        /// <summary>
        /// 接收到私聊信息
        /// </summary>
        /// <param name="privateChatResponse"></param>
        private void AppendToPrivateForm(PrivateChatRequest privateChatResponse)
        {
            AddChatRequest request = privateChatResponse.ToAddChatRequest();
            GlobalVariable.AddNewChat(request);
            if (CheckChatFormIsOpen())
            {
                //   chatForm.DoReveieveMessage(request);
                OpenOrCreateChatForm(request, true);
            }
            else
            {
                OpenOrCreateChatForm(request, true);
                // ShowNotify(request);
            }

        }

        /// <summary>
        /// 打开或创建聊天窗口
        /// </summary>
        /// <param name="request"></param>
        public void OpenOrCreateChatForm(AddChatRequest request, bool fromReceMsg)
        {
            //chatFormIsShow = CheckChatFormIsOpen();
            //if (chatForm == null)
            //{
            //    chatForm = new ChatForm();
            //    isOpen = false;
            //}

            chatForm.BringToFront();
            chatForm.CreateChatItems(request, fromReceMsg);
            chatForm.Show();
        }


        private void ShowNotify(AddChatRequest request)
        {
            //上次登录历史窗体
            //frmNotify frm = new frmNotify(request);
            //   frm.Show(this);
            //获取屏幕宽高与调节最大大小
            // this.MaximumSize = new Size(543, Screen.GetWorkingArea(this).Height);
        }


        #region 顶部菜单
        /// <summary>
        /// 导出签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void class_exportSign_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 班级点名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void class_call_Click(object sender, EventArgs e)
        {
            CallForm frm = new CallForm();
            frm.ShowDialog(this);
        }
        /// <summary>
        /// 分组讨论
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team_discuss_Click(object sender, EventArgs e)
        {
            TeamDiscuss frm = new TeamDiscuss(onlineInfo);
            frm.ShowDialog();
        }

        /// <summary>
        /// 查看分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team_view_Click(object sender, EventArgs e)
        {
            TeamView frm = new TeamView();
            frm.ShowDialog();
        }
        /// <summary>
        /// 屏幕肃静
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_slient_Click(object sender, EventArgs e)
        {
            if (this.control_slient.Text == "屏幕肃静")
            {
                GlobalVariable.client.Send_Quiet();
                control_slient.Text = "解除屏幕肃静";
            }
            else
            {
                GlobalVariable.client.Send_StopQuiet();
                control_slient.Text = "屏幕肃静";
            }

        }
        /// <summary>
        /// 远程控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_remoteControl_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 禁止鼠标和键盘（等同于锁屏）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseKeyboardMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 屏幕广播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void video_Broadcast_Click(object sender, EventArgs e)
        {
            string text = this.video_Broadcast.Text;
            if (text == "屏幕广播")
            {
                if (!beingWatching)
                {
                    GlobalVariable.client.CreateScreenInteract();
                    GlobalVariable.client.Send_ScreenInteract();
                    this.video_Broadcast.Text = "关闭广播";
                    //beingScreenBroadcast = true;
                }
                else
                {
                    //  showTip();
                    return;
                }
            }
            else
            {
                GlobalVariable.client.StopScreenInteract();
                GlobalVariable.client.Send_StopScreenInteract();
                this.video_Broadcast.Text = "屏幕广播";

              //  beingScreenBroadcast = false;
            }
        }



        /// <summary>
        /// 学生演示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void video_studentShow_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 视频直播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void video_live_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 文件共享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void file_dispatch_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 账号管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void other_userManager_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 视频录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void other_screenRecord_Click(object sender, EventArgs e)
        {
            if (this.other_screenRecord.Text == "屏幕录制")
            {
                startRecord();
                this.other_screenRecord.Text = "停止录制";
            }
            else
            {
                endRecord();
                this.other_screenRecord.Text = "屏幕录制";
                if (MessageBox.Show("录像已保存到" + savePath + ",是否要直接播放录像？", "已保存录像", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(savePath);
                }

            }
        }

        public void endRecord()
        {
            var i = SceRecStopRecordV();

        }

        #endregion
        #region 在线列表右键菜单
        /// <summary>
        /// 私聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_privateChat_Click(object sender, EventArgs e)
        {
            string userName = this.onlineList.SelectedItems[0].SubItems[2].Text;
            string displayName = this.onlineList.SelectedItems[0].Text;
            AddChatRequest request = new AddChatRequest();
            request.DisplayName = displayName;
            request.ChatType = ChatType.PrivateChat;
            request.UserName = userName;
            request.UserType = ClientRole.Student;
            GlobalVariable.AddNewChat(request);
            OpenOrCreateChatForm(request, false);
        }
        /// <summary>
        /// 锁屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_lockScreen_Click(object sender, EventArgs e)
        {
            string username = this.onlineList.SelectedItems[0].SubItems[2].Text;
            GlobalVariable.client.Send_LockScreen(username);
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_stopLockScreen_Click(object sender, EventArgs e)
        {
            string username = this.onlineList.SelectedItems[0].SubItems[2].Text;
            GlobalVariable.client.Send_StopLockScreen(username);
        }

        /// <summary>
        /// 禁止私聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_P_forbidPrivateChat_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 禁止群聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_P_forbidGroupChat_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 允许私聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_P_allowPrivateChat_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 允许群聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_P_allowGroupChat_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 学生演示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_studentShow_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 停止学生演示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userList_stopStudentShow_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 显示在线用户列表
        /// </summary>
        /// <param name="onLineList"></param>
        private void userListShow(IList<OnlineListResult> list)
        {
            this.onlineList.Items.Clear();
            AddOnlineUser(list);
        }

        private void AddOnlineUser(IList<OnlineListResult> list)
        {
            foreach (OnlineListResult item in list)
            {
                if (!IsMySelf(item.username))
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.Text = item.nickname;
                    listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 39;
                    listItem.SubItems.Add(item.IsCalled ? "是" : "");
                    listItem.SubItems.Add(item.username);
                    listItem.SubItems.Add(item.no.ToString());
                    this.onlineList.Items.Add(listItem);

                }
            }
        }


        private void AddUserList(IList<OnlineListResult> list)
        {
            AddOnlineUser(list);
        }




        /// <summary>
        /// 刷新用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {

        }





        #endregion

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.video_Broadcast.Text == "关闭广播")
                {
                    DialogResult r = MessageBox.Show("屏幕广播尚未关闭，确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (r != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        GlobalVariable.client.Close().Wait();
                        System.Environment.Exit(0);
                    }
                }
                else
                {
                    DialogResult r = MessageBox.Show("确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (r != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        GlobalVariable.client.Close().Wait();
                        System.Environment.Exit(0);
                    }
                }
            }
        }

        private void class_groupChat_Click(object sender, EventArgs e)
        {

        }

        public bool IsMySelf(string userName)
        {
            return userName == GlobalVariable.LoginUserInfo.UserName;
        }

        /// <summary>
        /// 用户列表选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineList_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = onlineList.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    onlineList.ContextMenuStrip = UserListMenu;
                }
                else
                {
                    onlineList.ContextMenuStrip = null;
                }
                return;
            }
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            GlobalVariable.client.Send_OnlineList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm frm = new MainForm();
            frm.ShowDialog();
        }
    }

}
