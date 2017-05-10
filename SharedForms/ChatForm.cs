using CCWin.SkinControl;
using Common;
using Model;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class ChatForm : Form
    {
        #region 变量
        /// <summary>
        /// 文本格式
        /// </summary>
        Font messageFont = new Font("微软雅黑", 9);
        Color messageColor = Color.FromArgb(255, 32, 32, 32);
        string _myDisplayName = GlobalVariable.LoginUserInfo.DisplayName;
        string _myUserName = GlobalVariable.LoginUserInfo.UserName;
        bool _formIsOpen;
        ChatStore selectChatStore;
        string selectUserName = "";
        public delegate void ReveieveMessageHandle(object sender, ReceieveMessageEventArgs e);
        public event ReveieveMessageHandle ReveieveMessage;
        //  ChatListSubItem selectedSubItem;

        public bool IsHide { get; set; }
        public AddChatRequest newMessage;
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
            ChatItem3 item = new ChatItem3();
            item.Group = chatList.Groups[0];
            item.ImageIndex = 0;
            item.Text = "所有人";
            item.UserName = "allpeople";
            item.ChatType = ChatType.GroupChat;
            item.DisplayName = "所有人";
            chatList.Items.Add(item);
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
            ChatItem3 chatItem = GetItemInChatListBox(request);
            if (chatItem == null)
            {
                chatItem = chatList.CreateItem(request);

            }

            if (fromReceieveMessage)
            {
                if (chatItem.UserName != selectUserName)
                {
                    chatItem.Text = chatItem.DisplayName + " 有新消息！";
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

        private void ChatItemSelected(ChatItem3 chatItem, bool fromClick)
        {
          //  chatItem.Text = chatItem.DisplayName;
            this.labChatTitle.Text = "与" + chatItem.Text + "的对话：";
            if (fromClick && chatItem.UserName == selectUserName)
            {
                return;
            }
            if (chatItem.UserName != selectUserName)
            {
                LoadChatMessage(chatItem);
                ClearSelect();
            }
            AppendNewMessage(chatItem);
            selectUserName = chatItem.UserName;
            chatItem.Selected = true;
            chatList.Select();
        }

        private void ClearSelect()
        {
            foreach (ChatItem3 item in chatList.SelectedItems)
            {
                item.Selected = false;
            }
        }

        public void ReflashTeamChat()
        {
            if (GlobalVariable.IsTeamChatChanged)
            {
                GlobalVariable.IsTeamChatChanged = false;
                var list = GlobalVariable.GetTeamChatList();
                this.chatList.Groups[1].Items.Clear();
                foreach (ChatStore item in list)
                {
                    chatList.CreateItem(item);
                }
            }
        }

        /// <summary>
        /// 检查当前聊天对象是否存在
        /// </summary>
        /// <param name="chatUserName"></param>
        /// <returns></returns>
        private ChatItem3 GetItemInChatListBox(AddChatRequest request)
        {
            ListViewGroup item = GetGroup(request.ChatType);
            if (item != null)
            {
                foreach (ChatItem3 subItem in item.Items)
                {
                    if (subItem.UserName == request.UserName)
                    {
                        return subItem;
                    }
                }
            }

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

        private void AddNewChatItem(AddChatRequest request)
        {

        }

        private ListViewGroup GetGroup(ChatType type)
        {
            ListViewGroup item = null;
            switch (type)
            {
                case ChatType.PrivateChat:
                    item = chatList.Groups[2];
                    break;
                case ChatType.GroupChat:
                    item = chatList.Groups[0];
                    break;
                case ChatType.TeamChat:
                    item = chatList.Groups[1];
                    break;
                default:
                    break;
            }
            return item;
        }










        private void AppendNewMessage(ChatItem3 subItem)
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
                    GlobalVariable.SaveChatMessage(chatBox_history.GetContent(), subItem.UserName);
                    this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
                    this.chatBox_history.ScrollToCaret();
                }
            }
            // GlobalVariable.GetNewMessageList(subItem.);
        }

        private void AppendMessageAndSave(ChatMessage message)
        {
            AppendMessage(message, false);
            GlobalVariable.SaveChatMessage(chatBox_history.GetContent(), message.SendUserName);
            this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
            this.chatBox_history.ScrollToCaret();
        }

        /// <summary>
        /// 加载聊天历史记录
        /// </summary>
        private void LoadChatMessage(ChatItem3 subItem)
        {
            // if (chatListBox1.SelectSubItem != subItem)
            // {
            //  chatListBox1.SelectSubItem = subItem;
            chatBox_history.Text = "";
            var chatStore = subItem.GetChatStore();
            if (chatStore == null)
            {
                return;
            }
            AddContentToHistoryBox(chatStore.HistoryContent);

        }
        #endregion


        private void AddContentToHistoryBox(ChatBoxContent content)
        {
            chatBox_history.AppendChatBoxContent(content);
            this.chatBox_history.AppendText("\n");
            this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
            this.chatBox_history.ScrollToCaret();
        }


        #region 窗体重绘时
        private void ChatForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //  this.chatBox_history.BackColor = Color.WhiteSmoke;
            ////全屏蒙浓遮罩层
            //g.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), new Rectangle(0, 0, this.Width, this.chatBox_history.Top));
            //g.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), new Rectangle(0, this.chatBox_history.Top, this.chatBox_history.Width + this.chatBox_history.Left, this.Height - this.chatBox_history.Top));

            //线条
            // g.DrawLine(new Pen(Color.FromArgb(180, 198, 221)), new Point(0, this.chatBox_history.Top - 1), new Point(chatBox_history.Right, this.chatBox_history.Top - 1));
            //   g.DrawLine(new Pen(Color.FromArgb(180, 198, 221)), new Point(0, this.chatBox_history.Bottom), new Point(chatBox_history.Right, this.chatBox_history.Bottom));
        }
        #endregion

        #region 发送信息
        private void SendMessageCommand(string receieveUserName, string msg)
        {

            PrivateChatRequest request = new PrivateChatRequest();
            request.guid = Guid.NewGuid().ToString();
            request.msg = msg;
            request.receivename = receieveUserName;
            request.SendDisplayName = GlobalVariable.LoginUserInfo.DisplayName;
            request.SendUserName = GlobalVariable.LoginUserInfo.UserName;
            GlobalVariable.client.Send_PrivateChat(request);
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

            this.IsHide = true;
            this.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatBoxContent content = this.chatBoxSend.GetContent();
            //发送内容为空时，不做响应
            if (content.IsEmpty())
            {
                return;
            }

            if (chatList.SelectedItems == null)
            {
                GlobalVariable.ShowWarnning("请先选择聊天对象");
                return;
            }

            //  string userName = chatListBox1.SelectSubItem.Tag.ToString();
            SendMessageCommand(selectUserName, content.Text);
            var message = new ChatMessage(_myUserName, _myDisplayName, selectUserName, content);
            AppendMessage(message, true);
            GlobalVariable.SaveChatMessage(chatBox_history.GetContent(), selectUserName);
            //  GlobalVariable.SaveChatMessage(message, true);
        }




        private void AppendMessage(ChatMessage chatMessage, bool isInput)
        {
            var color = chatMessage.SendUserName == _myUserName ? Color.SeaGreen : Color.Blue;
            var showTime = chatMessage.SendTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.chatBox_history.AppendRichText(string.Format("{0}  {1}\n",
                chatMessage.SendDisplayName, showTime),
                new Font(this.messageFont, FontStyle.Regular), color);
            this.chatBox_history.AppendChatBoxContent(chatMessage.Content);
            this.chatBox_history.AppendText("\n");


            if (isInput)
            {
                this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
                this.chatBox_history.ScrollToCaret();
                //清空发送输入框
                this.chatBoxSend.Text = string.Empty;
                this.chatBoxSend.Focus();
            }
        }




        private void chatList_Click(object sender, EventArgs e)
        {
            var selectItem = chatList.SelectedItems[0];
            ChatItemSelected(selectItem as ChatItem3, true);
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
