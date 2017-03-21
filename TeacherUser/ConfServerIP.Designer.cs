namespace TeacherUser
{
    partial class ConfServerIP
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
            this.ServerIP_tb = new System.Windows.Forms.TextBox();
            this.ServerIP_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerIP_tb
            // 
            this.ServerIP_tb.Location = new System.Drawing.Point(38, 34);
            this.ServerIP_tb.Name = "ServerIP_tb";
            this.ServerIP_tb.Size = new System.Drawing.Size(226, 21);
            this.ServerIP_tb.TabIndex = 0;
            // 
            // ServerIP_btn
            // 
            this.ServerIP_btn.Location = new System.Drawing.Point(286, 34);
            this.ServerIP_btn.Name = "ServerIP_btn";
            this.ServerIP_btn.Size = new System.Drawing.Size(75, 23);
            this.ServerIP_btn.TabIndex = 1;
            this.ServerIP_btn.Text = "确定";
            this.ServerIP_btn.UseVisualStyleBackColor = true;
            this.ServerIP_btn.Click += new System.EventHandler(this.ServerIP_btn_Click);
            // 
            // ConfServerIP
            // 
            this.AcceptButton = this.ServerIP_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 101);
            this.Controls.Add(this.ServerIP_btn);
            this.Controls.Add(this.ServerIP_tb);
            this.Name = "ConfServerIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请重新填写服务器IP！";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerIP_tb;
        private System.Windows.Forms.Button ServerIP_btn;
    }
}