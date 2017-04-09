

using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class MyChatForm : CCSkinMain
    {
        #region 变量
        /// <summary>
        /// 文本格式
        /// </summary>
        private Font messageFont = new Font("微软雅黑", 9);

        private ChatListSubItem qqUser;
        /// <summary>
        /// QQ聊天用户
        /// </summary>
        public ChatListSubItem QQUser
        {
            get { return qqUser; }
            set
            {
                if (qqUser != value)
                {
                    qqUser = value;
                 //   lblChatName.Tag = lblChatName.Text = string.IsNullOrEmpty(qqUser.DisplayName) ? qqUser.NicName : qqUser.DisplayName;
                    // lblChatQm.Text = qqUser.PersonalMsg;
                    //    pnlImgTx.BackgroundImage = qqUser.HeadImage;
                    //  imgQQShow.Image = qqUser.QQShow;
                }
            }
        }


        string _displayName;
        string _userName;
        string _myName = "测试u测";// GlobalVariable.LoginUserInfo.DisplayName;
        #endregion

        #region 无参构造
        public MyChatForm(string displayName, string userName)
        {
            InitializeComponent();
            //加载表情到文本框
            this.chatBoxSend.Initialize(GlobalResourceManager.EmotionDictionary);
            this.chatBox_history.Initialize(GlobalResourceManager.EmotionDictionary);
            _displayName = displayName;
            _userName = userName;
          //  lblChatName.Text = "与（" + _displayName + "）的聊天";
        }
        #endregion

        #region 带参构造
        public MyChatForm(ChatListSubItem QQUser)
        {
            InitializeComponent();
            this.QQUser = QQUser;
            //加载表情到文本框
            this.chatBoxSend.Initialize(GlobalResourceManager.EmotionDictionary);
            this.chatBox_history.Initialize(GlobalResourceManager.EmotionDictionary);
        }
        #endregion

        #region 窗体重绘时
        private void ChatForm_Paint(object sender, PaintEventArgs e)
        {
          //  Graphics g = e.Graphics;
          // g.SmoothingMode = SmoothingMode.HighQuality;
            ////全屏蒙浓遮罩层
            //g.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), new Rectangle(0, 0, this.Width, this.chatBox_history.Top));
            //g.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), new Rectangle(0, this.chatBox_history.Top, this.chatBox_history.Width + this.chatBox_history.Left, this.Height - this.chatBox_history.Top));

            //线条
            // g.DrawLine(new Pen(Color.FromArgb(180, 198, 221)), new Point(0, this.chatBox_history.Top - 1), new Point(chatBox_history.Right, this.chatBox_history.Top - 1));
            //   g.DrawLine(new Pen(Color.FromArgb(180, 198, 221)), new Point(0, this.chatBox_history.Bottom), new Point(chatBox_history.Right, this.chatBox_history.Bottom));
        }
        #endregion

        #region 发送信息
        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatBoxContent content = this.chatBoxSend.GetContent();
            //发送内容为空时，不做响应
            if (content.IsEmpty())
            {
                return;
            }
            SendMessage(content.Text);
            AddMessageToHistory(content);
            //ChatBoxContent content = this.chatBoxSend.GetContent();
            ////发送内容为空时，不做响应
            //if (content.IsEmpty())
            //{
            //    return;
            //}
            //this.AppendChatBoxContent("乔克斯", null, content, Color.SeaGreen, false);

            ////清空发送输入框
            //this.chatBoxSend.Text = string.Empty;
            //this.chatBoxSend.Focus();
        }


        private void SendMessage(string msg)
        {

            PrivateChatRequest request = new PrivateChatRequest();
            request.guid = Guid.NewGuid().ToString();
            request.msg = msg;
            request.receivename = _userName;
            request.sendname = GlobalVariable.LoginUserInfo.DisplayName;

            GlobalVariable.client.Send_PrivateChat(request);
            //   GlobalVariable.AddPrivateChatToChatList(_userName, GlobalVariable.LoginUserInfo.DisplayName, msg);


        }


        private void AddMessageToHistory(ChatBoxContent content)
        {

            var showTime = DateTime.Now.ToLongTimeString();
            this.chatBox_history.AppendRichText(string.Format("{0}  {1}\n", _myName, showTime),
                new Font(this.messageFont, FontStyle.Regular), Color.SeaGreen);

            content.Text = "    " + content.Text.Replace("\n", "\n    ");
            this.chatBox_history.AppendChatBoxContent(content);
            this.chatBox_history.AppendText("\n");
            this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
            this.chatBox_history.ScrollToCaret();

            //清空发送输入框
            this.chatBoxSend.Text = string.Empty;
            this.chatBoxSend.Focus();
        }

        #endregion

        #region 接收信息封装
        private void OnReceivedMsg(ChatBoxContent content, DateTime? originTime)
        {
           // this.AppendChatBoxContent(lblChatName.Tag == null ? "小黄鸡" : lblChatName.Tag.ToString(), originTime, content, Color.Blue, false);
        }

        public void AddReceivedMsg(PrivateChatRequest response)
        {
            ChatBoxContent content = new ChatBoxContent(response.msg, messageFont, Color.Black);
            var showTime = DateTime.Now.ToLongTimeString();
            this.chatBox_history.AppendRichText(string.Format("{0}  {1}\n", response.sendname, showTime),
                new Font(this.messageFont, FontStyle.Regular), Color.Blue);
            content.Text = "    " + content.Text.Replace("\n", "\n    ");
            this.chatBox_history.AppendChatBoxContent(content);
            this.chatBox_history.AppendText("\n");
            this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
            this.chatBox_history.ScrollToCaret();
        }
        #endregion

        #region 发送消息封装
        /// <summary>
        /// 发送信息文本到内容框
        /// </summary>
        /// <param name="userName">名字</param>
        /// <param name="originTime">时间</param>
        /// <param name="content">发送内容</param>
        /// <param name="color">字体颜色</param>
        /// <param name="followingWords">是否有用户名</param>
        private void AppendChatBoxContent(string userName, DateTime? originTime, ChatBoxContent content, Color color, bool followingWords)
        {
            this.AppendChatBoxContent(userName, originTime, content, color, followingWords, originTime != null);
        }

        /// <summary>
        /// 发送信息文本到内容框
        /// </summary>
        /// <param name="userName">名字</param>
        /// <param name="originTime">时间</param>
        /// <param name="content">发送内容</param>
        /// <param name="color">字体颜色</param>
        /// <param name="followingWords">是否有用户名</param>
        /// <param name="offlineMessage">是否在线消息</param>
        private void AppendChatBoxContent(string userName, DateTime? originTime, ChatBoxContent content, Color color, bool followingWords, bool offlineMessage)
        {
            if (!followingWords)
            {
                string showTime = DateTime.Now.ToLongTimeString();
                if (!offlineMessage && originTime != null)
                {
                    showTime = originTime.Value.ToString();
                }
                this.chatBox_history.AppendRichText(string.Format("{0}  {1}\n", userName, showTime), new Font(this.messageFont, FontStyle.Regular), color);
                if (originTime != null && offlineMessage)
                {
                    this.chatBox_history.AppendText(string.Format("    [{0} 离线消息] ", originTime.Value.ToString()));
                }
                else
                {
                    this.chatBox_history.AppendText("    ");
                }
            }
            else
            {
                this.chatBox_history.AppendText("   .");
            }

            this.chatBox_history.AppendChatBoxContent(content);
            this.chatBox_history.AppendText("\n");
            this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
            this.chatBox_history.ScrollToCaret();
        }

        /// <summary>
        /// 发送信息文本到内容框
        /// </summary>
        /// <param name="userName">名称</param>
        /// <param name="color">字体颜色</param>
        /// <param name="msg">信息</param>
        private void AppendMessage(string userName, Color color, string msg)
        {
            DateTime showTime = DateTime.Now;
            this.chatBox_history.AppendRichText(string.Format("{0}  {1}\n", userName, showTime.ToLongTimeString()), new Font(this.messageFont, FontStyle.Regular), color);
            this.chatBox_history.AppendText("    ");

            this.chatBox_history.AppendText(msg);
            this.chatBox_history.Select(this.chatBox_history.Text.Length, 0);
            this.chatBox_history.ScrollToCaret();
        }

        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="msg">信息</param>
        public void AppendSysMessage(string msg)
        {
            this.AppendMessage("系统", Color.Gray, msg);
            this.chatBox_history.AppendText("\n");
        }
        #endregion

        #region 退出当前聊天
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 请求小黄鸡回复
        /// <summary>
        /// 请求小黄鸡回复
        /// </summary>
        /// <param name="msg"></param>
        private void GoChat(string msg)
        {
            string s = string.Empty;
            try
            {
                //设置Post的Data值
                Dictionary<string, string> dr = new Dictionary<string, string>();
                dr.Add("para", msg);
                //请求回复-10秒超时
                HttpWebResponse hp = HttpHelper.CreatePostHttpResponse("http://www.xiaohuangji.com/ajax.php", dr, 10000, null, Encoding.UTF8, null);
                //输出文本
                StreamReader sr = new StreamReader(hp.GetResponseStream(), Encoding.UTF8);
                s = sr.ReadToEnd();
            }
            catch (Exception)
            {
                s = "AI智能回复挂了！现在时间是：" + DateTime.Now;
            }
            this.Invoke(new MethodInvoker(delegate
            {
                OnReceivedMsg(new ChatBoxContent(s, messageFont, Color.Black), null);
            }));
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

        #region 震动按钮事件
        private void toolZhenDong_Click(object sender, EventArgs e)
        {
            this.AppendMessage("乔克斯", Color.Green, "您发送了一个抖动提醒。\n");
            this.chatBoxSend.Focus();
            Vibration();
        }
        #endregion

        #region 震动方法
        //震动方法
        private void Vibration()
        {
            Point pOld = this.Location;//原来的位置
            int radius = 3;//半径
            for (int n = 0; n < 3; n++) //旋转圈数
            {
                //右半圆逆时针
                for (int i = -radius; i <= radius; i++)
                {
                    int x = Convert.ToInt32(Math.Sqrt(radius * radius - i * i));
                    int y = -i;

                    this.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
                //左半圆逆时针
                for (int j = radius; j >= -radius; j--)
                {
                    int x = -Convert.ToInt32(Math.Sqrt(radius * radius - j * j));
                    int y = -j;

                    this.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
            }
            //抖动完成，恢复原来位置
            this.Location = pOld;
        }
        #endregion

        #region 发送键更多选择 及 发送键更多选择菜单关闭时
        //发送键更多选择
        private void btnSendMenu_Click(object sender, EventArgs e)
        {
            //btnSendMenu.StopState = StopStates.Pressed;
            //  SendMenu.Show(btnSendMenu, new Point(0, btnSendMenu.Height + 5));
        }

        //发送键更多选择菜单关闭时
        private void SendMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            //  btnSendMenu.StopState = StopStates.NoStop;
            //  btnSendMenu.ControlState = ControlState.Normal;
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

        #region 自定义系统按钮事件
        private void ChatForm_SysBottomClick(object sender, SysButtonEventArgs e)
        {
            if (e.SysButton.Name == "SysSet")
            {
                Point l = PointToScreen(e.SysButton.Location);
                l.Y += e.SysButton.Size.Height + 1;
                SysMenu.Show(l);
            }
        }
        #endregion

        private void MyChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          //  this.DialogResult = DialogResult.Cancel;
        }

        private void Chanel_panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Chanel_panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (Chanel2_Info.Visible)
            {
                Chanel2_Info.Visible = false;
            }
            else
            {
                Chanel2_Info.Height = 1080;
                Chanel2_Info.Visible = true;
            }
        }

        private void chatBoxSend_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
