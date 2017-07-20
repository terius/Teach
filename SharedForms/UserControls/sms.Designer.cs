namespace SharedForms
{
    partial class sms
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSMS = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSMS
            // 
            this.txtSMS.BackColor = System.Drawing.Color.LightCoral;
            this.txtSMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSMS.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSMS.Location = new System.Drawing.Point(36, 17);
            this.txtSMS.Multiline = true;
            this.txtSMS.Name = "txtSMS";
            this.txtSMS.ReadOnly = true;
            this.txtSMS.Size = new System.Drawing.Size(100, 21);
            this.txtSMS.TabIndex = 0;
            // 
            // txtLink
            // 
            this.txtLink.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLink.Location = new System.Drawing.Point(182, 22);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(100, 23);
            this.txtLink.TabIndex = 1;
            this.txtLink.TabStop = true;
            this.txtLink.Text = "linkLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(311, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // sms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtSMS);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "sms";
            this.Size = new System.Drawing.Size(535, 70);
            this.Load += new System.EventHandler(this.sms_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.sms_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSMS;
        private System.Windows.Forms.LinkLabel txtLink;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
