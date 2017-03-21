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

namespace TeacherUser
{
    public partial class GroupChat : Form
    {
        private string ipRecv;//消息发送方的ip
        private int portRecv;//消息发送方的port
        //private string content = null;

        //ftp连接类初始化
        public static FtpConnect ftp;

        //声音播放类初始化
       // RecordVideo playVideo = new RecordVideo();
        RecordVoice rVoice = null;

        static int count = 1;

        public GroupChat()
        {
            InitializeComponent();
            rVoice = new RecordVoice(this.axWindowsMediaPlayer1);
            //ftp连接类初始化
            ftp = new FtpConnect(MainForm.clientConnect, MainForm.IP, ConfigurationManager.AppSettings["FtpName"], ConfigurationManager.AppSettings["FtpPassword"]);//***********************************  参数要来自配置文件
            ftp.ftpDownLoadFileSuccess += ftp_ftpDownLoadFileSuccess;//
            ftp.ftpConnectFailed+=ftp_ftpConnectFailed;
           // this.groupChatHistRtb.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
        }

        private void ftp_ftpConnectFailed(string filename, string msg)
        {
            //throw new NotImplementedException();
            MessageBox.Show("FTP服务异常！"+msg);
            return;
        }

        

       private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rVoice.playVoice(((LinkLabel)sender).Tag.ToString());
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
                        this.groupChatHistRtb.AppendText( '\n'+"来自" + ipRecv + "/" + portRecv + "的语音：" + '\n');
                        this.groupChatHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');

                       /*
                        this.axWindowsMediaPlayer1.URL = "cache/video/record.amr";
                        this.axWindowsMediaPlayer1.Ctlcontrols.play();
                        Clipboard.SetDataObject(Image.FromFile(@"..\..\Images\video.png"), true);
                        groupChatHistRtb.Paste();
                        Clipboard.Clear();
                       */
                         LinkLabel testVideo = new LinkLabel();          
                         testVideo.Parent = this.groupChatHistRtb;
                         testVideo.Location = new Point(this.groupChatHistRtb.Location.X + 10*count , this.groupChatHistRtb.Location.Y + 100*count);
                         testVideo.Text = "语音消息";
                         //testVideo.Image = Image.FromFile(@"..\..\Images\video.png");
                        //testVideo.Tag = "ftpDownload/voice/"+filename;
                         testVideo.Tag =filename;
                        // MessageBox.Show(filename);
                         testVideo.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
                         testVideo.Margin = new Padding(200, 100, 200, 100);
                         //设置鼠标样式
                         testVideo.Cursor = Cursors.Hand;
                         testVideo.Parent = this.groupChatHistRtb;
                         this.groupChatHistRtb.Controls.Add(testVideo);
                         this.groupChatHistRtb.SelectionStart = this.groupChatHistRtb.TextLength;
                         this.groupChatHistRtb.ScrollToCaret();
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
                           this.groupChatHistRtb.AppendText('\n' + "来自" + ipRecv + "/" + portRecv + "的图片：" + '\n');
                           this.groupChatHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');
                           //Bitmap bmp = new Bitmap("D:\\" + filename);
                          // Bitmap bmp = new Bitmap("cache/picture/" + filename);
                           Bitmap bmp = new Bitmap("ftpDownload/picture/" + filename);//*******************************************************
                           if (bmp.Height > this.groupChatHistRtb.Height || bmp.Width > this.groupChatHistRtb.Width)
                           {
                               this.groupChatHistRtb.AppendText("（提示：图片过大！已经进行了压缩。）" + '\n');
                               Clipboard.SetDataObject(KiResizeImage2(bmp, this.groupChatHistRtb.Width, this.groupChatHistRtb.Height));//将数据置于系统剪贴板中
                           }
                           else
                           {
                               Clipboard.SetDataObject(bmp);
                           }
                           //  Clipboard.SetDataObject(KiResizeImage(bmp,100,100));//将数据置于系统剪贴板中
                           DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);//格式
                           if (this.groupChatHistRtb.CanPaste(dataFormat))
                               this.groupChatHistRtb.Paste(dataFormat);
                       }
                       catch (Exception exc)
                       {
                           MessageBox.Show("图片插入失败。" + exc.Message, "提示",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                    }));
                    break;
                default:
                    break;
            }
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private delegate void DoSomething();//全局代理

        private void groupChatSendBtn_Click(object sender, EventArgs e)//发送
        {
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.groupChat;
            msg.time = System.DateTime.Now.ToString();
            // msg.ipReceive = ipRecv;//因为这边是群聊，所以不需要对方的ip和port，如果是私聊的话，一定要加上
            // msg.portReceive = portRecv;
            msg.ipSend = MainForm._localIP;
            //MessageBox.Show(msg.ipSend);
            msg.portSend = MainForm._localPort;
            msg.content = this.groupChatContentRtb.Text;
            msg.type = MessType.text;
            /*
            if (msg.content.IndexOf("#_") > -1)
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
            this.groupChatContentRtb.Clear();
            // this.groupChatHistRtb.AppendText(msg.time + "我说：" + "\n");
            // this.groupChatHistRtb.AppendText(msg.content + "\n");
        }

        private void groupChatClear_Click(object sender, EventArgs e)//清空
        {
            this.groupChatContentRtb.Text = string.Empty;
        }

        private void GroupChat_Load(object sender, EventArgs e)
        {

        }

        private void groupChatClose_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }
        public void setMessage(string ip, int port, string recvContent)
        {
            this.Invoke(new DoSomething(delegate()
            {
                this.ipRecv = ip;
                this.portRecv = port;
                this.groupChatHistRtb.AppendText('\n' + "来自" + ip + "/" + port + "的消息：" + '\n');
                this.groupChatHistRtb.AppendText(System.DateTime.Now.ToString() + '\n');
                this.groupChatHistRtb.AppendText(recvContent + '\n');
                this.groupChatHistRtb.SelectionStart = this.groupChatHistRtb.TextLength;
                this.groupChatHistRtb.ScrollToCaret(); 
            }));
        }

        private void groupChatImageSendBtn_Click(object sender, EventArgs e)
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
                msg.order = OrderByTec.groupChat;
                msg.time = System.DateTime.Now.ToString();
                msg.content = sendFile.Substring(sendFile.LastIndexOf(@"\") + 1);
                msg.type = MessType.picture;
                msg.ipSend = MainForm._localIP;
                msg.portSend = MainForm._localPort;
                ftpUDParams param = new ftpUDParams(msg, sendFile, "PCtest");
                ftp.beginUploadFile(param);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        internal void setPicture(string ip, int port, string picName)
        {
            //throw new NotImplementedException();
            //ftpDLParams param = new ftpDLParams(picName, "PCtest", "D:\\" + picName);      
            // ftpDLParams param = new ftpDLParams(picName, "PCtest", "cache/picture/" + picName);
            ftpDLParams param = new ftpDLParams(picName, "PCtest", "ftpDownload/picture/" + picName);//*******************************************
            ftp.beginDownloadFile(param);
            ipRecv = ip;
            portRecv = port;
            count++;
        }

        internal void setVoice(string ip, int port, string voiceName)
        {
            //throw new NotImplementedException();
            ftpDLParams param = new ftpDLParams(voiceName, "PCtest", "cache/video/" + voiceName);//*****************************************
            ftp.beginDownloadFile(param);
            ipRecv = ip;
            portRecv = port;
        }

        private void startRecordBtn_Click(object sender, EventArgs e)
        {
            this.stopRecordBtn.Enabled = true;
            this.startRecordBtn.Enabled = false;
            //playVideo.beginRecord();
            rVoice.beginRecord();
        }

        private void stopRecordBtn_Click(object sender, EventArgs e)
        {
            this.startRecordBtn.Enabled = true;
            this.stopRecordBtn.Enabled = false;
           // string sendFile = playVideo.stopRecord();
            string sendFile=rVoice.stopRecord();
            //MessageBox.Show(sendFile);//cache\video\*****.amr
            int index = sendFile.LastIndexOf("\\");
            string fileName=sendFile.Substring(index+1);
            //MessageBox.Show(fileName);//****.amr
            //将转换好格式的音频上传到服务器
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.groupChat;
            msg.time = System.DateTime.Now.ToString();
           // msg.content = sendFile.Substring(sendFile.LastIndexOf(@"/") + 1);
            msg.content = fileName;//2016-6-8修改
            msg.type = MessType.voice;
            msg.ipSend = MainForm._localIP;
            msg.portSend = MainForm._localPort;
            ftpUDParams param = new ftpUDParams(msg, sendFile, "PCtest");
            //ftpUDParams param = new ftpUDParams(msg, fileName, "PCtest");
            ftp.beginUploadFile(param);
        }

        //http://huqiji.iteye.com/blog/2162871    修改图片大小
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {              
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
        //http://huqiji.iteye.com/blog/2162871    修改图片大小
        public static Bitmap KiResizeImage2(Bitmap bmp, int width,int height)
        {
            try
            {
               // if (bmp.Height > height || bmp.Width > width)
                //{
                    float scH = (float)bmp.Height / (float)height;
                    float scW = (float)bmp.Width/ (float)width;
                    float sc = (scH > scW) ? scH : scW;
                    int newW = (int)(Math.Floor((float)bmp.Width /sc));
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

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "17226161117808820160624154611.amr";//
            rVoice.playVoice(url);
        }
    }
}
