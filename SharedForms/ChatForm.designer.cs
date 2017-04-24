/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net 
 * * 论坛：http://bbs.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2015-01-28
 * * 说明：ChatForm.Designer.cs
 * *
********************************************************************/

namespace SharedForms
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            CCWin.SkinControl.ChatListItem chatListItem1 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem1 = new CCWin.SkinControl.ChatListSubItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            CCWin.SkinControl.ChatListItem chatListItem2 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListItem chatListItem3 = new CCWin.SkinControl.ChatListItem();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("所有人", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("分组", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("私聊", System.Windows.Forms.HorizontalAlignment.Left);
            this.chatListBox1 = new CCWin.SkinControl.ChatListBox();
            this.chatBox_history = new CCWin.SkinControl.SkinChatRichTextBox();
            this.chatBoxSend = new CCWin.SkinControl.SkinChatRichTextBox();
            this.SendMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolStripMenuItem36 = new System.Windows.Forms.ToolStripMenuItem();
            this.按CtrlEnter键发送消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.SysMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolQQShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.气泡设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem51 = new System.Windows.Forms.ToolStripSeparator();
            this.更多设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.Content_panel = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.labChatTitle = new CCWin.SkinControl.SkinLabel();
            this.myListView1 = new SharedForms.MyListView();
            this.SendMenu.SuspendLayout();
            this.SysMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainer1)).BeginInit();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.Panel2.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            this.Content_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatListBox1
            // 
            this.chatListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chatListBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatListBox1.ForeColor = System.Drawing.Color.Black;
            this.chatListBox1.FriendsMobile = true;
            this.chatListBox1.ItemColor = System.Drawing.Color.White;
            chatListItem1.Bounds = new System.Drawing.Rectangle(0, 1, 238, 79);
            chatListItem1.IsOpen = true;
            chatListItem1.IsTwinkleHide = false;
            chatListItem1.OwnerChatListBox = this.chatListBox1;
            chatListSubItem1.Bounds = new System.Drawing.Rectangle(0, 27, 238, 53);
            chatListSubItem1.DisplayName = "所有人";
            chatListSubItem1.HeadImage = ((System.Drawing.Image)(resources.GetObject("chatListSubItem1.HeadImage")));
            chatListSubItem1.HeadRect = new System.Drawing.Rectangle(5, 33, 40, 40);
            chatListSubItem1.ID = ((uint)(0u));
            chatListSubItem1.IpAddress = null;
            chatListSubItem1.IsTwinkle = false;
            chatListSubItem1.IsTwinkleHide = false;
            chatListSubItem1.IsVip = false;
            chatListSubItem1.NicName = "";
            chatListSubItem1.OwnerListItem = chatListItem1;
            chatListSubItem1.PersonalMsg = "";
            chatListSubItem1.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem1.QQShow = null;
            chatListSubItem1.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem1.Tag = null;
            chatListSubItem1.TcpPort = 0;
            chatListSubItem1.UpdPort = 0;
            chatListItem1.SubItems.AddRange(new CCWin.SkinControl.ChatListSubItem[] {
            chatListSubItem1});
            chatListItem1.Tag = null;
            chatListItem1.Text = "所有人";
            chatListItem1.TwinkleSubItemNumber = 0;
            chatListItem2.Bounds = new System.Drawing.Rectangle(0, 81, 238, 25);
            chatListItem2.IsTwinkleHide = false;
            chatListItem2.OwnerChatListBox = this.chatListBox1;
            chatListItem2.Tag = null;
            chatListItem2.Text = "分组聊天";
            chatListItem2.TwinkleSubItemNumber = 0;
            chatListItem3.Bounds = new System.Drawing.Rectangle(0, 107, 238, 25);
            chatListItem3.IsTwinkleHide = false;
            chatListItem3.OwnerChatListBox = this.chatListBox1;
            chatListItem3.Tag = null;
            chatListItem3.Text = "私聊";
            chatListItem3.TwinkleSubItemNumber = 0;
            this.chatListBox1.Items.AddRange(new CCWin.SkinControl.ChatListItem[] {
            chatListItem1,
            chatListItem2,
            chatListItem3});
            this.chatListBox1.ListSubItemMenu = null;
            this.chatListBox1.Location = new System.Drawing.Point(99, 167);
            this.chatListBox1.Name = "chatListBox1";
            this.chatListBox1.SelectSubItem = null;
            this.chatListBox1.Size = new System.Drawing.Size(247, 128);
            this.chatListBox1.SubItemColor = System.Drawing.Color.White;
            this.chatListBox1.SubItemMenu = null;
            this.chatListBox1.TabIndex = 3;
            this.chatListBox1.Text = "chatListBox1";
            this.chatListBox1.ClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListClickEventHandler(this.chatListBox1_ClickSubItem);
            this.chatListBox1.Click += new System.EventHandler(this.chatListBox1_Click);
            // 
            // chatBox_history
            // 
            this.chatBox_history.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chatBox_history.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatBox_history.ContextMenuMode = CCWin.SkinControl.ChatBoxContextMenuMode.None;
            this.chatBox_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatBox_history.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chatBox_history.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.chatBox_history.Location = new System.Drawing.Point(0, 36);
            this.chatBox_history.Margin = new System.Windows.Forms.Padding(2);
            this.chatBox_history.Name = "chatBox_history";
            this.chatBox_history.PopoutImageWhenDoubleClick = false;
            this.chatBox_history.ReadOnly = true;
            this.chatBox_history.SelectControl = null;
            this.chatBox_history.SelectControlIndex = 0;
            this.chatBox_history.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBox_history.Size = new System.Drawing.Size(686, 405);
            this.chatBox_history.TabIndex = 1;
            this.chatBox_history.Text = "";
            // 
            // chatBoxSend
            // 
            this.chatBoxSend.BackColor = System.Drawing.Color.White;
            this.chatBoxSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatBoxSend.ContextMenuMode = CCWin.SkinControl.ChatBoxContextMenuMode.None;
            this.chatBoxSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatBoxSend.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chatBoxSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.chatBoxSend.Location = new System.Drawing.Point(0, 8);
            this.chatBoxSend.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.chatBoxSend.Name = "chatBoxSend";
            this.chatBoxSend.PopoutImageWhenDoubleClick = false;
            this.chatBoxSend.SelectControl = null;
            this.chatBoxSend.SelectControlIndex = 0;
            this.chatBoxSend.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBoxSend.Size = new System.Drawing.Size(686, 111);
            this.chatBoxSend.TabIndex = 0;
            this.chatBoxSend.Text = "";
            // 
            // SendMenu
            // 
            this.SendMenu.Arrow = System.Drawing.Color.Black;
            this.SendMenu.Back = System.Drawing.Color.White;
            this.SendMenu.BackRadius = 2;
            this.SendMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.SendMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.SendMenu.Fore = System.Drawing.Color.Black;
            this.SendMenu.HoverFore = System.Drawing.Color.White;
            this.SendMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SendMenu.ItemAnamorphosis = false;
            this.SendMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.SendMenu.ItemBorderShow = false;
            this.SendMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.SendMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.SendMenu.ItemRadius = 4;
            this.SendMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.SendMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem36,
            this.按CtrlEnter键发送消息ToolStripMenuItem});
            this.SendMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.SendMenu.Name = "MenuState";
            this.SendMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.SendMenu.Size = new System.Drawing.Size(208, 48);
            this.SendMenu.SkinAllColor = true;
            this.SendMenu.TitleAnamorphosis = false;
            this.SendMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(236)))));
            this.SendMenu.TitleRadius = 4;
            this.SendMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolStripMenuItem36
            // 
            this.toolStripMenuItem36.Checked = true;
            this.toolStripMenuItem36.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem36.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem36.Name = "toolStripMenuItem36";
            this.toolStripMenuItem36.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItem36.Text = "按Enter键发送消息";
            // 
            // 按CtrlEnter键发送消息ToolStripMenuItem
            // 
            this.按CtrlEnter键发送消息ToolStripMenuItem.Name = "按CtrlEnter键发送消息ToolStripMenuItem";
            this.按CtrlEnter键发送消息ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.按CtrlEnter键发送消息ToolStripMenuItem.Text = "按Ctrl+Enter键发送消息";
            // 
            // fontDialog
            // 
            this.fontDialog.Color = System.Drawing.SystemColors.ControlText;
            this.fontDialog.ShowColor = true;
            // 
            // SysMenu
            // 
            this.SysMenu.Arrow = System.Drawing.Color.Black;
            this.SysMenu.Back = System.Drawing.Color.White;
            this.SysMenu.BackRadius = 2;
            this.SysMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.SysMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.SysMenu.Fore = System.Drawing.Color.Black;
            this.SysMenu.HoverFore = System.Drawing.Color.White;
            this.SysMenu.ImageScalingSize = new System.Drawing.Size(11, 11);
            this.SysMenu.ItemAnamorphosis = false;
            this.SysMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.SysMenu.ItemBorderShow = false;
            this.SysMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.SysMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(136)))), ((int)(((byte)(200)))));
            this.SysMenu.ItemRadius = 4;
            this.SysMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.SysMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolQQShow,
            this.toolStripMenuItem50,
            this.toolStripSeparator4,
            this.toolStripMenuItem33,
            this.toolStripMenuItem26,
            this.toolExit,
            this.气泡设置ToolStripMenuItem,
            this.toolStripMenuItem51,
            this.更多设置ToolStripMenuItem});
            this.SysMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.SysMenu.Name = "MenuState";
            this.SysMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.SysMenu.Size = new System.Drawing.Size(161, 170);
            this.SysMenu.SkinAllColor = true;
            this.SysMenu.TitleAnamorphosis = false;
            this.SysMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(236)))));
            this.SysMenu.TitleRadius = 4;
            this.SysMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolQQShow
            // 
            this.toolQQShow.Name = "toolQQShow";
            this.toolQQShow.Size = new System.Drawing.Size(160, 22);
            this.toolQQShow.Text = "保持窗口最前";
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.Checked = true;
            this.toolStripMenuItem50.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem50.Text = "合并会话窗口";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem33.Text = "显示自己的皮肤";
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Checked = true;
            this.toolStripMenuItem26.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem26.Text = "启用场景秀模式";
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(160, 22);
            this.toolExit.Text = "场景秀设置";
            // 
            // 气泡设置ToolStripMenuItem
            // 
            this.气泡设置ToolStripMenuItem.Name = "气泡设置ToolStripMenuItem";
            this.气泡设置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.气泡设置ToolStripMenuItem.Text = "气泡设置";
            // 
            // toolStripMenuItem51
            // 
            this.toolStripMenuItem51.Name = "toolStripMenuItem51";
            this.toolStripMenuItem51.Size = new System.Drawing.Size(157, 6);
            // 
            // 更多设置ToolStripMenuItem
            // 
            this.更多设置ToolStripMenuItem.Name = "更多设置ToolStripMenuItem";
            this.更多设置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.更多设置ToolStripMenuItem.Text = "更多设置";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.IsSplitterFixed = true;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.skinSplitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.Content_panel);
            // 
            // skinSplitContainer1.Panel2
            // 
            this.skinSplitContainer1.Panel2.Controls.Add(this.chatBox_history);
            this.skinSplitContainer1.Panel2.Controls.Add(this.chatListBox1);
            this.skinSplitContainer1.Panel2.Controls.Add(this.panel2);
            this.skinSplitContainer1.Panel2.Controls.Add(this.labChatTitle);
            this.skinSplitContainer1.Size = new System.Drawing.Size(940, 602);
            this.skinSplitContainer1.SplitterDistance = 246;
            this.skinSplitContainer1.SplitterWidth = 8;
            this.skinSplitContainer1.TabIndex = 2;
            // 
            // Content_panel
            // 
            this.Content_panel.AutoScroll = true;
            this.Content_panel.AutoSize = true;
            this.Content_panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.Content_panel.Controls.Add(this.myListView1);
            this.Content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content_panel.Location = new System.Drawing.Point(0, 0);
            this.Content_panel.Margin = new System.Windows.Forms.Padding(2);
            this.Content_panel.Name = "Content_panel";
            this.Content_panel.Size = new System.Drawing.Size(246, 602);
            this.Content_panel.TabIndex = 5;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "所有人.png");
            this.imageList1.Images.SetKeyName(1, "群聊.png");
            this.imageList1.Images.SetKeyName(2, "学生.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chatBoxSend);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 161);
            this.panel2.TabIndex = 141;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(686, 8);
            this.panel3.TabIndex = 141;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 42);
            this.panel1.TabIndex = 140;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSend.DownBack = global::SharedForms.Resource1.btn_Down;
            this.btnSend.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(542, 6);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.MouseBack = global::SharedForms.Resource1.btn_Mouse;
            this.btnSend.Name = "btnSend";
            this.btnSend.NormlBack = global::SharedForms.Resource1.btn_norml;
            this.btnSend.Palace = true;
            this.btnSend.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSend.Size = new System.Drawing.Size(60, 30);
            this.btnSend.TabIndex = 139;
            this.btnSend.Text = "发 送";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.DownBack = global::SharedForms.Resource1.btn_Down;
            this.btnClose.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(617, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.MouseBack = global::SharedForms.Resource1.btn_Mouse;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = global::SharedForms.Resource1.btn_norml;
            this.btnClose.Palace = true;
            this.btnClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClose.Size = new System.Drawing.Size(56, 30);
            this.btnClose.TabIndex = 138;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // labChatTitle
            // 
            this.labChatTitle.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Relievo;
            this.labChatTitle.BackColor = System.Drawing.Color.Transparent;
            this.labChatTitle.BorderColor = System.Drawing.Color.White;
            this.labChatTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labChatTitle.Enabled = false;
            this.labChatTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labChatTitle.ForeColor = System.Drawing.Color.White;
            this.labChatTitle.Location = new System.Drawing.Point(0, 0);
            this.labChatTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labChatTitle.Name = "labChatTitle";
            this.labChatTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labChatTitle.Size = new System.Drawing.Size(686, 36);
            this.labChatTitle.TabIndex = 136;
            this.labChatTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // myListView1
            // 
            this.myListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "所有人";
            listViewGroup1.Name = "groupAll";
            listViewGroup2.Header = "分组";
            listViewGroup2.Name = "groupTeam";
            listViewGroup3.Header = "私聊";
            listViewGroup3.Name = "groupPrivate";
            this.myListView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.myListView1.LargeImageList = this.imageList1;
            this.myListView1.Location = new System.Drawing.Point(0, 0);
            this.myListView1.Name = "myListView1";
            this.myListView1.Size = new System.Drawing.Size(246, 602);
            this.myListView1.SmallImageList = this.imageList1;
            this.myListView1.TabIndex = 5;
            this.myListView1.UseCompatibleStateImageBehavior = false;
            this.myListView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(940, 602);
            this.Controls.Add(this.skinSplitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChatForm";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatForm_Paint);
            this.SendMenu.ResumeLayout(false);
            this.SysMenu.ResumeLayout(false);
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel1.PerformLayout();
            this.skinSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainer1)).EndInit();
            this.skinSplitContainer1.ResumeLayout(false);
            this.Content_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinChatRichTextBox chatBox_history;
        public CCWin.SkinControl.SkinChatRichTextBox chatBoxSend;
        private CCWin.SkinControl.SkinContextMenuStrip SendMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem36;
        private System.Windows.Forms.ToolStripMenuItem 按CtrlEnter键发送消息ToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog;
        private CCWin.SkinControl.SkinContextMenuStrip SysMenu;
        private System.Windows.Forms.ToolStripMenuItem toolQQShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem33;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem26;
        private System.Windows.Forms.ToolStripMenuItem 气泡设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem51;
        private System.Windows.Forms.ToolStripMenuItem 更多设置ToolStripMenuItem;
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private System.Windows.Forms.Panel Content_panel;
        private CCWin.SkinControl.SkinLabel labChatTitle;
        private CCWin.SkinControl.SkinButton btnClose;
        private CCWin.SkinControl.SkinButton btnSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CCWin.SkinControl.ChatListBox chatListBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
        private MyListView myListView1;
    }
}