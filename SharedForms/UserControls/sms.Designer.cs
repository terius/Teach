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
            this.SuspendLayout();
            // 
            // txtSMS
            // 
            this.txtSMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSMS.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSMS.Location = new System.Drawing.Point(36, 17);
            this.txtSMS.Multiline = true;
            this.txtSMS.Name = "txtSMS";
            this.txtSMS.ReadOnly = true;
            this.txtSMS.Size = new System.Drawing.Size(100, 21);
            this.txtSMS.TabIndex = 0;
            // 
            // sms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtSMS);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "sms";
            this.Size = new System.Drawing.Size(535, 70);
            this.Load += new System.EventHandler(this.sms_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.sms_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSMS;
    }
}
