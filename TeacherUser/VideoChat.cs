using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpConnectJson;

namespace TeacherUser
{
    public partial class VideoChat : Form
    {
        private VideoCall vc=null;
        private string localIP=null;
        private int localPort;
        private string remoteIP = null;
        private int remotePort;
        private string camera = "Lenovo EasyCamera";
        private VlcPlayer vp = null;
        private string sevIP = ConfigurationManager.AppSettings["serverIP"];
        
        private delegate void DoSomething();//全局代理



        public VideoChat(string _localIP,string _localPort,string _remoteIP,string _remotePort)
        {
            this.localIP = _localIP;
            this.localPort = Convert.ToInt32(_localPort);
            this.remoteIP = _remoteIP;
            this.remotePort = Convert.ToInt32(_remotePort);

            InitializeComponent();
        }

     

        private void VideoChat_Load(object sender, EventArgs e)
        {
            this.stopVideoCallBtn.Enabled = false;   
        }

        private void launchVideoCallBtn_Click(object sender, EventArgs e)
        {
            vp = new VlcPlayer(this.axVLCPlugin21);//vlcPlayer初始化
            vc = new VideoCall(MainForm.clientConnect, sevIP, localIP, localPort, remoteIP, remotePort, vp, camera, UserRole.teacher);//videoCall初始化
            //之前这边错写成 VideoCall vc=new VideoCall(...)，这样的话只是定义了一个与全局变量同名的局部变量，并对局部变量进行实例化，
            //但是全局变量vc仍然未实例化，导致下面recei()调用makeCallSuccess_A()函数中的vc为null,程序出错
            vc.makeCall_A();
            this.launchVideoCallBtn.Enabled = false;
            this.stopVideoCallBtn.Enabled = true;
            this.statusLbl.Text = "请求已发送，等待对方答复....";
        }

        private void stopVideoCallBtn_Click(object sender, EventArgs e)//挂断
        {
            vc.stopVideoCall();
            //vc.disposeVideoCall_AB();
            if (vc != null) vc = null;
            this.launchVideoCallBtn.Enabled = true;
            this.stopVideoCallBtn.Enabled = false;
            this.statusLbl.Text = "视话结束！";
        }

        internal void receiveAccpet(string rtsp)
        {
            //throw new NotImplementedException();
            this.BeginInvoke(new DoSomething(delegate()
            {
                vc.makeCallSuccess_A(rtsp);
                this.statusLbl.Text = "对方已接受邀请！现在开始视话.";
            }));
        }

        private void VideoChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.vcForm = null;
        }

        internal void requireRefused()
        {
            //throw new NotImplementedException();
            vc.disposeVideoCall_AB();
            this.statusLbl.Text = "对方已拒绝视话请求！";
        }
    }
}
