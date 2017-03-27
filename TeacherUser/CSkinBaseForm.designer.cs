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
 * * 说明：FrmQQChat.Designer.cs
 * *
********************************************************************/

namespace TeacherUser
{
    partial class CSkinBaseForm
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
            this.SuspendLayout();
            // 
            // CSkinBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::TeacherUser.Properties.Resources.main_1;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(183)))), ((int)(((byte)(183)))), ((int)(((byte)(183)))));
            this.ClientSize = new System.Drawing.Size(585, 508);
            this.CloseBoxSize = new System.Drawing.Size(30, 27);
            this.CloseDownBack = global::TeacherUser.Properties.Resources.sysbtn_close_down;
            this.CloseMouseBack = global::TeacherUser.Properties.Resources.sysbtn_close_hover;
            this.CloseNormlBack = global::TeacherUser.Properties.Resources.sysbtn_close_normal;
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.None;
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
            this.Name = "CSkinBaseForm";
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
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmQQChat_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}