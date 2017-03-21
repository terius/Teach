namespace TeacherUser
{
    partial class PopformForScreenCap
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
            this.startScreenCapBtn = new System.Windows.Forms.Button();
            this.stopScreenCapBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.desktopChbox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.soundChBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectPathbt = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // startScreenCapBtn
            // 
            this.startScreenCapBtn.Location = new System.Drawing.Point(57, 297);
            this.startScreenCapBtn.Name = "startScreenCapBtn";
            this.startScreenCapBtn.Size = new System.Drawing.Size(75, 23);
            this.startScreenCapBtn.TabIndex = 0;
            this.startScreenCapBtn.Text = "开始";
            this.startScreenCapBtn.UseVisualStyleBackColor = true;
            this.startScreenCapBtn.Click += new System.EventHandler(this.startScreenCapBtn_Click);
            // 
            // stopScreenCapBtn
            // 
            this.stopScreenCapBtn.Location = new System.Drawing.Point(545, 297);
            this.stopScreenCapBtn.Name = "stopScreenCapBtn";
            this.stopScreenCapBtn.Size = new System.Drawing.Size(75, 23);
            this.stopScreenCapBtn.TabIndex = 1;
            this.stopScreenCapBtn.Text = "停止";
            this.stopScreenCapBtn.UseVisualStyleBackColor = true;
            this.stopScreenCapBtn.Click += new System.EventHandler(this.stopScreenCapBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.desktopChbox);
            this.groupBox1.Location = new System.Drawing.Point(57, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像";
            // 
            // desktopChbox
            // 
            this.desktopChbox.AutoSize = true;
            this.desktopChbox.Checked = true;
            this.desktopChbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.desktopChbox.Enabled = false;
            this.desktopChbox.Location = new System.Drawing.Point(68, 20);
            this.desktopChbox.Name = "desktopChbox";
            this.desktopChbox.Size = new System.Drawing.Size(48, 16);
            this.desktopChbox.TabIndex = 0;
            this.desktopChbox.Text = "桌面";
            this.desktopChbox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.soundChBox);
            this.groupBox2.Location = new System.Drawing.Point(57, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "声源";
            // 
            // soundChBox
            // 
            this.soundChBox.AutoSize = true;
            this.soundChBox.Enabled = false;
            this.soundChBox.Location = new System.Drawing.Point(68, 21);
            this.soundChBox.Name = "soundChBox";
            this.soundChBox.Size = new System.Drawing.Size(60, 16);
            this.soundChBox.TabIndex = 0;
            this.soundChBox.Text = "麦克风";
            this.soundChBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.selectPathbt);
            this.groupBox3.Location = new System.Drawing.Point(57, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 55);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件保存路径";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(437, 21);
            this.textBox1.TabIndex = 1;
            // 
            // selectPathbt
            // 
            this.selectPathbt.Location = new System.Drawing.Point(23, 20);
            this.selectPathbt.Name = "selectPathbt";
            this.selectPathbt.Size = new System.Drawing.Size(75, 23);
            this.selectPathbt.TabIndex = 0;
            this.selectPathbt.Text = "选择";
            this.selectPathbt.UseVisualStyleBackColor = true;
            this.selectPathbt.Click += new System.EventHandler(this.selectPathbt_Click);
            // 
            // PopformForScreenCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 346);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stopScreenCapBtn);
            this.Controls.Add(this.startScreenCapBtn);
            this.Name = "PopformForScreenCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopformForScreenCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopformForScreenCap_FormClosing);
            this.Load += new System.EventHandler(this.PopformForScreenCap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startScreenCapBtn;
        private System.Windows.Forms.Button stopScreenCapBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox desktopChbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox soundChBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button selectPathbt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}