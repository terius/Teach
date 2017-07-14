using System;
using System.Windows.Forms;
using SharedForms;
using Model;
using System.Collections.Generic;
using Common;
using Helpers;
using MySocket;

namespace NewTeacher
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region 自定义字段
        OnlineInfo onlineInfo;
        ChatForm chatForm;
        //  string soundSource;
        bool isPush = false;//是否正在推送视频流
        string actionStuUserName;
        ViewRtsp videoPlayer;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            InitOnlineInfo();
            //  menuClassNamed.ImageOptions.LargeImage.h.
            //  menuClassNamed.ItemAppearance.SetFont(new Font("微软雅黑", 10F));
            //   GetSoundSource();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalVariable.LoadTeamFromXML();
            chatForm = new ChatForm();
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            GlobalVariable.client.Send_OnlineList();

        }



        #region 在线列表
        private void InitOnlineInfo()
        {
            onlineInfo = new OnlineInfo();
            onlineInfo.OnLineChange += OnlineInfo_OnLineChange;
            onlineInfo.AddOnLine += OnlineInfo_AddOnLine;
            onlineInfo.DelOnLine += OnlineInfo_DelOnLine;
        }
        private void OnlineInfo_DelOnLine(UserLogoutResponse delInfo)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                foreach (ListViewItem item in this.lvOnline.Items)
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
            this.InvokeOnUiThreadIfRequired(() => AddOnlineUser(e.OnLines));
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
                    this.lvOnline.Items.Add(listItem);

                }
            }
        }

        private bool IsMySelf(string userName)
        {
            return userName == GlobalVariable.LoginUserInfo.UserName;
        }

        private void OnlineInfo_OnLineChange(object sender, OnlineEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => userListShow(e.OnLines));
        }

        /// <summary>
        /// 显示在线用户列表
        /// </summary>
        /// <param name="onLineList"></param>
        private void userListShow(IList<OnlineListResult> list)
        {
            this.lvOnline.Items.Clear();
            AddOnlineUser(list);
        }

        #endregion

        #region  消息事件
        private void Client_OnReveieveData(ReceieveMessage message)
        {
            //   messageList.InvokeOnUiThreadIfRequired(() => messageList.AppendText(message.DataStr));
            switch (message.Action)
            {
                case (int)CommandType.OnlineList://在线用户
                    var userList2 = JsonHelper.DeserializeObj<List<OnlineListResult>>(message.DataStr);
                    onlineInfo.OnOnlineChange(userList2);
                    break;
                case (int)CommandType.PrivateChat://接收到学生私聊信息
                    var PrivateChatMessage = JsonHelper.DeserializeObj<PrivateChatRequest>(message.DataStr);
                    this.InvokeOnUiThreadIfRequired(() => { ReceievePrivateMessage(PrivateChatMessage); });
                    break;
                case (int)CommandType.TeamChat://收到群聊信息
                    var TeamChatRequest = JsonHelper.DeserializeObj<TeamChatRequest>(message.DataStr);
                    this.InvokeOnUiThreadIfRequired(() => { ReceieveTeamMessage(TeamChatRequest); });
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
                case (int)CommandType.UserLoginOut://用户登出
                    var loginoutInfo = JsonHelper.DeserializeObj<UserLogoutResponse>(message.DataStr);
                    onlineInfo.OnUserLoginOut(loginoutInfo);
                    break;
                case (int)CommandType.ScreenInteract://收到视频流
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    this.InvokeOnUiThreadIfRequired(() =>
                    {
                        PlayRtspVideo(resp.url);
                    });
                    break;
                case (int)CommandType.StopScreenInteract://收到停止接收视频流
                    this.InvokeOnUiThreadIfRequired(() =>
                    {
                        StopPlay();
                    });
                    break;
                default:
                    break;
            }
        }

        private void PlayRtspVideo(string rtsp)
        {

            if (videoPlayer == null || videoPlayer.IsDisposed)
            {
                videoPlayer = new ViewRtsp(rtsp);
            }
            videoPlayer.Show();
            //  videoPlayer = f;
            videoPlayer.startPlay();

        }
        private void StopPlay()
        {
            if (videoPlayer != null)
            {
                videoPlayer.Close();
                videoPlayer = null;
            }

        }

        private void ReceieveTeamMessage(TeamChatRequest message)
        {
            AddChatRequest request = message.ToAddChatRequest();
            GlobalVariable.AddNewChat(request);
            OpenOrCreateChatForm(request, true);
        }


        private void ReceievePrivateMessage(PrivateChatRequest message)
        {
            AddChatRequest request = message.ToAddChatRequest();
            GlobalVariable.AddNewChat(request);
            OpenOrCreateChatForm(request, true);
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
            this.InvokeOnUiThreadIfRequired(() =>
            {
                foreach (ListViewItem item in lvOnline.Items)
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
        private void lvOnline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = lvOnline.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    lvOnline.ContextMenuStrip = UserListMenu;
                }
                else
                {
                    lvOnline.ContextMenuStrip = null;
                }
                return;
            }
        }

        #endregion


        #region 方法

        private string GetSelectStudentUserName()
        {
            if (lvOnline.Items.Count <= 0)
            {
                GlobalVariable.ShowWarnning("当前在线学生为空");
                return "";
            }
            if (lvOnline.SelectedItems.Count <= 0)
            {
                GlobalVariable.ShowWarnning("请先选择学生");
                return "";
            }
            string username = lvOnline.SelectedItems[0].SubItems[2].Text;
            actionStuUserName = username;
            return username;
        }
        #endregion



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GlobalVariable.client.Send_OnlineList();
        }





        #region 顶部菜单
        private void menuExportSign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportSign();

        }

        private void ExportSign()
        {
            //var onlineList = onlineInfo.GetStudentOnlineList();
            if (onlineInfo.LoginedStuList.Count <= 0)
            {
                MessageBox.Show("当前登陆学生为空");
                return;
            }
            var table = new System.Data.DataTable();
            table.Columns.Add("学生姓名", typeof(string));
            table.Columns.Add("是否签到", typeof(string));
            foreach (var item in onlineInfo.LoginedStuList)
            {
                if (item.clientRole == ClientRole.Student)
                {
                    System.Data.DataRow dr = table.NewRow();
                    dr[0] = item.nickname;
                    dr[1] = item.IsCalled ? "是" : "否";
                    table.Rows.Add(dr);
                }
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "导出签到.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelHelper.Export(table, saveFileDialog1.FileName);
                MessageBox.Show("导出成功");
            }

        }

        private void menuClassNamed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CallForm frm = new CallForm();
            frm.ShowDialog(this);
        }

        private void menuGroupChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddChatRequest request = new AddChatRequest();
            request.DisplayName = "所有人";
            request.ChatType = ChatType.PrivateChat;
            request.UserName = "allpeople";
            request.UserType = ClientRole.Student;
            GlobalVariable.AddNewChat(request);
            OpenOrCreateChatForm(request, false);

        }

        private void menuTeamCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TeamDiscuss frm = new TeamDiscuss(onlineInfo);
            frm.ShowDialog();
        }

        private void menuViewTeam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TeamView frm = new TeamView();
            frm.ShowDialog();
        }

        private void menuSilence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Caption == "屏幕肃静")
            {
                GlobalVariable.client.Send_Quiet();
                e.Item.Caption = "解除屏幕肃静";
            }
            else
            {
                GlobalVariable.client.Send_StopQuiet();
                e.Item.Caption = "屏幕肃静";
            }
        }

        private void menuDisableMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvOnline.SelectedItems.Count <= 0)
            {
                return;
            }
            string username = lvOnline.SelectedItems[0].SubItems[2].Text;
            if (e.Item.Caption == "禁止鼠标键盘")
            {
                GlobalVariable.client.Send_LockScreen(username);
                e.Item.Caption = "解锁";
            }
            else
            {
                GlobalVariable.client.Send_StopLockScreen(username);
                e.Item.Caption = "禁止鼠标键盘";
            }
        }

        private void menuScreenShare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string text = e.Item.Caption;
            if (text == "屏幕广播")
            {
                if (!isPush)
                {
                    GlobalVariable.client.CreateScreenInteract();
                    GlobalVariable.client.Send_ScreenInteract();
                    e.Item.Caption = "关闭广播";
                    isPush = true;
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
                e.Item.Caption = "屏幕广播";
                isPush = false;
            }
        }

      



        private void menuStudentShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string text = e.Item.Caption;
            if (text == "学生演示")
            {
                var username = GetSelectStudentUserName();
                if (!string.IsNullOrWhiteSpace(username))
                {
                   
                    GlobalVariable.client.Send_CallStudentShow(username);
                    e.Item.Caption = "关闭演示";

                }

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(actionStuUserName))
                {
                    GlobalVariable.client.Send_StopStudentShow(actionStuUserName);
                    actionStuUserName = null;
                    e.Item.Caption = "学生演示";
                }
            }


        }

        private void menuVideoLive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string text = e.Item.Caption;
            if (text == "视频直播")
            {
                if (!isPush)
                {
                    GlobalVariable.client.CreateScreenInteract();
                    GlobalVariable.client.Send_VideoInteract();
                    e.Item.Caption = "关闭直播";
                    isPush = true;
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
                e.Item.Caption = "视频直播";
                isPush = false;
            }
        }

        private void menuFileShare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        #endregion


        #region 用户列表右键菜单

        private void userList_privateChat_Click(object sender, EventArgs e)
        {
            string userName = lvOnline.SelectedItems[0].SubItems[2].Text;
            string displayName = lvOnline.SelectedItems[0].Text;
            AddChatRequest request = new AddChatRequest();
            request.DisplayName = displayName;
            request.ChatType = ChatType.PrivateChat;
            request.UserName = userName;
            request.UserType = ClientRole.Student;
            GlobalVariable.AddNewChat(request);
            OpenOrCreateChatForm(request, false);
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
            chatForm.Show();
            chatForm.CreateChatItems(request, fromReceMsg);

        }



        private void userList_lockScreen_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_LockScreen(userName);
            }
           
        }

        private void userList_stopLockScreen_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_StopLockScreen(userName);
            }
        }

        private void userList_P_forbidPrivateChat_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_ForbidPrivateChat(userName);
            }
        }

        private void userList_P_forbidGroupChat_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_ForbidTeamChat(userName);
            }
        }

        private void userList_P_allowPrivateChat_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_AllowPrivateChat(userName);
            }
        }

        private void userList_P_allowGroupChat_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_AllowTeamChat(userName);
            }
        }

        private void userList_studentShow_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_CallStudentShow(userName);
            }
        }

        private void userList_stopStudentShow_Click(object sender, EventArgs e)
        {
            var userName = GetSelectStudentUserName();
            if (!string.IsNullOrWhiteSpace(userName))
            {
                GlobalVariable.client.Send_StopStudentShow(userName);
            }
        }

        #endregion
    }
}