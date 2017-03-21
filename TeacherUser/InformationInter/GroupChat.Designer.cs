namespace TeacherUser
{
    partial class GroupChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupChat));
            this.groupChatSendBtn = new System.Windows.Forms.Button();
            this.groupChatClearBtn = new System.Windows.Forms.Button();
            this.groupChatContentRtb = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupChatHistRtb = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupChatImageSendBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.startRecordBtn = new System.Windows.Forms.Button();
            this.stopRecordBtn = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupChatSendBtn
            // 
            this.groupChatSendBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupChatSendBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupChatSendBtn.Location = new System.Drawing.Point(109, 502);
            this.groupChatSendBtn.Name = "groupChatSendBtn";
            this.groupChatSendBtn.Size = new System.Drawing.Size(83, 35);
            this.groupChatSendBtn.TabIndex = 1;
            this.groupChatSendBtn.Text = "发送(&S)";
            this.groupChatSendBtn.UseVisualStyleBackColor = true;
            this.groupChatSendBtn.Click += new System.EventHandler(this.groupChatSendBtn_Click);
            // 
            // groupChatClearBtn
            // 
            this.groupChatClearBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupChatClearBtn.Location = new System.Drawing.Point(287, 502);
            this.groupChatClearBtn.Name = "groupChatClearBtn";
            this.groupChatClearBtn.Size = new System.Drawing.Size(83, 35);
            this.groupChatClearBtn.TabIndex = 2;
            this.groupChatClearBtn.Text = "清空(&Z)";
            this.groupChatClearBtn.UseVisualStyleBackColor = true;
            this.groupChatClearBtn.Click += new System.EventHandler(this.groupChatClear_Click);
            // 
            // groupChatContentRtb
            // 
            this.groupChatContentRtb.Location = new System.Drawing.Point(29, 20);
            this.groupChatContentRtb.Name = "groupChatContentRtb";
            this.groupChatContentRtb.Size = new System.Drawing.Size(490, 163);
            this.groupChatContentRtb.TabIndex = 3;
            this.groupChatContentRtb.Text = "";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(376, 504);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "关闭(&C)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.groupChatClose_Click);
            // 
            // groupChatHistRtb
            // 
            this.groupChatHistRtb.Location = new System.Drawing.Point(29, 19);
            this.groupChatHistRtb.Name = "groupChatHistRtb";
            this.groupChatHistRtb.Size = new System.Drawing.Size(490, 215);
            this.groupChatHistRtb.TabIndex = 5;
            this.groupChatHistRtb.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupChatHistRtb);
            this.groupBox1.Location = new System.Drawing.Point(27, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 240);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "聊天对话框";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupChatContentRtb);
            this.groupBox2.Location = new System.Drawing.Point(27, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 202);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "聊天输入框";
            // 
            // groupChatImageSendBtn
            // 
            this.groupChatImageSendBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupChatImageSendBtn.Location = new System.Drawing.Point(198, 503);
            this.groupChatImageSendBtn.Name = "groupChatImageSendBtn";
            this.groupChatImageSendBtn.Size = new System.Drawing.Size(83, 35);
            this.groupChatImageSendBtn.TabIndex = 8;
            this.groupChatImageSendBtn.Text = "发送图片";
            this.groupChatImageSendBtn.UseVisualStyleBackColor = true;
            this.groupChatImageSendBtn.Click += new System.EventHandler(this.groupChatImageSendBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // startRecordBtn
            // 
            this.startRecordBtn.Location = new System.Drawing.Point(602, 157);
            this.startRecordBtn.Name = "startRecordBtn";
            this.startRecordBtn.Size = new System.Drawing.Size(75, 23);
            this.startRecordBtn.TabIndex = 9;
            this.startRecordBtn.Text = "开始录音";
            this.startRecordBtn.UseVisualStyleBackColor = true;
            this.startRecordBtn.Click += new System.EventHandler(this.startRecordBtn_Click);
            // 
            // stopRecordBtn
            // 
            this.stopRecordBtn.Location = new System.Drawing.Point(747, 157);
            this.stopRecordBtn.Name = "stopRecordBtn";
            this.stopRecordBtn.Size = new System.Drawing.Size(75, 23);
            this.stopRecordBtn.TabIndex = 10;
            this.stopRecordBtn.Text = "停止录音";
            this.stopRecordBtn.UseVisualStyleBackColor = true;
            this.stopRecordBtn.Click += new System.EventHandler(this.stopRecordBtn_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(602, 43);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(220, 45);
            this.axWindowsMediaPlayer1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GroupChat
            // 
            this.AcceptButton = this.groupChatSendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.stopRecordBtn);
            this.Controls.Add(this.startRecordBtn);
            this.Controls.Add(this.groupChatImageSendBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupChatClearBtn);
            this.Controls.Add(this.groupChatSendBtn);
            this.Name = "GroupChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "群聊";
            this.Load += new System.EventHandler(this.GroupChat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button groupChatSendBtn;
        private System.Windows.Forms.Button groupChatClearBtn;
        private System.Windows.Forms.RichTextBox groupChatContentRtb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox groupChatHistRtb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button groupChatImageSendBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button startRecordBtn;
        private System.Windows.Forms.Button stopRecordBtn;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button button1;
    }
}