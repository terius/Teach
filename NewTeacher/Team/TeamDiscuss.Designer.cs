namespace NewTeacher
{
    partial class TeamDiscuss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamDiscuss));
            this.onLineListView = new System.Windows.Forms.ListView();
            this.MenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.teamMemList = new System.Windows.Forms.ListView();
            this.cboxTeam = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtCreate = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.memberMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.memDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cboxTeam2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddStudent = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.memberMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // onLineListView
            // 
            this.onLineListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.onLineListView.CheckBoxes = true;
            this.onLineListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onLineListView.LargeImageList = this.MenuImageList;
            this.onLineListView.Location = new System.Drawing.Point(15, 22);
            this.onLineListView.Margin = new System.Windows.Forms.Padding(2);
            this.onLineListView.Name = "onLineListView";
            this.onLineListView.Size = new System.Drawing.Size(209, 469);
            this.onLineListView.SmallImageList = this.MenuImageList;
            this.onLineListView.TabIndex = 0;
            this.onLineListView.UseCompatibleStateImageBehavior = false;
            this.onLineListView.View = System.Windows.Forms.View.List;
            // 
            // MenuImageList
            // 
            this.MenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MenuImageList.ImageStream")));
            this.MenuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MenuImageList.Images.SetKeyName(0, "学生.png");
            this.MenuImageList.Images.SetKeyName(1, "老师.png");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.onLineListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15, 8, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(226, 493);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线学生";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.teamMemList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(429, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15, 8, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(405, 493);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "群组成员";
            // 
            // teamMemList
            // 
            this.teamMemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.teamMemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamMemList.LargeImageList = this.MenuImageList;
            this.teamMemList.Location = new System.Drawing.Point(15, 22);
            this.teamMemList.Margin = new System.Windows.Forms.Padding(2);
            this.teamMemList.Name = "teamMemList";
            this.teamMemList.Size = new System.Drawing.Size(388, 469);
            this.teamMemList.SmallImageList = this.MenuImageList;
            this.teamMemList.TabIndex = 0;
            this.teamMemList.UseCompatibleStateImageBehavior = false;
            this.teamMemList.View = System.Windows.Forms.View.List;
            this.teamMemList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.teamMemList_MouseDown);
            // 
            // cboxTeam
            // 
            this.cboxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTeam.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxTeam.FormattingEnabled = true;
            this.cboxTeam.Location = new System.Drawing.Point(13, 19);
            this.cboxTeam.Margin = new System.Windows.Forms.Padding(2);
            this.cboxTeam.Name = "cboxTeam";
            this.cboxTeam.Size = new System.Drawing.Size(170, 24);
            this.cboxTeam.TabIndex = 0;
            this.cboxTeam.SelectedIndexChanged += new System.EventHandler(this.cboxTeam_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.cboxTeam);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 77);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(831, 419);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "编辑删除群组";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(200, 45);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 22);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除选择的分组";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(200, 19);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 22);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改选择的分组名";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(122, 26);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(61, 22);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "创建";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtCreate
            // 
            this.txtCreate.Location = new System.Drawing.Point(4, 26);
            this.txtCreate.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreate.Name = "txtCreate";
            this.txtCreate.Size = new System.Drawing.Size(107, 21);
            this.txtCreate.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCreate);
            this.groupBox4.Controls.Add(this.btnCreate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(831, 74);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "创建群组";
            // 
            // memberMenu
            // 
            this.memberMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.memberMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memDel});
            this.memberMenu.Name = "memberMenu";
            this.memberMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // memDel
            // 
            this.memDel.Name = "memDel";
            this.memDel.Size = new System.Drawing.Size(124, 22);
            this.memDel.Text = "删除成员";
            this.memDel.Click += new System.EventHandler(this.memDel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(845, 525);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(837, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "群组";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(837, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "群组成员";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddStudent);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.cboxTeam2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(229, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 493);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "选择群组成员";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(3, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存群组信息";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // cboxTeam2
            // 
            this.cboxTeam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTeam2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxTeam2.FormattingEnabled = true;
            this.cboxTeam2.Location = new System.Drawing.Point(6, 47);
            this.cboxTeam2.Margin = new System.Windows.Forms.Padding(2);
            this.cboxTeam2.Name = "cboxTeam2";
            this.cboxTeam2.Size = new System.Drawing.Size(189, 24);
            this.cboxTeam2.TabIndex = 6;
            this.cboxTeam2.SelectedIndexChanged += new System.EventHandler(this.cboxTeam2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择群组";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.Appearance.Options.UseFont = true;
            this.btnAddStudent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStudent.Image")));
            this.btnAddStudent.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddStudent.Location = new System.Drawing.Point(6, 180);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(153, 36);
            this.btnAddStudent.TabIndex = 9;
            this.btnAddStudent.Text = "选择勾选的学生";
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // TeamDiscuss
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 525);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TeamDiscuss";
            this.ShowInTaskbar = false;
            this.Text = "建立分组";
            this.Load += new System.EventHandler(this.TeamDiscuss_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.memberMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView onLineListView;
        private System.Windows.Forms.ImageList MenuImageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView teamMemList;
        private System.Windows.Forms.ComboBox cboxTeam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtCreate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip memberMenu;
        private System.Windows.Forms.ToolStripMenuItem memDel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboxTeam2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAddStudent;
    }
}