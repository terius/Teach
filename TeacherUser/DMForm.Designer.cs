namespace TeacherUser
{
    partial class DMForm
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
            this.components = new System.ComponentModel.Container();
            this.dmButtonCloseLight1 = new DMSkin.Controls.DMButtonCloseLight();
            this.dmButtonMinLight1 = new DMSkin.Controls.DMButtonMinLight();
            this.dmButtonMax1 = new DMSkin.Controls.DMButtonMax();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dmButtonCloseLight1
            // 
            this.dmButtonCloseLight1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dmButtonCloseLight1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonCloseLight1.Location = new System.Drawing.Point(947, 0);
            this.dmButtonCloseLight1.Margin = new System.Windows.Forms.Padding(0);
            this.dmButtonCloseLight1.MaximumSize = new System.Drawing.Size(30, 27);
            this.dmButtonCloseLight1.MinimumSize = new System.Drawing.Size(30, 27);
            this.dmButtonCloseLight1.Name = "dmButtonCloseLight1";
            this.dmButtonCloseLight1.Size = new System.Drawing.Size(30, 27);
            this.dmButtonCloseLight1.TabIndex = 0;
            this.dmButtonCloseLight1.Click += new System.EventHandler(this.dmButtonCloseLight1_Click);
            // 
            // dmButtonMinLight1
            // 
            this.dmButtonMinLight1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dmButtonMinLight1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonMinLight1.Location = new System.Drawing.Point(887, 0);
            this.dmButtonMinLight1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dmButtonMinLight1.Name = "dmButtonMinLight1";
            this.dmButtonMinLight1.Size = new System.Drawing.Size(30, 27);
            this.dmButtonMinLight1.TabIndex = 1;
            this.dmButtonMinLight1.Click += new System.EventHandler(this.dmButtonMinLight1_Click);
            // 
            // dmButtonMax1
            // 
            this.dmButtonMax1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dmButtonMax1.BackColor = System.Drawing.Color.Transparent;
            this.dmButtonMax1.Location = new System.Drawing.Point(917, 0);
            this.dmButtonMax1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dmButtonMax1.Name = "dmButtonMax1";
            this.dmButtonMax1.Size = new System.Drawing.Size(30, 27);
            this.dmButtonMax1.TabIndex = 3;
            this.dmButtonMax1.Click += new System.EventHandler(this.dmButtonMax1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dmButtonMinLight1);
            this.panel1.Controls.Add(this.dmButtonCloseLight1);
            this.panel1.Controls.Add(this.dmButtonMax1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 39);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // DMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(985, 581);
            this.Controls.Add(this.panel1);
            this.DM_CanMove = false;
            this.DM_Radius = 4;
            this.Name = "DMForm";
            this.Text = "DMForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DMSkin.Controls.DMButtonCloseLight dmButtonCloseLight1;
        private DMSkin.Controls.DMButtonMinLight dmButtonMinLight1;
        private DMSkin.Controls.DMButtonMax dmButtonMax1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
    }
}