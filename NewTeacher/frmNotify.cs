
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTeacher
{
    public partial class frmNotify : CCSkinMain
    {
        AddChatRequest _request;
        public frmNotify(AddChatRequest request)
        {
            InitializeComponent();
            _request = request;
        }

        //窗口加载时
        private void FrmInformation_Load(object sender, EventArgs e)
        {
         
            linkLabel1.Text = _request.DisplayName + "给您发了一条新消息，点击打开";
            //初始化窗口出现位置
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            NativeMethods.AnimateWindow(this.Handle, 130, AW.AW_SLIDE + AW.AW_VER_NEGATIVE);//开始窗体动画
        }


        //倒计时三秒关闭弹出窗
        private void timShow_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = (BaseForm)Owner;
            frm.OpenOrCreateChatForm(_request);
            this.Close();
        }
    }
}
