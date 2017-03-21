namespace TeacherUser.InformationInter
{
    partial class PrivateChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrivateHistRtb = new System.Windows.Forms.RichTextBox();
            this.PrivateSendBtn = new System.Windows.Forms.Button();
            this.PrivateClearBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.videoChat = new System.Windows.Forms.Button();
            this.reliefPrivateChatBtn = new System.Windows.Forms.Button();
            this.PrivateContentRtb = new System.Windows.Forms.RichTextBox();
            this.privateChatImageSendBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrivateHistRtb
            // 
            this.PrivateHistRtb.Location = new System.Drawing.Point(15, 12);
            this.PrivateHistRtb.Name = "PrivateHistRtb";
            this.PrivateHistRtb.Size = new System.Drawing.Size(457, 192);
            this.PrivateHistRtb.TabIndex = 0;
            this.PrivateHistRtb.Text = "";
            // 
            // PrivateSendBtn
            // 
            this.PrivateSendBtn.Location = new System.Drawing.Point(24, 173);
            this.PrivateSendBtn.Name = "PrivateSendBtn";
            this.PrivateSendBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivateSendBtn.TabIndex = 1;
            this.PrivateSendBtn.Text = "发送文字";
            this.PrivateSendBtn.UseVisualStyleBackColor = true;
            this.PrivateSendBtn.Click += new System.EventHandler(this.PrivateSendBtn_Click);
            // 
            // PrivateClearBtn
            // 
            this.PrivateClearBtn.Location = new System.Drawing.Point(333, 214);
            this.PrivateClearBtn.Name = "PrivateClearBtn";
            this.PrivateClearBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivateClearBtn.TabIndex = 2;
            this.PrivateClearBtn.Text = "清空";
            this.PrivateClearBtn.UseVisualStyleBackColor = true;
            this.PrivateClearBtn.Click += new System.EventHandler(this.PrivateClearBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(67, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PrivateHistRtb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.privateChatImageSendBtn);
            this.splitContainer1.Panel2.Controls.Add(this.videoChat);
            this.splitContainer1.Panel2.Controls.Add(this.reliefPrivateChatBtn);
            this.splitContainer1.Panel2.Controls.Add(this.PrivateContentRtb);
            this.splitContainer1.Panel2.Controls.Add(this.PrivateSendBtn);
            this.splitContainer1.Panel2.Controls.Add(this.PrivateClearBtn);
          //  this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(489, 451);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 5;
            // 
            // videoChat
            // 
            this.videoChat.Location = new System.Drawing.Point(414, 214);
            this.videoChat.Name = "videoChat";
            this.videoChat.Size = new System.Drawing.Size(75, 23);
            this.videoChat.TabIndex = 7;
            this.videoChat.Text = "视频聊天";
            this.videoChat.UseVisualStyleBackColor = true;
            this.videoChat.Click += new System.EventHandler(this.videoChat_Click);
            // 
            // reliefPrivateChatBtn
            // 
            this.reliefPrivateChatBtn.Location = new System.Drawing.Point(252, 214);
            this.reliefPrivateChatBtn.Name = "reliefPrivateChatBtn";
            this.reliefPrivateChatBtn.Size = new System.Drawing.Size(75, 23);
            this.reliefPrivateChatBtn.TabIndex = 6;
            this.reliefPrivateChatBtn.Text = "解除禁止";
            this.reliefPrivateChatBtn.UseVisualStyleBackColor = true;
            this.reliefPrivateChatBtn.Click += new System.EventHandler(this.reliefPrivateChatBtn_Click);
            // 
            // PrivateContentRtb
            // 
            this.PrivateContentRtb.Location = new System.Drawing.Point(15, 30);
            this.PrivateContentRtb.Name = "PrivateContentRtb";
            this.PrivateContentRtb.Size = new System.Drawing.Size(457, 114);
            this.PrivateContentRtb.TabIndex = 5;
            this.PrivateContentRtb.Text = "";
            // 
            // privateChatImageSendBtn
            // 
            this.privateChatImageSendBtn.Location = new System.Drawing.Point(137, 173);
            this.privateChatImageSendBtn.Name = "privateChatImageSendBtn";
            this.privateChatImageSendBtn.Size = new System.Drawing.Size(75, 23);
            this.privateChatImageSendBtn.TabIndex = 8;
            this.privateChatImageSendBtn.Text = "发送图片";
            this.privateChatImageSendBtn.UseVisualStyleBackColor = true;
            this.privateChatImageSendBtn.Click += new System.EventHandler(this.privateChatImageSend_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PrivateChat
            // 
            this.AcceptButton = this.PrivateSendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 540);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PrivateChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrivateChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrivateChat_FormClosing);
            this.Load += new System.EventHandler(this.PrivateChat_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox PrivateHistRtb;
        private System.Windows.Forms.Button PrivateSendBtn;
        private System.Windows.Forms.Button PrivateClearBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox PrivateContentRtb;
        private System.Windows.Forms.Button reliefPrivateChatBtn;
        private System.Windows.Forms.Button videoChat;
        private System.Windows.Forms.Button privateChatImageSendBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}