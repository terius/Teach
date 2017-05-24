using System;
using System.Windows.Forms;
using SharedForms;
using Model;
using System.Collections.Generic;
using Common;
using Helpers;

namespace NewTeacher
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region 自定义字段
        OnlineInfo onlineInfo;
        ChatForm chatForm;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            InitOnlineInfo();
            //  menuClassNamed.ImageOptions.LargeImage.h.
            //  menuClassNamed.ItemAppearance.SetFont(new Font("微软雅黑", 10F));
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



        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chatForm = new ChatForm();
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            GlobalVariable.client.Send_OnlineList();
        }



        #region 顶部菜单
        private void menuExportSign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuClassNamed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuGroupChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

        }

        private void menuDisableMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuScreenShare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ribbon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuStudentShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuVideoLive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void menuFileShare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        #endregion


        #region 用户列表右键菜单

        private void userList_privateChat_Click(object sender, EventArgs e)
        {
            string userName =lvOnline.SelectedItems[0].SubItems[2].Text;
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
            chatForm.CreateChatItems(request, fromReceMsg);
            chatForm.Show();
        }



        private void userList_lockScreen_Click(object sender, EventArgs e)
        {

        }

        private void userList_stopLockScreen_Click(object sender, EventArgs e)
        {

        }

        private void userList_P_forbidPrivateChat_Click(object sender, EventArgs e)
        {

        }

        private void userList_P_forbidGroupChat_Click(object sender, EventArgs e)
        {

        }

        private void userList_P_allowPrivateChat_Click(object sender, EventArgs e)
        {

        }

        private void userList_P_allowGroupChat_Click(object sender, EventArgs e)
        {

        }

        private void userList_studentShow_Click(object sender, EventArgs e)
        {

        }

        private void userList_stopStudentShow_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}