namespace TeacherUser
{
    partial class TeamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TeamViewTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "team.PNG");
            this.imageList1.Images.SetKeyName(1, "computer.PNG");
            this.imageList1.Images.SetKeyName(2, "phone.PNG");
            this.imageList1.Images.SetKeyName(3, "pingban.PNG");
            // 
            // TeamViewTree
            // 
            this.TeamViewTree.Location = new System.Drawing.Point(80, 25);
            this.TeamViewTree.Name = "TeamViewTree";
            this.TeamViewTree.Size = new System.Drawing.Size(218, 443);
            this.TeamViewTree.TabIndex = 0;
            // 
            // TeamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 500);
            this.Controls.Add(this.TeamViewTree);
            this.Name = "TeamView";
            this.Text = "TeamView";
            this.Load += new System.EventHandler(this.TeamView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView TeamViewTree;
    }
}