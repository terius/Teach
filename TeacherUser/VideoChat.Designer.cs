namespace TeacherUser
{
    partial class VideoChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoChat));
            this.launchVideoCallBtn = new System.Windows.Forms.Button();
            this.stopVideoCallBtn = new System.Windows.Forms.Button();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.statusLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.SuspendLayout();
            // 
            // launchVideoCallBtn
            // 
            this.launchVideoCallBtn.Location = new System.Drawing.Point(81, 385);
            this.launchVideoCallBtn.Name = "launchVideoCallBtn";
            this.launchVideoCallBtn.Size = new System.Drawing.Size(75, 23);
            this.launchVideoCallBtn.TabIndex = 0;
            this.launchVideoCallBtn.Text = "发起视频通话";
            this.launchVideoCallBtn.UseVisualStyleBackColor = true;
            this.launchVideoCallBtn.Click += new System.EventHandler(this.launchVideoCallBtn_Click);
            // 
            // stopVideoCallBtn
            // 
            this.stopVideoCallBtn.Location = new System.Drawing.Point(366, 385);
            this.stopVideoCallBtn.Name = "stopVideoCallBtn";
            this.stopVideoCallBtn.Size = new System.Drawing.Size(75, 23);
            this.stopVideoCallBtn.TabIndex = 1;
            this.stopVideoCallBtn.Text = "挂断";
            this.stopVideoCallBtn.UseVisualStyleBackColor = true;
            this.stopVideoCallBtn.Click += new System.EventHandler(this.stopVideoCallBtn_Click);
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(33, 28);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(444, 289);
            this.axVLCPlugin21.TabIndex = 2;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(6, 423);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 12);
            this.statusLbl.TabIndex = 3;
            // 
            // VideoChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 440);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.axVLCPlugin21);
            this.Controls.Add(this.stopVideoCallBtn);
            this.Controls.Add(this.launchVideoCallBtn);
            this.Name = "VideoChat";
            this.Text = "VideoChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoChat_FormClosing);
            this.Load += new System.EventHandler(this.VideoChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchVideoCallBtn;
        private System.Windows.Forms.Button stopVideoCallBtn;
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.Label statusLbl;
    }
}