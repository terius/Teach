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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            CCWin.SkinControl.ChatListItem chatListItem1 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem1 = new CCWin.SkinControl.ChatListSubItem();
            CCWin.SkinControl.ChatListItem chatListItem2 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem2 = new CCWin.SkinControl.ChatListSubItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem3 = new CCWin.SkinControl.ChatListSubItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem4 = new CCWin.SkinControl.ChatListSubItem();
            CCWin.SkinControl.ChatListItem chatListItem3 = new CCWin.SkinControl.ChatListItem();
            this.chatBox_history = new CCWin.SkinControl.SkinChatRichTextBox();
            this.chatBoxSend = new CCWin.SkinControl.SkinChatRichTextBox();
            this.skinToolStrip2 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.给对方播放影音文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视频设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语音测试向导ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripSeparator();
            this.传文件设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件助手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.labChatTitle = new CCWin.SkinControl.SkinLabel();
            this.chatListBox1 = new CCWin.SkinControl.ChatListBox();
            this.skinToolStrip2.SuspendLayout();
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
            // chatBox_history
            // 
            this.chatBox_history.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chatBox_history.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatBox_history.ContextMenuMode = CCWin.SkinControl.ChatBoxContextMenuMode.None;
            this.chatBox_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatBox_history.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chatBox_history.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.chatBox_history.Location = new System.Drawing.Point(0, 36);
            this.chatBox_history.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chatBox_history.Name = "chatBox_history";
            this.chatBox_history.PopoutImageWhenDoubleClick = false;
            this.chatBox_history.ReadOnly = true;
            this.chatBox_history.SelectControl = null;
            this.chatBox_history.SelectControlIndex = 0;
            this.chatBox_history.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBox_history.Size = new System.Drawing.Size(685, 405);
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
            this.chatBoxSend.Location = new System.Drawing.Point(0, 32);
            this.chatBoxSend.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.chatBoxSend.Name = "chatBoxSend";
            this.chatBoxSend.PopoutImageWhenDoubleClick = false;
            this.chatBoxSend.SelectControl = null;
            this.chatBoxSend.SelectControlIndex = 0;
            this.chatBoxSend.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBoxSend.Size = new System.Drawing.Size(685, 87);
            this.chatBoxSend.TabIndex = 0;
            this.chatBoxSend.Text = "";
            // 
            // skinToolStrip2
            // 
            this.skinToolStrip2.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinToolStrip2.Back = System.Drawing.Color.White;
            this.skinToolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BackRadius = 4;
            this.skinToolStrip2.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip2.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip2.BaseForeAnamorphosis = false;
            this.skinToolStrip2.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip2.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip2.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip2.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip2.BaseItemAnamorphosis = true;
            this.skinToolStrip2.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip2.BaseItemBorderShow = true;
            this.skinToolStrip2.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip2.BaseItemDown")));
            this.skinToolStrip2.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip2.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip2.BaseItemMouse")));
            this.skinToolStrip2.BaseItemNorml = null;
            this.skinToolStrip2.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BaseItemRadius = 2;
            this.skinToolStrip2.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(195)))), ((int)(((byte)(204)))));
            this.skinToolStrip2.BindTabControl = null;
            this.skinToolStrip2.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip2.Fore = System.Drawing.Color.Black;
            this.skinToolStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip2.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip2.ItemAnamorphosis = false;
            this.skinToolStrip2.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemBorderShow = false;
            this.skinToolStrip2.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemRadius = 1;
            this.skinToolStrip2.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.ToolFile,
            this.toolStripButton4,
            this.toolStripSplitButton1,
            this.toolStripButton5});
            this.skinToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip2.Name = "skinToolStrip2";
            this.skinToolStrip2.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.Size = new System.Drawing.Size(685, 32);
            this.skinToolStrip2.SkinAllColor = true;
            this.skinToolStrip2.TabIndex = 133;
            this.skinToolStrip2.Text = "skinToolStrip2";
            this.skinToolStrip2.TitleAnamorphosis = false;
            this.skinToolStrip2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(236)))));
            this.skinToolStrip2.TitleRadius = 4;
            this.skinToolStrip2.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(41, 29);
            this.toolStripDropDownButton2.Text = "toolStripButton8";
            this.toolStripDropDownButton2.ToolTipText = "开始视频通话";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem15.Text = "开始语音会话";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem16.Text = "发起多人语音";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem17.Text = "语音设置";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem18.Text = "语音测试向导";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem19.Text = "发送语音信息";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem7,
            this.给对方播放影音文件ToolStripMenuItem,
            this.视频设置ToolStripMenuItem,
            this.语音测试向导ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(41, 29);
            this.toolStripDropDownButton1.Text = "toolStripButton8";
            this.toolStripDropDownButton1.ToolTipText = "开始语音通话";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem2.Text = "开始视频会话";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem3.Text = "邀请多人视频会话";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem4.Text = "发送视频留言";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(181, 6);
            // 
            // 给对方播放影音文件ToolStripMenuItem
            // 
            this.给对方播放影音文件ToolStripMenuItem.Name = "给对方播放影音文件ToolStripMenuItem";
            this.给对方播放影音文件ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.给对方播放影音文件ToolStripMenuItem.Text = "给对方播放影音文件";
            // 
            // 视频设置ToolStripMenuItem
            // 
            this.视频设置ToolStripMenuItem.Name = "视频设置ToolStripMenuItem";
            this.视频设置ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.视频设置ToolStripMenuItem.Text = "视频设置";
            // 
            // 语音测试向导ToolStripMenuItem
            // 
            this.语音测试向导ToolStripMenuItem.Name = "语音测试向导ToolStripMenuItem";
            this.语音测试向导ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.语音测试向导ToolStripMenuItem.Text = "语音测试向导";
            // 
            // ToolFile
            // 
            this.ToolFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem32,
            this.toolStripMenuItem34,
            this.toolStripMenuItem24,
            this.toolStripMenuItem25,
            this.传文件设置ToolStripMenuItem,
            this.文件助手ToolStripMenuItem});
            this.ToolFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolFile.Image")));
            this.ToolFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolFile.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.ToolFile.Name = "ToolFile";
            this.ToolFile.Size = new System.Drawing.Size(38, 29);
            this.ToolFile.Text = "toolStripButton8";
            this.ToolFile.ToolTipText = "传送文件";
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem32.Text = "发送文件/文件夹";
            // 
            // toolStripMenuItem34
            // 
            this.toolStripMenuItem34.Name = "toolStripMenuItem34";
            this.toolStripMenuItem34.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem34.Text = "发送离线文件";
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem24.Text = "发送微云文件";
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(162, 6);
            // 
            // 传文件设置ToolStripMenuItem
            // 
            this.传文件设置ToolStripMenuItem.Name = "传文件设置ToolStripMenuItem";
            this.传文件设置ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.传文件设置ToolStripMenuItem.Text = "传文件设置";
            // 
            // 文件助手ToolStripMenuItem
            // 
            this.文件助手ToolStripMenuItem.Name = "文件助手ToolStripMenuItem";
            this.文件助手ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.文件助手ToolStripMenuItem.Text = "文件助手";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton4.Text = "toolStripButton1";
            this.toolStripButton4.ToolTipText = "创建讨论组";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22,
            this.toolStripMenuItem23});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(41, 29);
            this.toolStripSplitButton1.Text = "toolStripButton8";
            this.toolStripSplitButton1.ToolTipText = "远程桌面";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem20.Text = "发送文件";
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem21.Text = "发送文件夹";
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem22.Text = "发送离线文件";
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem23.Text = "传文件设置";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(31, 29);
            this.toolStripButton5.Text = "toolStripButton1";
            this.toolStripButton5.ToolTipText = "屏幕分享";
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
            this.SendMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.SendMenu_Closing);
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
            this.skinSplitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.Content_panel);
            // 
            // skinSplitContainer1.Panel2
            // 
            this.skinSplitContainer1.Panel2.Controls.Add(this.chatBox_history);
            this.skinSplitContainer1.Panel2.Controls.Add(this.panel2);
            this.skinSplitContainer1.Panel2.Controls.Add(this.labChatTitle);
            this.skinSplitContainer1.Size = new System.Drawing.Size(940, 602);
            this.skinSplitContainer1.SplitterDistance = 247;
            this.skinSplitContainer1.SplitterWidth = 8;
            this.skinSplitContainer1.TabIndex = 2;
            // 
            // Content_panel
            // 
            this.Content_panel.AutoScroll = true;
            this.Content_panel.AutoSize = true;
            this.Content_panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.Content_panel.Controls.Add(this.chatListBox1);
            this.Content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content_panel.Location = new System.Drawing.Point(0, 0);
            this.Content_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Content_panel.Name = "Content_panel";
            this.Content_panel.Size = new System.Drawing.Size(247, 602);
            this.Content_panel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chatBoxSend);
            this.panel2.Controls.Add(this.skinToolStrip2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 161);
            this.panel2.TabIndex = 141;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 42);
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
            this.btnSend.Location = new System.Drawing.Point(541, 6);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.btnClose.Location = new System.Drawing.Point(616, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.labChatTitle.Size = new System.Drawing.Size(685, 36);
            this.labChatTitle.TabIndex = 136;
            this.labChatTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chatListBox1
            // 
            this.chatListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chatListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatListBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatListBox1.ForeColor = System.Drawing.Color.Black;
            this.chatListBox1.FriendsMobile = true;
            this.chatListBox1.ItemColor = System.Drawing.Color.White;
            chatListItem1.Bounds = new System.Drawing.Rectangle(0, 1, 247, 79);
            chatListItem1.IsOpen = true;
            chatListItem1.IsTwinkleHide = false;
            chatListItem1.OwnerChatListBox = this.chatListBox1;
            chatListSubItem1.Bounds = new System.Drawing.Rectangle(0, 27, 247, 53);
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
            chatListItem2.Bounds = new System.Drawing.Rectangle(0, 81, 247, 25);
            chatListItem2.IsTwinkleHide = false;
            chatListItem2.OwnerChatListBox = this.chatListBox1;
            chatListSubItem2.Bounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem2.DisplayName = "分组1";
            chatListSubItem2.HeadImage = ((System.Drawing.Image)(resources.GetObject("chatListSubItem2.HeadImage")));
            chatListSubItem2.HeadRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem2.ID = ((uint)(0u));
            chatListSubItem2.IpAddress = null;
            chatListSubItem2.IsTwinkle = false;
            chatListSubItem2.IsTwinkleHide = false;
            chatListSubItem2.IsVip = false;
            chatListSubItem2.NicName = "";
            chatListSubItem2.OwnerListItem = chatListItem2;
            chatListSubItem2.PersonalMsg = "";
            chatListSubItem2.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem2.QQShow = null;
            chatListSubItem2.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem2.Tag = null;
            chatListSubItem2.TcpPort = 0;
            chatListSubItem2.UpdPort = 0;
            chatListSubItem3.Bounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem3.DisplayName = "分组2";
            chatListSubItem3.HeadImage = ((System.Drawing.Image)(resources.GetObject("chatListSubItem3.HeadImage")));
            chatListSubItem3.HeadRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem3.ID = ((uint)(0u));
            chatListSubItem3.IpAddress = null;
            chatListSubItem3.IsTwinkle = false;
            chatListSubItem3.IsTwinkleHide = false;
            chatListSubItem3.IsVip = false;
            chatListSubItem3.NicName = "";
            chatListSubItem3.OwnerListItem = chatListItem2;
            chatListSubItem3.PersonalMsg = "";
            chatListSubItem3.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem3.QQShow = null;
            chatListSubItem3.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem3.Tag = null;
            chatListSubItem3.TcpPort = 0;
            chatListSubItem3.UpdPort = 0;
            chatListSubItem4.Bounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem4.DisplayName = "分组3";
            chatListSubItem4.HeadImage = ((System.Drawing.Image)(resources.GetObject("chatListSubItem4.HeadImage")));
            chatListSubItem4.HeadRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem4.ID = ((uint)(0u));
            chatListSubItem4.IpAddress = null;
            chatListSubItem4.IsTwinkle = false;
            chatListSubItem4.IsTwinkleHide = false;
            chatListSubItem4.IsVip = false;
            chatListSubItem4.NicName = "";
            chatListSubItem4.OwnerListItem = chatListItem2;
            chatListSubItem4.PersonalMsg = "";
            chatListSubItem4.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem4.QQShow = null;
            chatListSubItem4.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem4.Tag = null;
            chatListSubItem4.TcpPort = 0;
            chatListSubItem4.UpdPort = 0;
            chatListItem2.SubItems.AddRange(new CCWin.SkinControl.ChatListSubItem[] {
            chatListSubItem2,
            chatListSubItem3,
            chatListSubItem4});
            chatListItem2.Tag = null;
            chatListItem2.Text = "分组聊天";
            chatListItem2.TwinkleSubItemNumber = 0;
            chatListItem3.Bounds = new System.Drawing.Rectangle(0, 107, 247, 25);
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
            this.chatListBox1.Location = new System.Drawing.Point(0, 0);
            this.chatListBox1.Name = "chatListBox1";
            this.chatListBox1.SelectSubItem = null;
            this.chatListBox1.Size = new System.Drawing.Size(247, 602);
            this.chatListBox1.SubItemColor = System.Drawing.Color.White;
            this.chatListBox1.SubItemMenu = null;
            this.chatListBox1.TabIndex = 3;
            this.chatListBox1.Text = "chatListBox1";
            this.chatListBox1.ClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListClickEventHandler(this.chatListBox1_ClickSubItem);
            this.chatListBox1.Click += new System.EventHandler(this.chatListBox1_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(940, 602);
            this.Controls.Add(this.skinSplitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChatForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatForm_Paint);
            this.skinToolStrip2.ResumeLayout(false);
            this.skinToolStrip2.PerformLayout();
            this.SendMenu.ResumeLayout(false);
            this.SysMenu.ResumeLayout(false);
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel1.PerformLayout();
            this.skinSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainer1)).EndInit();
            this.skinSplitContainer1.ResumeLayout(false);
            this.Content_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinChatRichTextBox chatBox_history;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip2;
        private System.Windows.Forms.ToolStripSplitButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem 给对方播放影音文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视频设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 语音测试向导ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem23;
        private System.Windows.Forms.ToolStripDropDownButton ToolFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem32;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem34;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem24;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem25;
        private System.Windows.Forms.ToolStripMenuItem 传文件设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件助手ToolStripMenuItem;
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
    }
}