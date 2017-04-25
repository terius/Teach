namespace StudentUser
{
    partial class UserMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            this.btnLockScreen = new System.Windows.Forms.Button();
            this.btnStopLockScreen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tuopan = new System.Windows.Forms.NotifyIcon(this.components);
            this.MinMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.mSignIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mChat = new System.Windows.Forms.ToolStripMenuItem();
            this.mHandUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mFileShare = new System.Windows.Forms.ToolStripMenuItem();
            this.mLetter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mCloseForm = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MinMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLockScreen
            // 
            this.btnLockScreen.Location = new System.Drawing.Point(3, 3);
            this.btnLockScreen.Name = "btnLockScreen";
            this.btnLockScreen.Size = new System.Drawing.Size(75, 23);
            this.btnLockScreen.TabIndex = 0;
            this.btnLockScreen.Text = "显示黑屏";
            this.btnLockScreen.UseVisualStyleBackColor = true;
            this.btnLockScreen.Click += new System.EventHandler(this.btnLockScreen_Click);
            // 
            // btnStopLockScreen
            // 
            this.btnStopLockScreen.Location = new System.Drawing.Point(3, 32);
            this.btnStopLockScreen.Name = "btnStopLockScreen";
            this.btnStopLockScreen.Size = new System.Drawing.Size(75, 23);
            this.btnStopLockScreen.TabIndex = 1;
            this.btnStopLockScreen.Text = "关闭黑屏";
            this.btnStopLockScreen.UseVisualStyleBackColor = true;
            this.btnStopLockScreen.Click += new System.EventHandler(this.btnStopLockScreen_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLockScreen);
            this.panel1.Controls.Add(this.btnStopLockScreen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 63);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 421);
            this.panel2.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(752, 421);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tuopan
            // 
            this.tuopan.ContextMenuStrip = this.MinMenu;
            this.tuopan.Icon = ((System.Drawing.Icon)(resources.GetObject("tuopan.Icon")));
            this.tuopan.Visible = true;
            // 
            // MinMenu
            // 
            this.MinMenu.Arrow = System.Drawing.Color.Black;
            this.MinMenu.Back = System.Drawing.Color.White;
            this.MinMenu.BackRadius = 4;
            this.MinMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.MinMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MinMenu.Fore = System.Drawing.Color.Black;
            this.MinMenu.HoverFore = System.Drawing.Color.White;
            this.MinMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MinMenu.ItemAnamorphosis = true;
            this.MinMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MinMenu.ItemBorderShow = true;
            this.MinMenu.ItemHover = System.Drawing.Color.DeepSkyBlue;
            this.MinMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MinMenu.ItemRadius = 4;
            this.MinMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.MinMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSignIn,
            this.mChat,
            this.mHandUp,
            this.mFileShare,
            this.mLetter,
            this.toolStripSeparator1,
            this.mCloseForm});
            this.MinMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MinMenu.Name = "MinMenu";
            this.MinMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.MinMenu.Size = new System.Drawing.Size(129, 166);
            this.MinMenu.SkinAllColor = true;
            this.MinMenu.TitleAnamorphosis = true;
            this.MinMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.MinMenu.TitleRadius = 4;
            this.MinMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // mSignIn
            // 
            this.mSignIn.Image = ((System.Drawing.Image)(resources.GetObject("mSignIn.Image")));
            this.mSignIn.Name = "mSignIn";
            this.mSignIn.Size = new System.Drawing.Size(128, 26);
            this.mSignIn.Text = "签到";
            this.mSignIn.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // mChat
            // 
            this.mChat.Image = ((System.Drawing.Image)(resources.GetObject("mChat.Image")));
            this.mChat.Name = "mChat";
            this.mChat.Size = new System.Drawing.Size(128, 26);
            this.mChat.Text = "聊天";
            this.mChat.Click += new System.EventHandler(this.mChat_Click);
            // 
            // mHandUp
            // 
            this.mHandUp.Image = ((System.Drawing.Image)(resources.GetObject("mHandUp.Image")));
            this.mHandUp.Name = "mHandUp";
            this.mHandUp.Size = new System.Drawing.Size(128, 26);
            this.mHandUp.Text = "举手";
            this.mHandUp.Click += new System.EventHandler(this.mHandUp_Click);
            // 
            // mFileShare
            // 
            this.mFileShare.Image = ((System.Drawing.Image)(resources.GetObject("mFileShare.Image")));
            this.mFileShare.Name = "mFileShare";
            this.mFileShare.Size = new System.Drawing.Size(128, 26);
            this.mFileShare.Text = "文件共享";
            this.mFileShare.Click += new System.EventHandler(this.mFileShare_Click);
            // 
            // mLetter
            // 
            this.mLetter.Image = ((System.Drawing.Image)(resources.GetObject("mLetter.Image")));
            this.mLetter.Name = "mLetter";
            this.mLetter.Size = new System.Drawing.Size(128, 26);
            this.mLetter.Text = "私信";
            this.mLetter.Click += new System.EventHandler(this.mLetter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // mCloseForm
            // 
            this.mCloseForm.Image = ((System.Drawing.Image)(resources.GetObject("mCloseForm.Image")));
            this.mCloseForm.Name = "mCloseForm";
            this.mCloseForm.Size = new System.Drawing.Size(128, 26);
            this.mCloseForm.Text = "退出";
            this.mCloseForm.Click += new System.EventHandler(this.mCloseForm_Click);
            // 
            // UserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(439, 406);
            this.Name = "UserMainForm";
            this.ShowInTaskbar = false;
            this.Text = "Student";
            this.Load += new System.EventHandler(this.UserMainForm_Load);
            this.Shown += new System.EventHandler(this.UserMainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MinMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLockScreen;
        private System.Windows.Forms.Button btnStopLockScreen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NotifyIcon tuopan;
        private CCWin.SkinControl.SkinContextMenuStrip MinMenu;
        private System.Windows.Forms.ToolStripMenuItem mSignIn;
        private System.Windows.Forms.ToolStripMenuItem mChat;
        private System.Windows.Forms.ToolStripMenuItem mHandUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mCloseForm;
        private System.Windows.Forms.ToolStripMenuItem mFileShare;
        private System.Windows.Forms.ToolStripMenuItem mLetter;
    }
}

