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
            this.btnLockScreen = new System.Windows.Forms.Button();
            this.btnStopLockScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLockScreen
            // 
            this.btnLockScreen.Location = new System.Drawing.Point(27, 13);
            this.btnLockScreen.Name = "btnLockScreen";
            this.btnLockScreen.Size = new System.Drawing.Size(75, 23);
            this.btnLockScreen.TabIndex = 0;
            this.btnLockScreen.Text = "显示黑屏";
            this.btnLockScreen.UseVisualStyleBackColor = true;
            this.btnLockScreen.Click += new System.EventHandler(this.btnLockScreen_Click);
            // 
            // btnStopLockScreen
            // 
            this.btnStopLockScreen.Location = new System.Drawing.Point(27, 42);
            this.btnStopLockScreen.Name = "btnStopLockScreen";
            this.btnStopLockScreen.Size = new System.Drawing.Size(75, 23);
            this.btnStopLockScreen.TabIndex = 1;
            this.btnStopLockScreen.Text = "关闭黑屏";
            this.btnStopLockScreen.UseVisualStyleBackColor = true;
            this.btnStopLockScreen.Click += new System.EventHandler(this.btnStopLockScreen_Click);
            // 
            // UserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 402);
            this.Controls.Add(this.btnStopLockScreen);
            this.Controls.Add(this.btnLockScreen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserMainForm";
            this.Text = "Student";
            this.Load += new System.EventHandler(this.UserMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLockScreen;
        private System.Windows.Forms.Button btnStopLockScreen;
    }
}

