using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TeacherUser.InformationInter;

namespace TeacherUser
{
    public partial class PrivateLetter : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;
        private const int AW_HOR_NEGATIVE = 0x0002;
        private const int AW_VER_POSITIVE = 0x0004;
        private const int AW_VER_NEGATIVE = 0x0008;
        private const int AW_CENTER = 0x0010;
        private const int AW_HIDE = 0x10000;
        private const int AW_ACTIVE = 0x20000;
        private const int AW_SLIDE = 0x40000;
        private const int AW_BLEND = 0x80000;


        private string ip;
        private int port;
        private string content;
        private List<ChatForm> cfList = null;
        private MainForm pf = null;
        public PrivateLetter()
        {
            InitializeComponent();
        }

        public PrivateLetter(string ip, int port, string content,List<ChatForm> list,MainForm mf)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.ip = ip;
            this.port = port;
            this.content = content;
            this.cfList=list;
            this.pf = mf;
        }

        private void PrivateLetter_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);
            setMessage(ip,port,content);
        }

        private void PrivateLetter_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 100, AW_BLEND | AW_HIDE);
        }

        private delegate void DoSomething();//全局代理
       
        public void setMessage(string ipSend, int portSend, string recvContent)
        {
            this.Invoke(new DoSomething(delegate()
            {
                this.linkLabel1.Tag=ipSend+":"+portSend.ToString();
                //this.Parent = this;
                //设置鼠标样式
                this.linkLabel1.Cursor = Cursors.Hand;
    
                this.contentTb.AppendText("来自" + ipSend + "/" + portSend + "的消息：" + '\n');
                this.contentTb.AppendText(System.DateTime.Now.ToString() + '\n');
                this.contentTb.AppendText(recvContent + '\n');
                /*
                this.ipSend = ipSend;
                this.portSend = portSend;
                this.PrivateHistRtb.AppendText("来自" + ipSend + "/" + portSend + "的消息：" + '\n');
                this.PrivateHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');
                this.PrivateHistRtb.AppendText(recvContent + '\n');
                 * */
            }));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //int index1 = linkLabel1.Tag.ToString().IndexOf(":");
            this.Invoke(new DoSomething(delegate()
            {
                PrivateChat f = null;
                if (cfList.Count!=0)
                {
                foreach (ChatForm cf in cfList)
                {
                    if ((cf._ip == this.ip) && (cf._port == this.port))
                    {
                        f=cf._cform;
                        if (cf._cform.WindowState == FormWindowState.Minimized)
                        {
                            cf._cform.WindowState = FormWindowState.Normal;//如果私聊窗体的当前状态是最小化，则将其调整到正常状态
                            cf._cform.BringToFront();//将相应的私聊窗体置顶显示(前提是窗体不能处于最小化状态)
                        }
                    }
                }
                if (f == null)
                {
                    f = new PrivateChat(this.ip, this.port, (MainForm)this.pf);
                    f.Show();    
                }
            }
            else
            {
                f = new PrivateChat(this.ip, this.port, (MainForm)this.pf);
                f.Show();
            }
            cfList = null;
            this.Close();//关闭消息提示
            }));
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();//关闭消息提示
        }          
    }
}
