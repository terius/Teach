namespace NewTeacher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.menuExportSign = new DevExpress.XtraBars.BarButtonItem();
            this.menuClassNamed = new DevExpress.XtraBars.BarButtonItem();
            this.menuGroupChat = new DevExpress.XtraBars.BarButtonItem();
            this.menuTeamCreate = new DevExpress.XtraBars.BarButtonItem();
            this.menuViewTeam = new DevExpress.XtraBars.BarButtonItem();
            this.menuSilence = new DevExpress.XtraBars.BarButtonItem();
            this.menuRomoteControl = new DevExpress.XtraBars.BarSubItem();
            this.menuDisableMK = new DevExpress.XtraBars.BarButtonItem();
            this.menuScreenShare = new DevExpress.XtraBars.BarButtonItem();
            this.menuStudentShow = new DevExpress.XtraBars.BarButtonItem();
            this.menuVideoLive = new DevExpress.XtraBars.BarButtonItem();
            this.menuFileShare = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lvOnline = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.UserListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.userList_privateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_lockScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_stopLockScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_permisson = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_P_forbidPrivateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_P_forbidGroupChat = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_P_allowPrivateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_P_allowGroupChat = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_studentShow = new System.Windows.Forms.ToolStripMenuItem();
            this.userList_stopStudentShow = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.UserListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AllowMdiChildButtons = false;
            this.ribbon.AllowMinimizeRibbon = false;
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.menuExportSign,
            this.menuClassNamed,
            this.menuGroupChat,
            this.menuTeamCreate,
            this.menuViewTeam,
            this.menuSilence,
            this.menuRomoteControl,
            this.menuDisableMK,
            this.menuScreenShare,
            this.menuStudentShow,
            this.menuVideoLive,
            this.menuFileShare});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1122, 125);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // menuExportSign
            // 
            this.menuExportSign.Caption = "导出签到";
            this.menuExportSign.Id = 1;
            this.menuExportSign.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("menuExportSign.ImageOptions.LargeImage")));
            this.menuExportSign.Name = "menuExportSign";
            // 
            // menuClassNamed
            // 
            this.menuClassNamed.Caption = "课堂点名";
            this.menuClassNamed.Id = 2;
            this.menuClassNamed.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.上课点名;
            this.menuClassNamed.Name = "menuClassNamed";
            // 
            // menuGroupChat
            // 
            this.menuGroupChat.Caption = "班级群聊";
            this.menuGroupChat.Id = 3;
            this.menuGroupChat.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.群聊;
            this.menuGroupChat.Name = "menuGroupChat";
            // 
            // menuTeamCreate
            // 
            this.menuTeamCreate.Caption = "分组讨论";
            this.menuTeamCreate.Id = 5;
            this.menuTeamCreate.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.分组;
            this.menuTeamCreate.Name = "menuTeamCreate";
            // 
            // menuViewTeam
            // 
            this.menuViewTeam.Caption = "查看分组";
            this.menuViewTeam.Id = 6;
            this.menuViewTeam.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.查看;
            this.menuViewTeam.Name = "menuViewTeam";
            // 
            // menuSilence
            // 
            this.menuSilence.Caption = "屏幕肃静";
            this.menuSilence.Id = 7;
            this.menuSilence.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.屏幕;
            this.menuSilence.Name = "menuSilence";
            // 
            // menuRomoteControl
            // 
            this.menuRomoteControl.Caption = "远程控制";
            this.menuRomoteControl.Id = 10;
            this.menuRomoteControl.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.远程控制;
            this.menuRomoteControl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.menuDisableMK, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.menuRomoteControl.Name = "menuRomoteControl";
            // 
            // menuDisableMK
            // 
            this.menuDisableMK.Caption = "禁止鼠标键盘";
            this.menuDisableMK.Id = 11;
            this.menuDisableMK.ImageOptions.Image = global::NewTeacher.Properties.Resources.禁用16;
            this.menuDisableMK.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.禁用;
            this.menuDisableMK.Name = "menuDisableMK";
            // 
            // menuScreenShare
            // 
            this.menuScreenShare.Caption = "屏幕广播";
            this.menuScreenShare.Id = 1;
            this.menuScreenShare.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.共享桌面;
            this.menuScreenShare.Name = "menuScreenShare";
            // 
            // menuStudentShow
            // 
            this.menuStudentShow.Caption = "学生演示";
            this.menuStudentShow.Id = 2;
            this.menuStudentShow.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.学生演示;
            this.menuStudentShow.Name = "menuStudentShow";
            // 
            // menuVideoLive
            // 
            this.menuVideoLive.Caption = "视频直播";
            this.menuVideoLive.Id = 3;
            this.menuVideoLive.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.视频直播;
            this.menuVideoLive.Name = "menuVideoLive";
            // 
            // menuFileShare
            // 
            this.menuFileShare.Caption = "文件分发";
            this.menuFileShare.Id = 4;
            this.menuFileShare.ImageOptions.LargeImage = global::NewTeacher.Properties.Resources.分发;
            this.menuFileShare.Name = "menuFileShare";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.menuExportSign);
            this.ribbonPageGroup1.ItemLinks.Add(this.menuClassNamed);
            this.ribbonPageGroup1.ItemLinks.Add(this.menuGroupChat);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "班级";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.menuTeamCreate);
            this.ribbonPageGroup2.ItemLinks.Add(this.menuViewTeam);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "分组";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.menuSilence);
            this.ribbonPageGroup3.ItemLinks.Add(this.menuRomoteControl);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "控制";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.menuScreenShare);
            this.ribbonPageGroup4.ItemLinks.Add(this.menuStudentShow);
            this.ribbonPageGroup4.ItemLinks.Add(this.menuVideoLive);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "演播室";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.menuFileShare);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "文件";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 125);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Panel1.Controls.Add(this.lvOnline);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "在线学生列表";
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1122, 474);
            this.splitContainerControl1.SplitterPosition = 195;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lvOnline
            // 
            this.lvOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOnline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCall});
            this.lvOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOnline.Location = new System.Drawing.Point(10, 38);
            this.lvOnline.Name = "lvOnline";
            this.lvOnline.Size = new System.Drawing.Size(181, 413);
            this.lvOnline.TabIndex = 1;
            this.lvOnline.UseCompatibleStateImageBehavior = false;
            this.lvOnline.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "姓名";
            this.colName.Width = 100;
            // 
            // colCall
            // 
            this.colCall.Text = "是否点名";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(10, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(181, 38);
            this.panelControl1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnRefresh.ImageUri.Uri = "Refresh;Size16x16";
            this.btnRefresh.Location = new System.Drawing.Point(5, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 26);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UserListMenu
            // 
            this.UserListMenu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.UserListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userList_privateChat,
            this.userList_lockScreen,
            this.userList_stopLockScreen,
            this.userList_permisson,
            this.userList_studentShow,
            this.userList_stopStudentShow});
            this.UserListMenu.Name = "contextMenuStrip1";
            this.UserListMenu.Size = new System.Drawing.Size(167, 160);
            // 
            // userList_privateChat
            // 
            this.userList_privateChat.Image = ((System.Drawing.Image)(resources.GetObject("userList_privateChat.Image")));
            this.userList_privateChat.Name = "userList_privateChat";
            this.userList_privateChat.Size = new System.Drawing.Size(166, 26);
            this.userList_privateChat.Text = "私聊";
            // 
            // userList_lockScreen
            // 
            this.userList_lockScreen.Image = ((System.Drawing.Image)(resources.GetObject("userList_lockScreen.Image")));
            this.userList_lockScreen.Name = "userList_lockScreen";
            this.userList_lockScreen.Size = new System.Drawing.Size(166, 26);
            this.userList_lockScreen.Text = "锁屏";
            // 
            // userList_stopLockScreen
            // 
            this.userList_stopLockScreen.Name = "userList_stopLockScreen";
            this.userList_stopLockScreen.Size = new System.Drawing.Size(166, 26);
            this.userList_stopLockScreen.Text = "解锁";
            // 
            // userList_permisson
            // 
            this.userList_permisson.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userList_P_forbidPrivateChat,
            this.userList_P_forbidGroupChat,
            this.userList_P_allowPrivateChat,
            this.userList_P_allowGroupChat});
            this.userList_permisson.Name = "userList_permisson";
            this.userList_permisson.Size = new System.Drawing.Size(166, 26);
            this.userList_permisson.Text = "权限管理";
            // 
            // userList_P_forbidPrivateChat
            // 
            this.userList_P_forbidPrivateChat.Name = "userList_P_forbidPrivateChat";
            this.userList_P_forbidPrivateChat.Size = new System.Drawing.Size(134, 24);
            this.userList_P_forbidPrivateChat.Text = "禁止私聊";
            // 
            // userList_P_forbidGroupChat
            // 
            this.userList_P_forbidGroupChat.Name = "userList_P_forbidGroupChat";
            this.userList_P_forbidGroupChat.Size = new System.Drawing.Size(134, 24);
            this.userList_P_forbidGroupChat.Text = "禁止群聊";
            // 
            // userList_P_allowPrivateChat
            // 
            this.userList_P_allowPrivateChat.Name = "userList_P_allowPrivateChat";
            this.userList_P_allowPrivateChat.Size = new System.Drawing.Size(134, 24);
            this.userList_P_allowPrivateChat.Text = "允许私聊";
            // 
            // userList_P_allowGroupChat
            // 
            this.userList_P_allowGroupChat.Name = "userList_P_allowGroupChat";
            this.userList_P_allowGroupChat.Size = new System.Drawing.Size(134, 24);
            this.userList_P_allowGroupChat.Text = "允许群聊";
            // 
            // userList_studentShow
            // 
            this.userList_studentShow.Name = "userList_studentShow";
            this.userList_studentShow.Size = new System.Drawing.Size(166, 26);
            this.userList_studentShow.Text = "学生演示";
            // 
            // userList_stopStudentShow
            // 
            this.userList_stopStudentShow.Name = "userList_stopStudentShow";
            this.userList_stopStudentShow.Size = new System.Drawing.Size(166, 26);
            this.userList_stopStudentShow.Text = "停止学生演示";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1122, 599);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.Text = "主页面";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.UserListMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem menuExportSign;
        private DevExpress.XtraBars.BarButtonItem menuClassNamed;
        private DevExpress.XtraBars.BarButtonItem menuGroupChat;
        private DevExpress.XtraBars.BarButtonItem menuTeamCreate;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem menuViewTeam;
        private DevExpress.XtraBars.BarButtonItem menuSilence;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarSubItem menuRomoteControl;
        private DevExpress.XtraBars.BarButtonItem menuDisableMK;
        private DevExpress.XtraBars.BarButtonItem menuScreenShare;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem menuStudentShow;
        private DevExpress.XtraBars.BarButtonItem menuVideoLive;
        private DevExpress.XtraBars.BarButtonItem menuFileShare;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ListView lvOnline;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCall;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.ContextMenuStrip UserListMenu;
        private System.Windows.Forms.ToolStripMenuItem userList_privateChat;
        private System.Windows.Forms.ToolStripMenuItem userList_lockScreen;
        private System.Windows.Forms.ToolStripMenuItem userList_stopLockScreen;
        private System.Windows.Forms.ToolStripMenuItem userList_permisson;
        private System.Windows.Forms.ToolStripMenuItem userList_P_forbidPrivateChat;
        private System.Windows.Forms.ToolStripMenuItem userList_P_forbidGroupChat;
        private System.Windows.Forms.ToolStripMenuItem userList_P_allowPrivateChat;
        private System.Windows.Forms.ToolStripMenuItem userList_P_allowGroupChat;
        private System.Windows.Forms.ToolStripMenuItem userList_studentShow;
        private System.Windows.Forms.ToolStripMenuItem userList_stopStudentShow;
    }
}