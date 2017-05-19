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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("所有人", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("群组", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("私聊", System.Windows.Forms.HorizontalAlignment.Left);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.sendBox = new System.Windows.Forms.RichTextBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chatList = new SharedForms.MyListView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.smsPanel1 = new SharedForms.smsPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labChatTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "所有人.png");
            this.imageList1.Images.SetKeyName(1, "群组.png");
            this.imageList1.Images.SetKeyName(2, "在线学生.png");
            // 
            // sendBox
            // 
            this.sendBox.BackColor = System.Drawing.Color.White;
            this.sendBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendBox.Location = new System.Drawing.Point(2, 2);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(937, 126);
            this.sendBox.TabIndex = 142;
            this.sendBox.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(851, 83);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(758, 83);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(78, 38);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "群组成员";
            // 
            // chatList
            // 
            this.chatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatList.FullRowSelect = true;
            listViewGroup1.Header = "所有人";
            listViewGroup1.Name = "groupAll";
            listViewGroup2.Header = "群组";
            listViewGroup2.Name = "groupTeam";
            listViewGroup3.Header = "私聊";
            listViewGroup3.Name = "groupPrivate";
            this.chatList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.chatList.HideSelection = false;
            this.chatList.LargeImageList = this.imageList1;
            this.chatList.Location = new System.Drawing.Point(0, 0);
            this.chatList.Name = "chatList";
            this.chatList.ShowItemToolTips = true;
            this.chatList.Size = new System.Drawing.Size(165, 658);
            this.chatList.SmallImageList = this.imageList1;
            this.chatList.TabIndex = 5;
            this.toolTip1.SetToolTip(this.chatList, "群组成员");
            this.chatList.UseCompatibleStateImageBehavior = false;
            this.chatList.View = System.Windows.Forms.View.SmallIcon;
            this.chatList.Click += new System.EventHandler(this.chatList_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chatList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1111, 658);
            this.splitContainerControl1.SplitterPosition = 165;
            this.splitContainerControl1.TabIndex = 143;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.smsPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(941, 478);
            this.panelControl2.TabIndex = 143;
            // 
            // smsPanel1
            // 
            this.smsPanel1.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.smsPanel1.Appearance.Options.UseBackColor = true;
            this.smsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smsPanel1.FireScrollEventOnMouseWheel = true;
            this.smsPanel1.LastY = 10;
            this.smsPanel1.Location = new System.Drawing.Point(2, 2);
            this.smsPanel1.Name = "smsPanel1";
            this.smsPanel1.Size = new System.Drawing.Size(937, 474);
            this.smsPanel1.TabIndex = 142;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSend);
            this.panelControl1.Controls.Add(this.sendBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 528);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(941, 130);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.labChatTitle);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(941, 50);
            this.panelControl3.TabIndex = 144;
            // 
            // labChatTitle
            // 
            this.labChatTitle.Location = new System.Drawing.Point(129, 13);
            this.labChatTitle.Name = "labChatTitle";
            this.labChatTitle.Size = new System.Drawing.Size(70, 14);
            this.labChatTitle.TabIndex = 0;
            this.labChatTitle.Text = "labelControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(273, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "labelControl1";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 658);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
     
        private System.Windows.Forms.ImageList imageList1;
        private MyListView chatList;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private System.Windows.Forms.RichTextBox sendBox;
        private smsPanel smsPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labChatTitle;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}