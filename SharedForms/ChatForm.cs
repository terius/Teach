
using Common;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using Model;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class ChatForm : XtraForm
    {




        #region 变量
        /// <summary>
        /// 文本格式
        /// </summary>
        Font messageFont = new Font("微软雅黑", 9);
        Color messageColor = Color.FromArgb(255, 32, 32, 32);
        string _myDisplayName = GlobalVariable.LoginUserInfo.DisplayName;
        string _myUserName = GlobalVariable.LoginUserInfo.UserName;

        ChatStore selectChatStore;
        string selectUserName = "";
        public delegate void ReveieveMessageHandle(object sender, ReceieveMessageEventArgs e);
        public event ReveieveMessageHandle ReveieveMessage;
        //  ChatListSubItem selectedSubItem;

        public bool IsHide { get; set; }
        public AddChatRequest newMessage;
        NavBarItem rightSelectedNavBarItem = null;
        #endregion


        #region 事件

        public void DoReveieveMessage(AddChatRequest message)
        {
            BringToFront();
            //     newMessage = message;
            ReceieveMessageEventArgs e = new ReceieveMessageEventArgs(message);
            ReveieveMessage(this, e);
        }



        #endregion



        #region 无参构造
        //public ChatForm(AddChatRequest request)
        //{
        //    InitializeComponent();
        //    //加载表情到文本框
        //    this.chatBoxSend.Initialize(GlobalResourceManager.EmotionDictionary);
        //    this.chatBox_history.Initialize(GlobalResourceManager.EmotionDictionary);
        //    //  _displayName = request.ChatDisplayName;
        //    //  _userName = request.ChatUserName;
        //    CreateChatItems(request);

        //}

        public ChatForm()
        {
            InitializeComponent();
            //AddChatRequest allreq = new AddChatRequest();
            //allreq.ChatType = ChatType.GroupChat;
            //allreq.DisplayName = "所有人";
            //allreq.UserName = "alluser";
            //allreq.UserType = ClientRole.Teacher;

            var groupChat = GlobalVariable.CreateGroupChat();
            if (groupChat != null)
            {
                ChatNav.CreateItem(groupChat);
            }
        
            // ReveieveMessage += ChatForm_ReveieveMessage; ;
        }

        //private void ChatForm_ReveieveMessage(object sender, ReceieveMessageEventArgs e)
        //{
        //    ChatMessage message = e.Message.ToChatMessage();
        //    ChatItem2 chatItem = GetItemInChatListBox(e.Message);
        //    if (chatItem == null)
        //    {
        //        ChatListItem item = GetChatItem(e.Message.ChatType);
        //        chatItem = new ChatItem2(item, e.Message);

        //    }

        //    if (chatListBox1.SelectSubItem == chatItem)
        //    {
        //        AppendMessageAndSave(message);
        //    }
        //    else
        //    {
        //        chatItem.IsTwinkle = true;
        //        chatItem.AddNewMessage(message);
        //    }

        //}



        /// <summary>
        /// 创建聊天对象
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCreate"></param>
        public void CreateChatItems(AddChatRequest request, bool fromReceieveMessage)
        {
            //    _formIsOpen = formIsOpend;
            IsHide = false;
            ReflashTeamChat();
            ChatItem chatItem = GetItemInChatListBox(request);
            if (chatItem == null)
            {
                chatItem = ChatNav.CreateItem(request);

            }

            if (fromReceieveMessage)
            {
                if (chatItem.UserName != selectUserName)
                {
                    chatItem.Caption = chatItem.DisplayName + " 有新消息！";
                }
                else
                {
                    ChatItemSelected(chatItem, false);
                }
            }
            else
            {
                ChatItemSelected(chatItem, false);
            }
        }

        private void ChatItemSelected(ChatItem chatItem, bool fromClick)
        {
            //  chatItem.Caption = chatItem.DisplayName;
            this.labChatTitle.Text = "与【" + chatItem.DisplayName + "】的对话：";
            if (fromClick && chatItem.UserName == selectUserName)
            {
                return;
            }
            if (chatItem.UserName != selectUserName)
            {
                LoadChatMessage(chatItem);
                //   ClearSelect();
            }
            AppendNewMessage(chatItem);
            selectUserName = chatItem.UserName;
            ChatNav.SelectedLink = chatItem.Links[0];
            //  ChatNav.Groups[0].SelectedLink = chatItem.Links[0];

            //    chatItem.Selected = true;
            //    chatList.Select();
        }

        //private void ClearSelect()
        //{
        //    foreach (ChatItem item in ChatNav.SelectedItems)
        //    {
        //        item.Selected = false;
        //    }
        //}

        public void ReflashTeamChat()
        {
            if (GlobalVariable.IsTeamChatChanged)
            {
                GlobalVariable.IsTeamChatChanged = false;
                var list = GlobalVariable.GetTeamChatList();
                ChatNav.Groups[1].ItemLinks.Clear();
                //this.chatList.Groups[1].Items.Clear();
                //int len = chatList.Items.Count;
                //while (--len >= 0)
                //{
                //    if (((ChatItem)chatList.Items[len]).ChatType == ChatType.TeamChat)
                //    {
                //        chatList.Items[len].Remove();
                //    }
                //}
                foreach (ChatStore item in list)
                {
                    ChatNav.CreateItem(item);
                }
            }
        }

        /// <summary>
        /// 检查当前聊天对象是否存在
        /// </summary>
        /// <param name="chatUserName"></param>
        /// <returns></returns>
        private ChatItem GetItemInChatListBox(AddChatRequest request)
        {
            foreach (ChatItem item in ChatNav.Items)
            {
                if (item.UserName == request.UserName)
                {
                    return item;
                }
            }


            //var item = GetGroup(request.ChatType);
            //if (item != null)
            //{
            //    foreach (NavBarItemLink subItem in item.ItemLinks)
            //    {
            //        if (((ChatItem)subItem.Item).UserName == request.UserName)
            //        {
            //            return (ChatItem)subItem.Item;
            //        }
            //    }
            //}

            return null;
        }




        //private void RefreshChatList()
        //{
        //    ReflashTeamChat();
        //    ReflashPrivateChatList();
        //}

        //private void ReflashPrivateChatList()
        //{
        //    throw new NotImplementedException();
        //}



        private NavBarGroup GetGroup(ChatType type)
        {
            NavBarGroup item = null;
            switch (type)
            {
                case ChatType.PrivateChat:
                    item = ChatNav.Groups[2];
                    break;
                case ChatType.GroupChat:
                    item = ChatNav.Groups[0];
                    break;
                case ChatType.TeamChat:
                    item = ChatNav.Groups[1];
                    break;
                default:
                    break;
            }
            return item;
        }

        private void AppendNewMessage(ChatItem subItem)
        {
            selectChatStore = subItem.GetChatStore();
            if (selectChatStore != null)
            {
                if (selectChatStore.NewMessageList != null)
                {

                    foreach (ChatMessage item in selectChatStore.NewMessageList)
                    {
                        AppendMessage(item, false);
                    }
                    GlobalVariable.SaveChatMessage(smsPanel1, subItem.UserName);
                    //   this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
                    //  this.chatBox_history.ScrollToCaret();
                }
            }
            // GlobalVariable.GetNewMessageList(subItem.);
        }

        //private void AppendMessageAndSave(ChatMessage message)
        //{
        //    AppendMessage(message, false);
        //    GlobalVariable.SaveChatMessage(smsPanel1, message.SendUserName);
        //    // this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
        //    //   this.chatBox_history.ScrollToCaret();
        //}

        /// <summary>
        /// 加载聊天历史记录
        /// </summary>
        private void LoadChatMessage(ChatItem subItem)
        {
            // if (chatListBox1.SelectSubItem != subItem)
            // {
            //  chatListBox1.SelectSubItem = subItem;
            // chatBox_history.Text = "";
            var chatStore = subItem.GetChatStore();
            if (chatStore == null)
            {
                return;
            }
            if (chatStore.HistoryContent == null)
            {
                chatStore.HistoryContent = new smsPanel();
                //   chatStore.HistoryContent.BackColor = Color.Red;
                //   chatStore.HistoryContent.Dock = DockStyle.None;
                panelControl2.Controls.Add(chatStore.HistoryContent);
            }
            smsPanel1 = chatStore.HistoryContent;
            chatStore.HistoryContent.BringToFront();
            //    AddContentToHistoryBox(chatStore.HistoryContent);

        }
        #endregion


        //private void AddContentToHistoryBox(ChatBoxContent content)
        //{
        //    chatBox_history.AppendChatBoxContent(content);
        //    this.chatBox_history.AppendText("\n");
        //    this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
        //    this.chatBox_history.ScrollToCaret();
        //}


        #region 窗体重绘时
        //private void ChatForm_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    g.SmoothingMode = SmoothingMode.HighQuality;
        //    //  this.chatBox_history.BackColor = Color.WhiteSmoke;
        //    ////全屏蒙浓遮罩层
        //    //g.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), new Rectangle(0, 0, this.Width, this.chatBox_history.Top));
        //    //g.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), new Rectangle(0, this.chatBox_history.Top, this.chatBox_history.Width + this.chatBox_history.Left, this.Height - this.chatBox_history.Top));

        //    //线条
        //    // g.DrawLine(new Pen(Color.FromArgb(180, 198, 221)), new Point(0, this.chatBox_history.Top - 1), new Point(chatBox_history.Right, this.chatBox_history.Top - 1));
        //    //   g.DrawLine(new Pen(Color.FromArgb(180, 198, 221)), new Point(0, this.chatBox_history.Bottom), new Point(chatBox_history.Right, this.chatBox_history.Bottom));
        //}
        #endregion

        #region 发送信息
        private void SendMessageCommand(string receieveUserName, string msg)
        {
            var chatType = GlobalVariable.GetChatType(receieveUserName);
            if (chatType == ChatType.PrivateChat)
            {
                PrivateChatRequest request = new PrivateChatRequest();
                request.guid = Guid.NewGuid().ToString();
                request.msg = msg;
                request.receivename = receieveUserName;
                request.SendDisplayName = GlobalVariable.LoginUserInfo.DisplayName;
                request.SendUserName = GlobalVariable.LoginUserInfo.UserName;
                request.clientRole = GlobalVariable.LoginUserInfo.UserType;
                GlobalVariable.client.Send_PrivateChat(request);
            }
            else if (chatType == ChatType.TeamChat)
            {
                var chat = GlobalVariable.GetChatStoreByUserName(receieveUserName);
                TeamChatRequest request = new TeamChatRequest();
                request.groupname = chat.ChatDisplayName;
                request.groupuserList = chat.GetUserNames();
                request.msg = msg;
                request.username = GlobalVariable.LoginUserInfo.UserName;
                GlobalVariable.client.SendMessage(request, CommandType.TeamChat);
            }
            //   GlobalVariable.AddPrivateChatToChatList(_userName, GlobalVariable.LoginUserInfo.DisplayName, msg);


        }
        #endregion



        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.IsHide = true;
            this.Hide();
            e.Cancel = true;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {


        }



        public bool IsMySelf(string sendUserName)
        {
            return GlobalVariable.LoginUserInfo.UserName == sendUserName;
        }


        private void AppendMessage(ChatMessage chatMessage, bool isInput)
        {
            bool isMySelf = IsMySelf(chatMessage.SendUserName);
            smsPanel1.AddMessage(chatMessage, isMySelf);
            //var color = chatMessage.SendUserName == _myUserName ? Color.SeaGreen : Color.Blue;
            //var showTime = chatMessage.SendTime.ToString("yyyy-MM-dd HH:mm:ss");
            //this.chatBox_history.AppendRichText(string.Format("{0}  {1}\n",
            //    chatMessage.SendDisplayName, showTime),
            //    new Font(this.messageFont, FontStyle.Regular), color);
            //this.chatBox_history.AppendChatBoxContent(chatMessage.Content);
            //this.chatBox_history.AppendText("\n");


            if (isInput)
            {
                //   this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
                //   this.chatBox_history.ScrollToCaret();
                //清空发送输入框
                this.sendBox.Text = string.Empty;
                this.sendBox.Focus();
            }


        }






        private void btnSend_Click_1(object sender, EventArgs e)
        {
            string content = sendBox.Text;
            //发送内容为空时，不做响应
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }
            if (ChatNav.SelectedLink == null)
            {
                GlobalVariable.ShowWarnning("请先选择聊天对象");
                return;
            }
            SendMessageCommand(selectUserName, content);
            var message = new ChatMessage(_myUserName, _myDisplayName, selectUserName, content, GlobalVariable.LoginUserInfo.UserType);
            AppendMessage(message, true);
            GlobalVariable.SaveChatMessage(smsPanel1, selectUserName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.IsHide = true;
            this.Hide();
        }

        private void ChatNav_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            // var selectItem = chatList.SelectedItems[0];
            ChatItemSelected(e.Link.Item as ChatItem, true);
        }

        private void ChatNav_CustomDrawLink(object sender, CustomDrawNavBarElementEventArgs e)
        {
            NavBarItemLink link = ((NavLinkInfoArgs)e.ObjectInfo).Link;
            if (link.State == DevExpress.Utils.Drawing.ObjectState.Selected
                || link.State == DevExpress.Utils.Drawing.ObjectState.Hot
                )
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue, e.RealBounds);
            }
        }

        private void itemViewTeamMem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TeamView frm = new TeamView();
            frm.ShowDialog();
        }

        private void ChatNav_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                NavBarHitInfo hit = ChatNav.CalcHitInfo(e.Location);

                if ((!hit.InLink))
                {
                    return;
                }

                if (hit.Group.Name != "navBarGroup2")
                {
                    return;
                }
                rightSelectedNavBarItem = hit.Link.Item;
                Point p = new Point(e.Location.X, e.Location.Y + ChatNav.Appearance.Item.FontHeight);
                popupMenu1.ShowPopup(ChatNav.PointToScreen(p));

                //FieldInfo fi = typeof(NavBarControl).GetField("viewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
                //NavBarViewInfo vi = fi.GetValue(ChatNav) as NavBarViewInfo;
                //rightSelectedNavBarItem = vi.HotTrackedLink.Item;
                //NavLinkInfoArgs arg = vi.GetLinkInfo(hit.Link);
                //Point p = new Point(arg.Bounds.X, arg.Bounds.Bottom);
                // popupMenu1.ShowPopup(ChatNav.PointToScreen(p));
            }
        }
    }

    public class ReceieveMessageEventArgs : EventArgs

    {
        private AddChatRequest _message;

        public ReceieveMessageEventArgs(AddChatRequest message)
        {
            this._message = message;
        }
        public AddChatRequest Message
        {
            get { return _message; }
        }


    }


}
