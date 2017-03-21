using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MyTCP;

namespace StudentUser
{
    public partial class ViewRtsp : Form
    {
        private VlcPlayer player = null;
        //private string playAddress = null;
        public string playAddress = null;
       // private TcpConnectJson.ScreenMonitor screenmonitor;
        private string ip = "";
        private int port = 0;
       

        //public ViewRtsp(string IP,int Port)
        //{
        //    InitializeComponent();
        //    this.playAddress = rtspAddress;
        //  //  this.screenmonitor = Screenmonitor;
        //    this.ip = IP;
        //    this.port = Port;
        //    player = new VlcPlayer(this.axVLCPlugin21);
        //}
        public ViewRtsp(string rtspAddress)
        {
            InitializeComponent();
            this.playAddress = rtspAddress;
            player = new VlcPlayer(this.axVLCPlugin21);
           //this.MaximumSize = new Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height); 
  
       }

        private void ViewRtsp_Load(object sender, EventArgs e)
        {
           // this.timer1.Enabled = true;
           // this.timer1.Enabled = true
            /*
            if (this.player != null && playAddress != null)
            {
                player.startPlay(playAddress);
            }
           */
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const int SC_CLOSE = 0xF060;
            const int SC_MINIMIZE = 0xF020;
            const int SC_MAXIMIZE = 0xF030;
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MINIMIZE) //是否点击最小化
                {
                    //这里写操作代码
                    this.Visible = false; //隐藏窗体
                    return;
                }
                if (m.WParam.ToInt32() == SC_MAXIMIZE) //是否点击最大化
                {
                    //MessageBox.Show("最大化");
                   this.FormBorderStyle = FormBorderStyle.None;

                    this.WindowState = FormWindowState.Maximized;
                }
                if (m.WParam.ToInt32() == SC_CLOSE) //是否点击关闭
                {
                    //if (screenmonitor == null)
                    //{
                    //    MessageBox.Show("请通过用户列表右键菜单关闭学生演示!");
                    //    return;
                    //}
                }
            }
            base.WndProc(ref m);
        }
        private void ViewRtsp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("界面即将关闭");
            //if (screenmonitor != null) screenmonitor.stopMonitorOrder_A(ip, port);
            //if (this.player != null)
            //{
            //    player.dispose();
            //}
        }
        internal void startPlay()
        {
            //throw new NotImplementedException();
            if (this.player != null && playAddress != null)
            {
                player.startPlay(playAddress);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal||this.WindowState==FormWindowState.Maximized)
            {
                if (this.player != null && playAddress != null)
                {
                    player.startPlay(playAddress);
                }
            }
        }
//按下ESC键，退出全屏
        private void ViewRtsp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

       
    }
}
