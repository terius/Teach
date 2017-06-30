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
            this.sendBox = new System.Windows.Forms.RichTextBox();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ChatNav = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.smsPanel1 = new SharedForms.smsPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnUploadFile = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.itemViewTeamMem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labChatTitle = new DevExpress.XtraEditors.LabelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // sendBox
            // 
            this.sendBox.BackColor = System.Drawing.Color.White;
            this.sendBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendBox.Location = new System.Drawing.Point(2, 34);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(1056, 147);
            this.sendBox.TabIndex = 142;
            this.sendBox.Text = "";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ChatNav);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1296, 768);
            this.splitContainerControl1.SplitterPosition = 224;
            this.splitContainerControl1.TabIndex = 143;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ChatNav
            // 
            this.ChatNav.ActiveGroup = this.navBarGroup1;
            this.ChatNav.AllowDrop = false;
            this.ChatNav.Appearance.ItemHotTracked.ForeColor = System.Drawing.Color.White;
            this.ChatNav.Appearance.ItemHotTracked.Options.UseFont = true;
            this.ChatNav.Appearance.ItemHotTracked.Options.UseForeColor = true;
            this.ChatNav.Appearance.ItemPressed.BorderColor = System.Drawing.Color.Red;
            this.ChatNav.Appearance.ItemPressed.Options.UseBorderColor = true;
            this.ChatNav.Appearance.ItemPressed.Options.UseFont = true;
            this.ChatNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatNav.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.ChatNav.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.ChatNav.LinkInterval = 10;
            this.ChatNav.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.ChatNav.Location = new System.Drawing.Point(0, 0);
            this.ChatNav.LookAndFeel.SkinName = "Office 2010 Blue";
            this.ChatNav.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ChatNav.Name = "ChatNav";
            this.ChatNav.OptionsNavPane.ExpandedWidth = 224;
            this.ChatNav.Size = new System.Drawing.Size(224, 768);
            this.ChatNav.TabIndex = 6;
            this.ChatNav.Text = "navBarControl1";
            this.ChatNav.CustomDrawLink += new DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventHandler(this.ChatNav_CustomDrawLink);
            this.ChatNav.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ChatNav_LinkClicked);
            this.ChatNav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChatNav_MouseDown);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.BackColor = System.Drawing.Color.Red;
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup1.Appearance.Options.UseBackColor = true;
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.BackgroundImage")));
            this.navBarGroup1.Caption = "所有人";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup1.LargeImage = global::SharedForms.Resource1.所有人;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SelectedLinkIndex = 0;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup2.Appearance.Options.UseFont = true;
            this.navBarGroup2.Caption = "群组";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup2.LargeImage = global::SharedForms.Resource1.群组;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup3.Appearance.Options.UseFont = true;
            this.navBarGroup3.Caption = "私聊";
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.LargeImage = global::SharedForms.Resource1.私;
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.SeaShell;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.smsPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 36);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1060, 549);
            this.panelControl2.TabIndex = 143;
            // 
            // smsPanel1
            // 
            this.smsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smsPanel1.FireScrollEventOnMouseWheel = true;
            this.smsPanel1.LastY = 10;
            this.smsPanel1.Location = new System.Drawing.Point(0, 0);
            this.smsPanel1.Name = "smsPanel1";
            this.smsPanel1.Size = new System.Drawing.Size(1060, 549);
            this.smsPanel1.TabIndex = 142;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSend);
            this.panelControl1.Controls.Add(this.sendBox);
            this.panelControl1.Controls.Add(this.standaloneBarDockControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 585);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1060, 183);
            this.panelControl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(965, 144);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(879, 144);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 27);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(2, 2);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1056, 32);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.itemViewTeamMem,
            this.barButtonItem1,
            this.btnUploadFile});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "自定义2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(422, 554);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUploadFile, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "自定义2";
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Caption = "上传文件";
            this.btnUploadFile.Id = 2;
            this.btnUploadFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadFile.ImageOptions.Image")));
            this.btnUploadFile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUploadFile.ImageOptions.LargeImage")));
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUploadFile_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1296, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 768);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1296, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 768);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1296, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 768);
            // 
            // itemViewTeamMem
            // 
            this.itemViewTeamMem.Caption = "查看群组成员";
            this.itemViewTeamMem.Id = 0;
            this.itemViewTeamMem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("itemViewTeamMem.ImageOptions.Image")));
            this.itemViewTeamMem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("itemViewTeamMem.ImageOptions.LargeImage")));
            this.itemViewTeamMem.Name = "itemViewTeamMem";
            this.itemViewTeamMem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.itemViewTeamMem_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "上传文件";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.labChatTitle);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1060, 36);
            this.panelControl3.TabIndex = 144;
            // 
            // labChatTitle
            // 
            this.labChatTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.labChatTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.labChatTitle.Appearance.Options.UseFont = true;
            this.labChatTitle.Appearance.Options.UseForeColor = true;
            this.labChatTitle.Location = new System.Drawing.Point(27, 7);
            this.labChatTitle.Name = "labChatTitle";
            this.labChatTitle.Size = new System.Drawing.Size(111, 22);
            this.labChatTitle.TabIndex = 0;
            this.labChatTitle.Text = "labelControl1";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.itemViewTeamMem)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // ChatForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 768);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChatNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private System.Windows.Forms.RichTextBox sendBox;
        private smsPanel smsPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labChatTitle;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarControl ChatNav;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem itemViewTeamMem;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnUploadFile;
    }
}