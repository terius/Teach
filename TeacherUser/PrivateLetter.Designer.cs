namespace TeacherUser
{
    partial class PrivateLetter
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
            this.contentTb = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.contentLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contentTb
            // 
            this.contentTb.Location = new System.Drawing.Point(12, 31);
            this.contentTb.Multiline = true;
            this.contentTb.Name = "contentTb";
            this.contentTb.ReadOnly = true;
            this.contentTb.Size = new System.Drawing.Size(260, 46);
            this.contentTb.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(55, 208);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "私聊";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(196, 208);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 12);
            this.linkLabel2.TabIndex = 2;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "关闭";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // contentLb
            // 
            this.contentLb.AutoSize = true;
            this.contentLb.Location = new System.Drawing.Point(12, 99);
            this.contentLb.Name = "contentLb";
            this.contentLb.Size = new System.Drawing.Size(41, 12);
            this.contentLb.TabIndex = 3;
            this.contentLb.Text = "label1";
            // 
            // PrivateLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 237);
            this.Controls.Add(this.contentLb);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.contentTb);
            this.Name = "PrivateLetter";
            this.Text = "PrivateLetter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrivateLetter_FormClosing);
            this.Load += new System.EventHandler(this.PrivateLetter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentTb;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label contentLb;
    }
}