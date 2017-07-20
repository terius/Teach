using DevExpress.XtraBars.Alerter;
using Helpers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class sms : UserControl
    {
        ImageAttributes imgAtt;
        private Point[] piccyBounds;

        Brush blackBrush = Brushes.Black;
        Font titleFont = new Font("微软雅黑", 10F, FontStyle.Bold, GraphicsUnit.Point, 134);
        // Font contentFont = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        Image topimg = Resource1.lt;
        Image middleimg = Resource1.lm;
        Image bottomimg = Resource1.lb;
        Image topimgR = Resource1.rt;
        Image middleimgR = Resource1.rm;
        Image bottomimgR = Resource1.rb;
        Image imgTech = Resource1.老师;
        Image imgStu = Resource1.学生;
        string _message;//消息
        string _title; //标题
        bool _isMySelf;//是否为自己
        int _messageHeight;
        int _sizeHeight;
        public bool IsMySelf { get { return _isMySelf; } }
        public readonly int SizeWidth = 420;
        Image headIcon;
        bool messageIsString = false;
        string _downloadFileUrl;

        public sms(ChatMessage messageInfo, bool isMySelf)
        {
            _title = messageInfo.Title;
            _message = messageInfo.Message;
            _isMySelf = isMySelf;
            _downloadFileUrl = messageInfo.DownloadFileUrl;
            InitializeComponent();
            this.txtLink.Hide();
            if (messageInfo.MessageType == Common.MessageType.String)
            {
                messageIsString = true;
                this.txtSMS.Show();
                this.pictureBox1.Hide();
            }
            else
            {
                messageIsString = false;
                this.pictureBox1.Show();
                this.pictureBox1.Cursor = Cursors.Hand;
                this.pictureBox1.Click += PictureBox1_Click;
                switch (messageInfo.MessageType)
                {
                  
                    case Common.MessageType.Sound:
                        pictureBox1.Image = Resource1.声音;
                        break;
                    case Common.MessageType.Image:
                        pictureBox1.Image = Resource1.图片;
                        break;
                    case Common.MessageType.Video:
                        pictureBox1.Image = Resource1.视频;
                        break;
                    default:
                        break;
                }
                //  this.txtSMS.Hide();

                //  this.txtLink.Show();
                //  this.txtLink.LinkClicked += TxtLink_LinkClicked;
            }
            if (messageInfo.UserType == Common.ClientRole.Student)
            {
                headIcon = imgStu;
            }
            else
            {
                headIcon = imgTech;
            }


        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            saveFilePath = FileHelper.DownloadFile(_downloadFileUrl);
            if (!string.IsNullOrWhiteSpace(saveFilePath))
            {
                ShowNotify("下载成功!文件已下载到\r\n" + saveFilePath);
            }
        }

        string saveFilePath;
        private void TxtLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            saveFilePath = FileHelper.DownloadFile(_downloadFileUrl);
            if (!string.IsNullOrWhiteSpace(saveFilePath))
            {
                ShowNotify("下载成功!文件已下载到\r\n" + saveFilePath);
            }
        }

        AlertControl messagebox;
        private void ShowNotify(string msg)
        {
            if (messagebox == null)
            {
                messagebox = new AlertControl();
                messagebox.AutoFormDelay = 2000;
                //   messagebox.AllowHtmlText = true;
                messagebox.ShowPinButton = false;

                AlertButton btn1 = new AlertButton(Resource1.打开文件);// global::DXApplication1.Properties.Resources.open_16x16;);
                btn1.Hint = "打开文件";
                btn1.Name = "buttonOpen";
                messagebox.Buttons.Add(btn1);
                messagebox.ButtonClick += Messagebox_ButtonClick;
            }
            messagebox.Show(this.ParentForm, "信息", msg);
        }

        private void Messagebox_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "buttonOpen")
            {
                System.Diagnostics.Process.Start(saveFilePath);
            }
        }

        private void sms_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量 
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            piccyBounds = new Point[3];
            int ptop = 0;// 4;
            int pleft = 0;// 5;
            Rectangle rectArea;
            if (IsMySelf)
            {
                g.DrawString(_title, titleFont, blackBrush, new PointF(pleft, ptop));
            }
            else
            {
                g.DrawString(_title, titleFont, blackBrush, new PointF(pleft + 40, ptop));
            }
            ptop += 20;

            if (IsMySelf)
            {
                rectArea = new Rectangle(pleft + 388, _sizeHeight - 32, 32, 32);
                g.DrawImage(headIcon, rectArea);
            }
            else
            {
                rectArea = new Rectangle(pleft, _sizeHeight - 32, 32, 32);
                g.DrawImage(headIcon, rectArea);
                pleft += 32;
            }
            rectArea = new Rectangle(pleft, ptop, 388, 17);
            if (IsMySelf)
            {
                g.DrawImage(topimgR, rectArea);
            }
            else
            {
                g.DrawImage(topimg, rectArea);
            }
            ptop += 17;
            piccyBounds[0] = new Point(pleft, ptop);
            piccyBounds[1] = new Point(388 + pleft, ptop);
            piccyBounds[2] = new Point(pleft, ptop + _messageHeight);
            if (IsMySelf)
            {
                g.DrawImage(middleimgR, piccyBounds, new Rectangle(0, 0, 388, _messageHeight), GraphicsUnit.Pixel, imgAtt);
            }
            else
            {
                g.DrawImage(middleimg, piccyBounds, new Rectangle(0, 0, 388, _messageHeight), GraphicsUnit.Pixel, imgAtt);
            }
            ptop += _messageHeight;
            rectArea = new Rectangle(pleft, ptop, 388, 17);
            if (IsMySelf)
            {
                g.DrawImage(bottomimgR, rectArea);
            }
            else
            {
                g.DrawImage(bottomimg, rectArea);
            }
        }

        private void innerSize()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);
            var textSize = this.CreateGraphics().MeasureString(_message, txtSMS.Font);
            // var textSize = this.CreateGraphics().MeasureString(_message, messageIsString ? txtSMS.Font : txtLink.Font);
            int count = (int)Math.Floor(textSize.Width / 389) + (textSize.Width % 389 == 0 ? 0 : 1);
            _messageHeight = count * 20 + 10;
            _sizeHeight = 20 + 17 * 2 + _messageHeight;
            Size = new Size(388 + 32, _sizeHeight + 5);

            if (IsMySelf)
            {
                txtSMS.Location = new Point(7, 37);
                txtSMS.BackColor = Color.FromArgb(198, 225, 252);
                if (messageIsString)
                {


                }
                else
                {

                    //  this.pictureBox1.Location = new Point(7 + txtSMS.Width, 37);
                    //txtLink.Location = new Point(7, 37);
                    //txtLink.BackColor = Color.FromArgb(198, 225, 252);
                }

            }
            else
            {
                txtSMS.Location = new Point(42, 37);
                txtSMS.BackColor = Color.FromArgb(244, 244, 244);
                if (messageIsString)
                {

                }
                else
                {
                    //  this.pictureBox1.Location = new Point(42 + txtSMS.Width, 37);
                    //  txtLink.Location = new Point(42, 37);
                    //  txtLink.BackColor = Color.FromArgb(244, 244, 244);
                }


            }
            txtSMS.Size = new Size(388 - 10 - 5, _messageHeight);
            txtSMS.Text = _message;
            if (messageIsString)
            {

            }
            else
            {
                this.pictureBox1.Location = new Point(388 - 50, 35);
                //txtLink.Size = new Size(388 - 10 - 5, _messageHeight);
                //txtLink.Text = _message;
            }
        }

        private void sms_Load(object sender, EventArgs e)
        {
            innerSize();

        }
    }
}
