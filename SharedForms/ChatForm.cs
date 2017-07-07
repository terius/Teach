
using Common;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using Helpers;
using Model;
using Model.Views;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class ChatForm : XtraForm
    {
        #region 变量
        /// <summary>
        /// 当前用户姓名
        /// </summary>
        string _myDisplayName = GlobalVariable.LoginUserInfo.DisplayName;
        /// <summary>
        /// 当前用户登录名
        /// </summary>
        string _myUserName = GlobalVariable.LoginUserInfo.UserName;

        /// <summary>
        /// 选择聊天的用户名
        /// </summary>
        string selectUserName = "";

        /// <summary>
        /// 页面是否关闭或隐藏
        /// </summary>
        public bool IsHide { get; set; }
        #endregion
        
        #region 构造函数


        public ChatForm()
        {
            InitializeComponent();
            var groupChat = GlobalVariable.CreateGroupChat();
            if (groupChat != null)
            {
                ChatNav.CreateItem(groupChat);
            }
        }

        #endregion
        
        #region 方法
        /// <summary>
        /// 创建聊天对象
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCreate"></param>
        public void CreateChatItems(AddChatRequest request, bool fromReceieveMessage)
        {
            this.Text = GlobalVariable.LoginUserInfo.DisplayName + " 的聊天窗口";
            IsHide = false;
            ReflashTeamChat();
            ChatItem chatItem = GetItemInChatListBox(request.UserName);
            if (chatItem == null)
            {
                chatItem = ChatNav.CreateItem(request);

            }

            if (fromReceieveMessage)
            {
                if (chatItem.UserName != selectUserName)
                {
                    //chatItem.Caption = chatItem.DisplayName + " 有新消息！";
                    chatItem.SmallImage = Resource1.新消息;
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

        /// <summary>
        /// 聊天列表对象被选中
        /// </summary>
        /// <param name="chatItem"></param>
        /// <param name="fromClick"></param>
        private void ChatItemSelected(ChatItem chatItem, bool fromClick)
        {
            this.labChatTitle.Text = "与【" + chatItem.DisplayName + "】的对话：";
          //  chatItem.Caption = chatItem.DisplayName;
            if (fromClick && chatItem.UserName == selectUserName)
            {
                return;
            }
            if (chatItem.UserName != selectUserName)
            {
                LoadChatMessage(chatItem);
            }
            AppendNewMessage(chatItem);
            selectUserName = chatItem.UserName;
            ChatNav.SelectedLink = chatItem.Links[0];
        }


        /// <summary>
        /// 刷新群组信息
        /// </summary>
        public void ReflashTeamChat()
        {
            if (GlobalVariable.IsTeamChatChanged)
            {
                GlobalVariable.IsTeamChatChanged = false;
                var list = GlobalVariable.GetTeamChatList();
                ChatNav.Groups[1].ItemLinks.Clear();
                foreach (ChatStore item in list)
                {
                    ChatNav.CreateItem(item);
                }
            }
        }

        /// <summary>
        /// 获取当前聊天对象
        /// </summary>
        /// <param name="chatUserName"></param>
        /// <returns></returns>
        private ChatItem GetItemInChatListBox(string userName)
        {
            foreach (ChatItem item in ChatNav.Items)
            {
                if (item.UserName == userName)
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// 显示新的聊天信息
        /// </summary>
        /// <param name="subItem"></param>
        private void AppendNewMessage(ChatItem subItem)
        {
            var selectChatStore = subItem.GetChatStore();
            if (selectChatStore != null)
            {
                if (selectChatStore.NewMessageList != null)
                {

                    foreach (ChatMessage item in selectChatStore.NewMessageList)
                    {
                        AppendMessage(item, false);
                    }
                    GlobalVariable.SaveChatMessage(smsPanel1, subItem.UserName);
                }
            }
        }



        /// <summary>
        /// 加载聊天历史记录
        /// </summary>
        private void LoadChatMessage(ChatItem subItem)
        {
            var chatStore = subItem.GetChatStore();
            if (chatStore == null)
            {
                return;
            }
            if (chatStore.HistoryContent == null)
            {
                chatStore.HistoryContent = new smsPanel();
                panelControl2.Controls.Add(chatStore.HistoryContent);
            }
            smsPanel1 = chatStore.HistoryContent;
            chatStore.HistoryContent.BringToFront();

        }




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


        /// <summary>
        /// 发送聊天信息
        /// </summary>
        /// <param name="receieveUserName"></param>
        /// <param name="msg"></param>
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
                request.groupid = receieveUserName;
                request.SendDisplayName = GlobalVariable.LoginUserInfo.DisplayName;
                GlobalVariable.client.SendMessage(request, CommandType.TeamChat);
            }
            //   GlobalVariable.AddPrivateChatToChatList(_userName, GlobalVariable.LoginUserInfo.DisplayName, msg);


        }


        /// <summary>
        /// 发送者是否为当前登录人
        /// </summary>
        /// <param name="sendUserName"></param>
        /// <returns></returns>
        public bool IsMySelf(string sendUserName)
        {
            return GlobalVariable.LoginUserInfo.UserName == sendUserName;
        }


        /// <summary>
        /// 添加聊天信息
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <param name="isInput"></param>
        private void AppendMessage(ChatMessage chatMessage, bool isInput)
        {
            bool isMySelf = IsMySelf(chatMessage.SendUserName);
            smsPanel1.AddMessage(chatMessage, isMySelf);
            if (isInput)
            {
                //清空发送输入框
                this.sendBox.Text = string.Empty;
                this.sendBox.Focus();
            }
        }

        AlertControl messagebox;
        private void ShowNotify(string msg)
        {
            if (messagebox == null)
            {
                messagebox = new AlertControl();
                messagebox.AutoFormDelay = 500;
                messagebox.ShowPinButton = false;
            }
            messagebox.Show(this, "信息", msg);
        }
        #endregion
        
        #region 事件

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.IsHide = true;
            this.Hide();
        }


        /// <summary>
        /// 聊天列表选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatNav_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            // var selectItem = chatList.SelectedItems[0];
            ChatItemSelected(e.Link.Item as ChatItem, true);
        }

        /// <summary>
        /// 显示选中背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatNav_CustomDrawLink(object sender, CustomDrawNavBarElementEventArgs e)
        {
            NavBarItemLink link = ((NavLinkInfoArgs)e.ObjectInfo).Link;
            if (link.State == DevExpress.Utils.Drawing.ObjectState.Selected
                || link.State == DevExpress.Utils.Drawing.ObjectState.Hot
                )
            {
                link.Item.AppearancePressed.ForeColor = Color.White;
                e.Graphics.FillRectangle(Brushes.DodgerBlue, e.RealBounds);
            }
        }

        /// <summary>
        /// 打开查看群组成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemViewTeamMem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TeamView frm = new TeamView();
            frm.ShowDialog();
        }


        /// <summary>
        /// 群组列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                Point p = new Point(e.Location.X, e.Location.Y + ChatNav.Appearance.Item.FontHeight);
                popupMenu1.ShowPopup(ChatNav.PointToScreen(p));
            }
        }

       

    
        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.IsHide = true;
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "媒体文件 (*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";
            dlg.Title = "选择媒体文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileHelper.UploadFile(dlg.FileName, MyConfig.UploadFileServer, (ob, ea) =>
                {
                    string result = Encoding.UTF8.GetString(ea.Result);
                    UploadResult uploadResult = JsonHelper.DeserializeObj<UploadResult>(result);
                    if (uploadResult.error == 0)
                    {
                        uploadResult.url = "http://" + MyConfig.ServerIp + ":8080" + uploadResult.url;
                    }
                    FileInfo fi = new FileInfo(dlg.FileName);
                    var uploadtext = _myDisplayName + "上传了文件:" + fi.Name;
                    var message = new ChatMessage(_myUserName, _myDisplayName, selectUserName, uploadtext, GlobalVariable.LoginUserInfo.UserType, MessageType.Link);
                    message.DownloadFileUrl = uploadResult.url;
                    AppendMessage(message, true);
                    GlobalVariable.SaveChatMessage(smsPanel1, selectUserName);
                    ShowNotify("上传成功");
                });

            }
        }


        /// <summary>
        /// 发送聊天信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        #endregion

        
    }


}
