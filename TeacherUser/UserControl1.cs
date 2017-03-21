using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class UserControl1 : UserControl
    {
        private TcpConnectJson.ScreenMonitor screenmonitor;
        private string ip = "";
        private int port = 0;

        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(TcpConnectJson.ScreenMonitor Screenmonitor,string Ip,int Port)
        {
            InitializeComponent();
            screenmonitor = Screenmonitor;
            ip = Ip;
            port = Port;
        }
        public void Set(string info, string path)
        {

            //pictureBox.Size = new Size(250, 140);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Image.FromFile(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox1.DoubleClick += new System.EventHandler(pic_DoubleClick);

            label1.Text = info;
            label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        }
        public void pic_DoubleClick(object sender, System.EventArgs e)  //双击事件
        {
            //Monitor monitor = new Monitor();
            //Thread t = new Thread(new ThreadStart(monitor.Show));
            //t.Start();
            //monitor.Show();
        }
        public void set_PictureBox(Image image)
        {
            pictureBox1.Image = image;
        }
        public void pic_dispose()
        {
            pictureBox1.Image.Dispose();
        }

        private void UserControl_MDC(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("双击");
            if (MainForm.beingScreenBroadcast)
            {
                MainForm.showTip();
                return;
            }
            screenmonitor.requireMonitorVideo_A(ip,port);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
