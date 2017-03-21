using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpConnectJson;

namespace TeacherUser.InformationInter
{
    public partial class PrivateChat : Form
    {
        private string ipRecv;
        private int portRecv;
        private MainForm parent=null;
        //ftp连接类初始化
        public static FtpConnect ftp;
        static int count = 1;


        public PrivateChat()
        {
            InitializeComponent();
        }

        public PrivateChat(string ipRecv, int portRecv,MainForm pf)
        {
            InitializeComponent();//别忘了从上面复制这句代码
            // TODO: Complete member initialization
            this.ipRecv = ipRecv;
            this.portRecv = portRecv;
            this.parent = pf;
            parent.chatFormList.Add(new ChatForm(ipRecv,portRecv,this));
            ftp = new FtpConnect(MainForm.clientConnect, MainForm.IP, ConfigurationManager.AppSettings["FtpName"], ConfigurationManager.AppSettings["FtpPassword"]);//***********************************  参数要来自配置文件
            ftp.ftpDownLoadFileSuccess += ftp_ftpDownLoadFileSuccess;//

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
        void ftp_ftpDownLoadFileSuccess(string filename)
        {
            //MessageBox.Show(filename);
            //音频例子：xx.amr
            //图片例子：xx.png
            //播放录音
            //this.VideoPlayer.URL = "cache/video/record.amr";
            //this.VideoPlayer.Ctlcontrols.play();
            int i = filename.LastIndexOf(".");
            string type = filename.Substring(i);
            switch (type)
            {
                case ".amr":
                    this.Invoke(new Action(() =>
                    {
                        this.PrivateHistRtb.AppendText('\n' + "来自" + ipRecv + "/" + portRecv + "的语音：" + '\n');
                        this.PrivateHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');
                        /*
                         this.axWindowsMediaPlayer1.URL = "cache/video/record.amr";
                         this.axWindowsMediaPlayer1.Ctlcontrols.play();
                         Clipboard.SetDataObject(Image.FromFile(@"..\..\Images\video.png"), true);
                         groupChatHistRtb.Paste();
                         Clipboard.Clear();
                        */
                        LinkLabel testVideo = new LinkLabel();
                        testVideo.Parent = this.PrivateHistRtb;
                        testVideo.Location = new Point(this.PrivateHistRtb.Location.X + 10 * count, this.PrivateHistRtb.Location.Y + 100 * count);
                        testVideo.Text = "语音消息";
                        //testVideo.Image = Image.FromFile(@"..\..\Images\video.png");
                        testVideo.Tag = "ftpDownload/voice/" + filename;
                        // MessageBox.Show(filename);
                        testVideo.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
                        testVideo.Margin = new Padding(200, 100, 200, 100);
                        //设置鼠标样式
                        testVideo.Cursor = Cursors.Hand;
                        testVideo.Parent = this.PrivateHistRtb;
                        this.PrivateHistRtb.Controls.Add(testVideo);
                        this.PrivateHistRtb.SelectionStart = this.PrivateHistRtb.TextLength;
                        this.PrivateHistRtb.ScrollToCaret();
                        // this.groupChatHistRtb.SelectionStart += 400;
                        /*
                            //创建控件
                            PictureBox picBox = new PictureBox();
                            //设置坐标
                            picBox.Location = new Point(this.groupChatHistRtb.Location.X + 10, this.groupChatHistRtb.Location.Y + 25);
                            //设置图片路径
                            picBox.Image = Image.FromFile(Application.StartupPath + "\\video.PNG");
                            //图片显示模式
                            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
                            //设置鼠标样式
                            picBox.Cursor = Cursors.Hand;
                            //父容器为RichtextBox
                            picBox.Tag = filename;
                            picBox.Parent = this.groupChatHistRtb;
                        
                            //控件的Clik事件
                            picBox.Click += new EventHandler(picBox_Click);
                            //将控件添加至父容器中
                            this.groupChatHistRtb.Controls.Add(picBox);
                          */

                        /*
                         Button btn = new Button();
                         btn.Size = new Size(60,20);
                         btn.Location = groupChatHistRtb.GetPositionFromCharIndex(groupChatHistRtb.SelectionStart);
                         btn.Left += 40;
                         btn.Parent = this.groupChatHistRtb;
                         //btn.Dock = DockStyle.Left;
                         groupChatHistRtb.Controls.Add(btn);

                        // this.groupChatHistRtb.AppendText(" "+'\n');
                       
                         this.groupChatHistRtb.SelectionStart = this.groupChatHistRtb.TextLength;
                         this.groupChatHistRtb.ScrollToCaret();
                      */

                    }));
                    break;
                case ".png":
                case ".PNG":
                case ".jpg":
                    this.Invoke(new Action(() =>
                    {
                        try
                        {
                            this.PrivateHistRtb.AppendText('\n' + "来自" + ipRecv + "/" + portRecv + "的图片：" + '\n');
                            this.PrivateHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');
                            //Bitmap bmp = new Bitmap("D:\\" + filename);
                            // Bitmap bmp = new Bitmap("cache/picture/" + filename);
                            Bitmap bmp = new Bitmap("ftpDownload/picture/" + filename);//*******************************************************
                            if (bmp.Height > this.PrivateHistRtb.Height || bmp.Width > this.PrivateHistRtb.Width)
                            {
                                this.PrivateHistRtb.AppendText("（提示：图片过大！已经进行了压缩。）" + '\n');
                                Clipboard.SetDataObject(KiResizeImage2(bmp, this.PrivateHistRtb.Width, this.PrivateHistRtb.Height));//将数据置于系统剪贴板中
                            }
                            else
                            {
                                Clipboard.SetDataObject(bmp);
                            }
                            //  Clipboard.SetDataObject(KiResizeImage(bmp,100,100));//将数据置于系统剪贴板中
                            DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);//格式
                            if (this.PrivateHistRtb.CanPaste(dataFormat))
                                this.PrivateHistRtb.Paste(dataFormat);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("图片插入失败。" + exc.Message, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        /*
                         this.groupChatHistRtb.AppendText('\n'+"来自" + ipRecv + "/" + portRecv + "的图片：" + '\n');
                         this.groupChatHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');
                         Clipboard.SetDataObject(Image.FromFile("E:\\" + filename), true);
                         groupChatHistRtb.Paste();
                         Clipboard.Clear();
                         this.groupChatHistRtb.SelectionStart = this.groupChatHistRtb.TextLength;
                         this.groupChatHistRtb.ScrollToCaret();
                        */
                    }));

                    break;
                default:
                    break;
            }
        }
        private void PrivateSendBtn_Click(object sender, EventArgs e)//发送 私聊
        {
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.privateChat;
            msg.time = System.DateTime.Now.ToString();
            msg.ipReceive = ipRecv;
            msg.portReceive = portRecv;
           // msg.ipSend = MainForm.serverIP.ToString();//貌似是服务器的ip,应该是自己的ip，但是服务器端代码进行调整后就可以不用加自己的ip了
           // msg.portSend = 15525;
            //msg.portSend = MainForm.serverPORT;//貌似是服务器的port,应该是自己的port，但是服务器端代码进行调整后就可以不用加自己的port了
            msg.content = this.PrivateContentRtb.Text;
            msg.type = MessType.text;
            /*
            if (msg.content.IndexOf("#_")>-1)
            {
                MessageBox.Show("不能出现'#_'等非法字符！");
                return;
            }
             */
            if (msg.content.IndexOf("Ψ") > -1)
            {
                MessageBox.Show("不能出现'Ψ'等非法字符！");
                return;
            }
            MainForm.clientConnect.BeginSendMessage(msg);
            this.PrivateContentRtb.Clear();
            this.PrivateHistRtb.AppendText('\n'+msg.time+"我说："+"\n");
            this.PrivateHistRtb.AppendText(msg.content+"\n");
        }

        private delegate void DoSomething();//全局代理
        public void RecvMess(string ip,int port,string content)
        {
            this.BeginInvoke(new DoSomething(delegate()
            {
                this.PrivateHistRtb.AppendText('\n'+"来自"+ip+"/"+port.ToString()+"的消息：" + "\n");
                this.PrivateHistRtb.AppendText(System.DateTime.Now.ToString() + "\n");
                this.PrivateHistRtb.AppendText(content+ "\n");
                this.PrivateHistRtb.SelectionStart = this.PrivateHistRtb.TextLength;
                this.PrivateHistRtb.ScrollToCaret(); 
                //this.label7.Text=
            })); 
        }

        private void PrivateChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < parent.chatFormList.Count; i++)
            {
                if (parent.chatFormList[i]._cform == this)
                    parent.chatFormList.RemoveAt(i);
            }
        }

        private void PrivateClearBtn_Click(object sender, EventArgs e)//清空
        {
            this.BeginInvoke(new DoSomething(delegate()
            {
                this.PrivateHistRtb.Clear();
            }));
        }


        public void setState(string str)
        {
            this.BeginInvoke(new DoSomething(delegate()
            {
                //this.stateLbl.Text = str;
                this.Text = str;
            }));
        }

        private void reliefPrivateChatBtn_Click(object sender, EventArgs e)//解除禁止私聊
        {
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.reliefForbidPrivateChat;
            msg.time = System.DateTime.Now.ToString();
            msg.ipReceive = ipRecv;
            msg.portReceive = portRecv;
            MainForm.clientConnect.BeginSendMessage(msg);
        }

        private void videoChat_Click(object sender, EventArgs e)
        {
            VideoChat f = new VideoChat(MainForm._localIP,MainForm._localPort.ToString(),ipRecv,portRecv.ToString());
            f.Show();
            MainForm.vcForm = f;
        }

        private void PrivateChat_Load(object sender, EventArgs e)
        {

        }

        private void privateChatImageSend_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"D:\";
            //操作完后恢复为原有的目录
            openFileDialog1.RestoreDirectory = true;
            //filter是设置打开文件对话框　文件类型的下拉列表子项为 txt files(*.txt)和all files(*.*)共2个子项
            //filter的值全是一对对的，比如 bat files(*.bat)|*.bat，以|分隔的2部分
            openFileDialog1.Filter = "png 图片 (*.png)|*.png|(*.PNG)|*.PNG";
            string sendFile;
            // openFileDialog1.FilterIndex = 2;//默认是1
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sendFile = openFileDialog1.FileName;
                // MessageBox.Show(sendFile);
                //将图片上传到服务器
                Messages msg = new Messages();
                msg.clientStyle = UserRole.teacher;
                //msg.order = OrderByTec.groupChat;
                msg.order = OrderByTec.privateChat;
                msg.time = System.DateTime.Now.ToString();
                msg.content = sendFile.Substring(sendFile.LastIndexOf(@"\") + 1);
                msg.type = MessType.picture;
                //msg.ipSend = MainForm._localIP;
                //msg.portSend = MainForm._localPort;
                msg.ipReceive = ipRecv;
                msg.portReceive = portRecv;
                ftpUDParams param = new ftpUDParams(msg, sendFile, "PCtest");
                ftp.beginUploadFile(param);
            }
        }
        public static Bitmap KiResizeImage2(Bitmap bmp, int width, int height)
        {
            try
            {
                // if (bmp.Height > height || bmp.Width > width)
                //{
                float scH = (float)bmp.Height / (float)height;
                float scW = (float)bmp.Width / (float)width;
                float sc = (scH > scW) ? scH : scW;
                int newW = (int)(Math.Floor((float)bmp.Width / sc));
                int newH = (int)(Math.Floor((float)bmp.Height / sc));
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
                //} 
            }
            catch
            {
                return null;
            }
        }


        internal void setPicture(string ip, int port, string picName)
        {
            //throw new NotImplementedException();
            ftpDLParams param = new ftpDLParams(picName, "PCtest", "ftpDownload/picture/" + picName);//*******************************************
            ftp.beginDownloadFile(param);
            ipRecv = ip;
            portRecv = port;
            count++;
        }
    }
}
