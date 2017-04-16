namespace TeacherUser.controls
{
    partial class ChatItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatItem));
            this.labName = new System.Windows.Forms.Label();
            this.cp2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cp2)).BeginInit();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labName.Location = new System.Drawing.Point(105, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(69, 20);
            this.labName.TabIndex = 4;
            this.labName.Text = "当前聊天";
            // 
            // cp2
            // 
            this.cp2.Image = ((System.Drawing.Image)(resources.GetObject("cp2.Image")));
            this.cp2.Location = new System.Drawing.Point(51, 10);
            this.cp2.Name = "cp2";
            this.cp2.Size = new System.Drawing.Size(32, 32);
            this.cp2.TabIndex = 3;
            this.cp2.TabStop = false;
            // 
            // ChatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labName);
            this.Controls.Add(this.cp2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ChatItem";
            this.Size = new System.Drawing.Size(515, 52);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChatItem_MouseClick);
            this.MouseEnter += new System.EventHandler(this.ChatItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ChatItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.cp2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.PictureBox cp2;
    }
}
