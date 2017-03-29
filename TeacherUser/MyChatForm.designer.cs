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

namespace TeacherUser
{
    partial class MyChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyChatForm));
            this.lblChatName = new CCWin.SkinControl.SkinLabel();
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
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem35 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem45 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem46 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem47 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem48 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem49 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
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
            this.skinToolStrip2.SuspendLayout();
            this.SendMenu.SuspendLayout();
            this.SysMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChatName
            // 
            this.lblChatName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChatName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.lblChatName.AutoSize = true;
            this.lblChatName.BackColor = System.Drawing.Color.Transparent;
            this.lblChatName.BorderColor = System.Drawing.Color.White;
            this.lblChatName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChatName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblChatName.ForeColor = System.Drawing.Color.Black;
            this.lblChatName.ForeColorSuit = true;
            this.lblChatName.Location = new System.Drawing.Point(7, 6);
            this.lblChatName.Name = "lblChatName";
            this.lblChatName.Size = new System.Drawing.Size(86, 31);
            this.lblChatName.TabIndex = 125;
            this.lblChatName.Text = "唯爱。";
            // 
            // chatBox_history
            // 
            this.chatBox_history.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox_history.BackColor = System.Drawing.Color.White;
            this.chatBox_history.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatBox_history.ContextMenuMode = CCWin.SkinControl.ChatBoxContextMenuMode.None;
            this.chatBox_history.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chatBox_history.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.chatBox_history.Location = new System.Drawing.Point(2, 86);
            this.chatBox_history.Name = "chatBox_history";
            this.chatBox_history.PopoutImageWhenDoubleClick = false;
            this.chatBox_history.ReadOnly = true;
            this.chatBox_history.SelectControl = null;
            this.chatBox_history.SelectControlIndex = 0;
            this.chatBox_history.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBox_history.Size = new System.Drawing.Size(662, 343);
            this.chatBox_history.TabIndex = 1;
            this.chatBox_history.Text = "";
            // 
            // chatBoxSend
            // 
            this.chatBoxSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBoxSend.BackColor = System.Drawing.Color.White;
            this.chatBoxSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatBoxSend.ContextMenuMode = CCWin.SkinControl.ChatBoxContextMenuMode.None;
            this.chatBoxSend.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chatBoxSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.chatBoxSend.Location = new System.Drawing.Point(2, 435);
            this.chatBoxSend.Name = "chatBoxSend";
            this.chatBoxSend.PopoutImageWhenDoubleClick = false;
            this.chatBoxSend.SelectControl = null;
            this.chatBoxSend.SelectControlIndex = 0;
            this.chatBoxSend.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBoxSend.Size = new System.Drawing.Size(662, 119);
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
            this.skinToolStrip2.Dock = System.Windows.Forms.DockStyle.None;
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
            this.toolStripButton5,
            this.toolStripDropDownButton3});
            this.skinToolStrip2.Location = new System.Drawing.Point(2, 52);
            this.skinToolStrip2.Name = "skinToolStrip2";
            this.skinToolStrip2.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip2.Size = new System.Drawing.Size(326, 32);
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
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(44, 29);
            this.toolStripDropDownButton2.Text = "toolStripButton8";
            this.toolStripDropDownButton2.ToolTipText = "开始视频通话";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem15.Text = "开始语音会话";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem16.Text = "发起多人语音";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem17.Text = "语音设置";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem18.Text = "语音测试向导";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(174, 26);
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
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(44, 29);
            this.toolStripDropDownButton1.Text = "toolStripButton8";
            this.toolStripDropDownButton1.ToolTipText = "开始语音通话";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem2.Text = "开始视频会话";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem3.Text = "邀请多人视频会话";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(219, 26);
            this.toolStripMenuItem4.Text = "发送视频留言";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(216, 6);
            // 
            // 给对方播放影音文件ToolStripMenuItem
            // 
            this.给对方播放影音文件ToolStripMenuItem.Name = "给对方播放影音文件ToolStripMenuItem";
            this.给对方播放影音文件ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.给对方播放影音文件ToolStripMenuItem.Text = "给对方播放影音文件";
            // 
            // 视频设置ToolStripMenuItem
            // 
            this.视频设置ToolStripMenuItem.Name = "视频设置ToolStripMenuItem";
            this.视频设置ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.视频设置ToolStripMenuItem.Text = "视频设置";
            // 
            // 语音测试向导ToolStripMenuItem
            // 
            this.语音测试向导ToolStripMenuItem.Name = "语音测试向导ToolStripMenuItem";
            this.语音测试向导ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
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
            this.ToolFile.Size = new System.Drawing.Size(39, 29);
            this.ToolFile.Text = "toolStripButton8";
            this.ToolFile.ToolTipText = "传送文件";
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(195, 26);
            this.toolStripMenuItem32.Text = "发送文件/文件夹";
            // 
            // toolStripMenuItem34
            // 
            this.toolStripMenuItem34.Name = "toolStripMenuItem34";
            this.toolStripMenuItem34.Size = new System.Drawing.Size(195, 26);
            this.toolStripMenuItem34.Text = "发送离线文件";
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(195, 26);
            this.toolStripMenuItem24.Text = "发送微云文件";
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(192, 6);
            // 
            // 传文件设置ToolStripMenuItem
            // 
            this.传文件设置ToolStripMenuItem.Name = "传文件设置ToolStripMenuItem";
            this.传文件设置ToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.传文件设置ToolStripMenuItem.Text = "传文件设置";
            // 
            // 文件助手ToolStripMenuItem
            // 
            this.文件助手ToolStripMenuItem.Name = "文件助手ToolStripMenuItem";
            this.文件助手ToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
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
            this.toolStripSplitButton1.Size = new System.Drawing.Size(44, 29);
            this.toolStripSplitButton1.Text = "toolStripButton8";
            this.toolStripSplitButton1.ToolTipText = "远程桌面";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem20.Text = "发送文件";
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem21.Text = "发送文件夹";
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem22.Text = "发送离线文件";
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(174, 26);
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
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem27,
            this.toolStripMenuItem28,
            this.toolStripMenuItem29,
            this.toolStripSeparator1,
            this.toolStripMenuItem30,
            this.toolStripMenuItem31,
            this.toolStripMenuItem35,
            this.toolStripMenuItem40,
            this.toolStripSeparator3,
            this.toolStripMenuItem46,
            this.toolStripMenuItem47,
            this.toolStripMenuItem48,
            this.toolStripMenuItem49});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(39, 29);
            this.toolStripDropDownButton3.Text = "toolStripButton8";
            this.toolStripDropDownButton3.ToolTipText = "应用";
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem27.Text = "发送短信";
            // 
            // toolStripMenuItem28
            // 
            this.toolStripMenuItem28.Name = "toolStripMenuItem28";
            this.toolStripMenuItem28.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem28.Text = "发送邮件";
            // 
            // toolStripMenuItem29
            // 
            this.toolStripMenuItem29.Name = "toolStripMenuItem29";
            this.toolStripMenuItem29.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem29.Text = "手机免费聊QQ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // toolStripMenuItem30
            // 
            this.toolStripMenuItem30.Name = "toolStripMenuItem30";
            this.toolStripMenuItem30.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem30.Text = "搜索";
            // 
            // toolStripMenuItem31
            // 
            this.toolStripMenuItem31.Name = "toolStripMenuItem31";
            this.toolStripMenuItem31.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem31.Text = "腾讯视频";
            // 
            // toolStripMenuItem35
            // 
            this.toolStripMenuItem35.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem37,
            this.toolStripMenuItem38,
            this.toolStripSeparator2,
            this.toolStripMenuItem39});
            this.toolStripMenuItem35.Name = "toolStripMenuItem35";
            this.toolStripMenuItem35.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem35.Text = "财付通";
            // 
            // toolStripMenuItem37
            // 
            this.toolStripMenuItem37.Name = "toolStripMenuItem37";
            this.toolStripMenuItem37.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem37.Text = "我要付款";
            // 
            // toolStripMenuItem38
            // 
            this.toolStripMenuItem38.Name = "toolStripMenuItem38";
            this.toolStripMenuItem38.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem38.Text = "查询交易记录";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // toolStripMenuItem39
            // 
            this.toolStripMenuItem39.Name = "toolStripMenuItem39";
            this.toolStripMenuItem39.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem39.Text = "交易发布";
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem41,
            this.toolStripMenuItem42,
            this.toolStripMenuItem43,
            this.toolStripMenuItem44,
            this.toolStripMenuItem45});
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem40.Text = "QQ风尚";
            // 
            // toolStripMenuItem41
            // 
            this.toolStripMenuItem41.Name = "toolStripMenuItem41";
            this.toolStripMenuItem41.Size = new System.Drawing.Size(144, 26);
            this.toolStripMenuItem41.Text = "QQ头像";
            // 
            // toolStripMenuItem42
            // 
            this.toolStripMenuItem42.Name = "toolStripMenuItem42";
            this.toolStripMenuItem42.Size = new System.Drawing.Size(144, 26);
            this.toolStripMenuItem42.Text = "QQ皮肤";
            // 
            // toolStripMenuItem43
            // 
            this.toolStripMenuItem43.Name = "toolStripMenuItem43";
            this.toolStripMenuItem43.Size = new System.Drawing.Size(144, 26);
            this.toolStripMenuItem43.Text = "QQ表情";
            // 
            // toolStripMenuItem44
            // 
            this.toolStripMenuItem44.Name = "toolStripMenuItem44";
            this.toolStripMenuItem44.Size = new System.Drawing.Size(144, 26);
            this.toolStripMenuItem44.Text = "会员炫铃";
            // 
            // toolStripMenuItem45
            // 
            this.toolStripMenuItem45.Name = "toolStripMenuItem45";
            this.toolStripMenuItem45.Size = new System.Drawing.Size(144, 26);
            this.toolStripMenuItem45.Text = "下载壁纸";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // toolStripMenuItem46
            // 
            this.toolStripMenuItem46.Name = "toolStripMenuItem46";
            this.toolStripMenuItem46.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem46.Text = "给他推荐好友";
            // 
            // toolStripMenuItem47
            // 
            this.toolStripMenuItem47.Name = "toolStripMenuItem47";
            this.toolStripMenuItem47.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem47.Text = "删除好友";
            // 
            // toolStripMenuItem48
            // 
            this.toolStripMenuItem48.Name = "toolStripMenuItem48";
            this.toolStripMenuItem48.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem48.Text = "移至黑名单";
            // 
            // toolStripMenuItem49
            // 
            this.toolStripMenuItem49.Name = "toolStripMenuItem49";
            this.toolStripMenuItem49.Size = new System.Drawing.Size(183, 26);
            this.toolStripMenuItem49.Text = "举报";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btnSend.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSend.DownBack = ((System.Drawing.Image)(resources.GetObject("btnSend.DownBack")));
            this.btnSend.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(474, 569);
            this.btnSend.Margin = new System.Windows.Forms.Padding(0);
            this.btnSend.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnSend.MouseBack")));
            this.btnSend.Name = "btnSend";
            this.btnSend.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnSend.NormlBack")));
            this.btnSend.Palace = true;
            this.btnSend.Radius = 6;
            this.btnSend.RoundStyle = CCWin.SkinClass.RoundStyle.Left;
            this.btnSend.Size = new System.Drawing.Size(61, 31);
            this.btnSend.TabIndex = 135;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.DownBack = ((System.Drawing.Image)(resources.GetObject("btnClose.DownBack")));
            this.btnClose.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(388, 569);
            this.btnClose.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnClose.MouseBack")));
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnClose.NormlBack")));
            this.btnClose.Palace = true;
            this.btnClose.Radius = 6;
            this.btnClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClose.Size = new System.Drawing.Size(69, 31);
            this.btnClose.TabIndex = 134;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.SendMenu.Size = new System.Drawing.Size(250, 56);
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
            this.toolStripMenuItem36.Size = new System.Drawing.Size(249, 26);
            this.toolStripMenuItem36.Text = "按Enter键发送消息";
            // 
            // 按CtrlEnter键发送消息ToolStripMenuItem
            // 
            this.按CtrlEnter键发送消息ToolStripMenuItem.Name = "按CtrlEnter键发送消息ToolStripMenuItem";
            this.按CtrlEnter键发送消息ToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
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
            this.SysMenu.Size = new System.Drawing.Size(190, 198);
            this.SysMenu.SkinAllColor = true;
            this.SysMenu.TitleAnamorphosis = false;
            this.SysMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(236)))));
            this.SysMenu.TitleRadius = 4;
            this.SysMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolQQShow
            // 
            this.toolQQShow.Name = "toolQQShow";
            this.toolQQShow.Size = new System.Drawing.Size(189, 26);
            this.toolQQShow.Text = "保持窗口最前";
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.Checked = true;
            this.toolStripMenuItem50.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(189, 26);
            this.toolStripMenuItem50.Text = "合并会话窗口";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(189, 26);
            this.toolStripMenuItem33.Text = "显示自己的皮肤";
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Checked = true;
            this.toolStripMenuItem26.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(189, 26);
            this.toolStripMenuItem26.Text = "启用场景秀模式";
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(189, 26);
            this.toolExit.Text = "场景秀设置";
            // 
            // 气泡设置ToolStripMenuItem
            // 
            this.气泡设置ToolStripMenuItem.Name = "气泡设置ToolStripMenuItem";
            this.气泡设置ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.气泡设置ToolStripMenuItem.Text = "气泡设置";
            // 
            // toolStripMenuItem51
            // 
            this.toolStripMenuItem51.Name = "toolStripMenuItem51";
            this.toolStripMenuItem51.Size = new System.Drawing.Size(186, 6);
            // 
            // 更多设置ToolStripMenuItem
            // 
            this.更多设置ToolStripMenuItem.Name = "更多设置ToolStripMenuItem";
            this.更多设置ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.更多设置ToolStripMenuItem.Text = "更多设置";
            // 
            // MyChatForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::TeacherUser.Properties.Resources.main_1;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(183)))), ((int)(((byte)(183)))), ((int)(((byte)(183)))));
            this.ClientSize = new System.Drawing.Size(667, 606);
            this.CloseBoxSize = new System.Drawing.Size(30, 27);
            this.CloseDownBack = global::TeacherUser.Properties.Resources.sysbtn_close_down;
            this.CloseMouseBack = global::TeacherUser.Properties.Resources.sysbtn_close_hover;
            this.CloseNormlBack = global::TeacherUser.Properties.Resources.sysbtn_close_normal;
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.skinToolStrip2);
            this.Controls.Add(this.chatBoxSend);
            this.Controls.Add(this.chatBox_history);
            this.Controls.Add(this.lblChatName);
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.InnerBorderColor = System.Drawing.Color.Transparent;
            this.MaxDownBack = global::TeacherUser.Properties.Resources.sysbtn_max_down;
            this.MaxMouseBack = global::TeacherUser.Properties.Resources.sysbtn_max_hover;
            this.MaxNormlBack = global::TeacherUser.Properties.Resources.sysbtn_max_normal;
            this.MaxSize = new System.Drawing.Size(30, 27);
            this.MiniDownBack = global::TeacherUser.Properties.Resources.sysbtn_min_down;
            this.MiniMouseBack = global::TeacherUser.Properties.Resources.sysbtn_min_hover;
            this.MinimumSize = new System.Drawing.Size(585, 508);
            this.MiniNormlBack = global::TeacherUser.Properties.Resources.sysbtn_min_normal;
            this.MiniSize = new System.Drawing.Size(30, 27);
            this.Name = "MyChatForm";
            this.Opacity = 0.98D;
            this.Radius = 2;
            this.RestoreDownBack = global::TeacherUser.Properties.Resources.sysbtn_restore_down;
            this.RestoreMouseBack = global::TeacherUser.Properties.Resources.sysbtn_restore_hover;
            this.RestoreNormlBack = global::TeacherUser.Properties.Resources.sysbtn_restore_normal;
            this.Shadow = false;
            this.ShadowPalace = global::TeacherUser.Properties.Resources.ShadowPalace;
            this.ShadowWidth = 6;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.ChatForm_SysBottomClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatForm_Paint);
            this.skinToolStrip2.ResumeLayout(false);
            this.skinToolStrip2.PerformLayout();
            this.SendMenu.ResumeLayout(false);
            this.SysMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinLabel lblChatName;
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
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem27;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem28;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem29;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem30;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem31;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem35;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem37;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem38;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem39;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem40;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem41;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem42;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem43;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem44;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem45;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem46;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem47;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem48;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem49;
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
        private CCWin.SkinControl.SkinButton btnSend;
        private CCWin.SkinControl.SkinButton btnClose;
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
    }
}