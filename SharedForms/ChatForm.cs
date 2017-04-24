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
        string selectUserName;
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
            this.chatBoxSend.Initialize(GlobalResourceManager.EmotionDictionary);
            this.chatBox_history.Initialize(GlobalResourceManager.EmotionDictionary);
            ReveieveMessage += ChatForm_ReveieveMessage; ;
        }

        private void ChatForm_ReveieveMessage(object sender, ReceieveMessageEventArgs e)
        {
            ChatMessage message = e.Message.ToChatMessage();
            ChatItem2 chatItem = GetItemInChatListBox(e.Message);
            if (chatItem == null)
            {
                ChatListItem item = GetChatItem(e.Message.ChatType);
                chatItem = new ChatItem2(item, e.Message);

            }

            if (chatListBox1.SelectSubItem == chatItem)
            {
                AppendMessageAndSave(message);
            }
            else
            {
                chatItem.IsTwinkle = true;
                chatItem.AddNewMessage(message);
            }

        }



        /// <summary>
        /// 创建聊天对象
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCreate"></param>
        public void CreateChatItems(AddChatRequest request, bool isOpen)
        {
            _formIsOpen = isOpen;
            IsHide = false;
            ReflashTeamChat();
            ChatItem2 chatItem = GetItemInChatListBox(request);
            if (chatItem == null)
            {
                ChatListItem item = GetChatItem(request.ChatType);
                chatItem = new ChatItem2(item, request);

            }
            SubItemSelected(chatItem);
        }

        private void SubItemSelected(ChatItem2 subItem, bool isFromClick = false)
        {

            this.labChatTitle.Text = "与" + subItem.DisplayName + "的对话：";
            if (isFromClick)
            {
                if (selectUserName == subItem.UserName)
                {
                    return;
                }
            }
            else
            {

            }
            // selectedSubItem = subItem;
            subItem.OwnerListItem.IsOpen = true;
            if (chatListBox1.SelectSubItem != subItem)
            {
                LoadChatMessage(subItem);
            }
            AppendNewMessage(subItem);
            //ChatListClickEventArgs ce = new ChatListClickEventArgs(subItem);

            //MouseEventArgs ms = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
            //chatListBox1_ClickSubItem(chatListBox1, ce, ms);
            //chatListBox1.SelectSubItem = subItem;
            chatListBox1.SelectSubItem = subItem;
            selectUserName = subItem.Tag.ToString();

        }

        public void ReflashTeamChat()
        {
            if (GlobalVariable.IsTeamChatChanged)
            {
                GlobalVariable.IsTeamChatChanged = false;
                var list = GlobalVariable.GetTeamChatList();
                this.chatListBox1.Items[1].SubItems.Clear();
                foreach (ChatStore item in list)
                {
                    ChatItem2 subItem = new ChatItem2(chatListBox1.Items[1], item);
                }
            }
        }

        /// <summary>
        /// 检查当前聊天对象是否存在
        /// </summary>
        /// <param name="chatUserName"></param>
        /// <returns></returns>
        private ChatItem2 GetItemInChatListBox(AddChatRequest request)
        {
            ChatListItem item = GetChatItem(request.ChatType);
            if (item != null)
            {
                foreach (ChatItem2 subItem in item.SubItems)
                {
                    if (subItem.Tag.ToString() == request.UserName)
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

        private ChatListItem GetChatItem(ChatType type)
        {
            ChatListItem item = null;
            switch (type)
            {
                case ChatType.PrivateChat:
                    item = chatListBox1.Items[2];
                    break;
                case ChatType.GroupChat:
                    item = chatListBox1.Items[0];
                    break;
                case ChatType.TeamChat:
                    item = chatListBox1.Items[1];
                    break;
                default:
                    break;
            }
            return item;
        }








    

        private void AppendNewMessage(ChatItem2 subItem)
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
        private void LoadChatMessage(ChatItem2 subItem)
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

      

     

     



        #region 截图
        /// <summary>
        /// 截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolPrintScreen_ButtonClick(object sender, EventArgs e)
        {
            this.StartCapture();
        }

        //截图方法
        private void StartCapture()
        {
            FrmCapture imageCapturer = new FrmCapture();
            if (imageCapturer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.Forms.IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {//如果剪贴板中的数据是文本格式
                    GifBox gif = this.chatBoxSend.InsertImage((Bitmap)iData.GetData(DataFormats.Bitmap));
                    this.chatBoxSend.Focus();
                    this.chatBoxSend.ScrollToCaret();
                    imageCapturer.Close();
                    imageCapturer = null;
                }
            }
        }
        #endregion

        #region 表情窗体与事件
        public FrmCountenance _faceForm = null;
        public FrmCountenance FaceForm
        {
            get
            {
                if (this._faceForm == null)
                {
                    this._faceForm = new FrmCountenance(this)
                    {
                        ImagePath = "Face\\",
                        CustomImagePath = "Face\\Custom\\",
                        CanManage = true,
                        ShowDemo = true,
                    };

                    this._faceForm.Init(24, 24, 8, 8, 12, 8);
                    this._faceForm.Selected += this._faceForm_AddFace;

                }

                return this._faceForm;
            }
        }

        string imgName = "";
        void _faceForm_AddFace(object sender, SelectFaceArgs e)
        {
            this.imgName = e.Img.FullName.Replace(Application.StartupPath + "\\", "");
            this.chatBoxSend.InsertDefaultEmotion((uint)e.ImageIndex);
        }
        #endregion

        #region 表情按钮事件
        private void toolCountenance_Click(object sender, EventArgs e)
        {
            //  Point pt = this.PointToScreen(new Point(skToolMenu.Left + 30 - this.FaceForm.Width / 2, (skToolMenu.Top - this.FaceForm.Height)));
            // this.FaceForm.Show(pt.X, pt.Y, skToolMenu.Height);
        }
        #endregion


     

   

        #region 字体
        //显示字体对话框
        private void toolFont_Click(object sender, EventArgs e)
        {
            this.fontDialog.Font = this.chatBoxSend.Font;
            this.fontDialog.Color = this.chatBoxSend.ForeColor;
            if (DialogResult.OK == this.fontDialog.ShowDialog())
            {
                this.chatBoxSend.Font = this.fontDialog.Font;
                this.chatBoxSend.ForeColor = this.fontDialog.Color;
            }
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
            listView1.Items[0].Selected = true;
            listView1.Select();
            this.Text = listView1.Items[0].Text;
            //this.IsHide = true;
            //   this.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatBoxContent content = this.chatBoxSend.GetContent();
            //发送内容为空时，不做响应
            if (content.IsEmpty())
            {
                return;
            }

            if (chatListBox1.SelectSubItem == null)
            {
                GlobalVariable.ShowWarnning("请先选择聊天对象");
                return;
            }

            string userName = chatListBox1.SelectSubItem.Tag.ToString();
            SendMessageCommand(userName, content.Text);
            var message = new ChatMessage(_myUserName, _myDisplayName, userName, content);
            AppendMessage(message, true);
            GlobalVariable.SaveChatMessage(chatBox_history.GetContent(), userName);
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

        private void chatListBox1_ClickSubItem(object sender, ChatListClickEventArgs e, MouseEventArgs es)
        {
            SubItemSelected(e.SelectSubItem as ChatItem2);
            // MessageBox.Show(e.SelectSubItem.DisplayName);


        }

        private void chatListBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
           // MessageBox.Show("aaaa");
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
         //   MessageBox.Show(e.Item.Text);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
          //  var selectItem = my.SelectedItems[0];
        //    this.Text = selectItem.Text;
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
