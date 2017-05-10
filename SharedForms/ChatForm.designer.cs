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
            this.chatBox_history = new CCWin.SkinControl.SkinChatRichTextBox();
            this.chatBoxSend = new CCWin.SkinControl.SkinChatRichTextBox();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.Content_panel = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.labChatTitle = new CCWin.SkinControl.SkinLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chatList = new SharedForms.MyListView();
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
            this.chatBox_history.Location = new System.Drawing.Point(0, 45);
            this.chatBox_history.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatBox_history.Name = "chatBox_history";
            this.chatBox_history.PopoutImageWhenDoubleClick = false;
            this.chatBox_history.ReadOnly = true;
            this.chatBox_history.SelectControl = null;
            this.chatBox_history.SelectControlIndex = 0;
            this.chatBox_history.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBox_history.Size = new System.Drawing.Size(915, 506);
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
            this.chatBoxSend.Location = new System.Drawing.Point(0, 10);
            this.chatBoxSend.Margin = new System.Windows.Forms.Padding(3, 10, 3, 2);
            this.chatBoxSend.Name = "chatBoxSend";
            this.chatBoxSend.PopoutImageWhenDoubleClick = false;
            this.chatBoxSend.SelectControl = null;
            this.chatBoxSend.SelectControlIndex = 0;
            this.chatBoxSend.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.chatBoxSend.Size = new System.Drawing.Size(915, 139);
            this.chatBoxSend.TabIndex = 0;
            this.chatBoxSend.Text = "";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.IsSplitterFixed = true;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.skinSplitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.skinSplitContainer1.Size = new System.Drawing.Size(1253, 752);
            this.skinSplitContainer1.SplitterDistance = 327;
            this.skinSplitContainer1.SplitterWidth = 11;
            this.skinSplitContainer1.TabIndex = 2;
            // 
            // Content_panel
            // 
            this.Content_panel.AutoScroll = true;
            this.Content_panel.AutoSize = true;
            this.Content_panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.Content_panel.Controls.Add(this.chatList);
            this.Content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content_panel.Location = new System.Drawing.Point(0, 0);
            this.Content_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Content_panel.Name = "Content_panel";
            this.Content_panel.Size = new System.Drawing.Size(327, 752);
            this.Content_panel.TabIndex = 5;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "所有人.png");
            this.imageList1.Images.SetKeyName(1, "群组.png");
            this.imageList1.Images.SetKeyName(2, "在线学生.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chatBoxSend);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 551);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 201);
            this.panel2.TabIndex = 141;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(915, 10);
            this.panel3.TabIndex = 141;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 52);
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
            this.btnSend.Location = new System.Drawing.Point(723, 8);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.MouseBack = global::SharedForms.Resource1.btn_Mouse;
            this.btnSend.Name = "btnSend";
            this.btnSend.NormlBack = global::SharedForms.Resource1.btn_norml;
            this.btnSend.Palace = true;
            this.btnSend.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSend.Size = new System.Drawing.Size(80, 38);
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
            this.btnClose.Location = new System.Drawing.Point(823, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.MouseBack = global::SharedForms.Resource1.btn_Mouse;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = global::SharedForms.Resource1.btn_norml;
            this.btnClose.Palace = true;
            this.btnClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnClose.Size = new System.Drawing.Size(75, 38);
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
            this.labChatTitle.Name = "labChatTitle";
            this.labChatTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labChatTitle.Size = new System.Drawing.Size(915, 45);
            this.labChatTitle.TabIndex = 136;
            this.labChatTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.chatList.Margin = new System.Windows.Forms.Padding(4);
            this.chatList.Name = "chatList";
            this.chatList.ShowItemToolTips = true;
            this.chatList.Size = new System.Drawing.Size(327, 752);
            this.chatList.SmallImageList = this.imageList1;
            this.chatList.TabIndex = 5;
            this.toolTip1.SetToolTip(this.chatList, "群组成员");
            this.chatList.UseCompatibleStateImageBehavior = false;
            this.chatList.View = System.Windows.Forms.View.SmallIcon;
            this.chatList.Click += new System.EventHandler(this.chatList_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1253, 752);
            this.Controls.Add(this.skinSplitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatForm";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatForm_Paint);
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
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private System.Windows.Forms.Panel Content_panel;
        private CCWin.SkinControl.SkinLabel labChatTitle;
        private CCWin.SkinControl.SkinButton btnClose;
        private CCWin.SkinControl.SkinButton btnSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
        private MyListView chatList;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}