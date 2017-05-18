using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace vlctest
{
    public partial class sms : UserControl
    {
        ImageAttributes imgAtt;
        private Point[] piccyBounds;

        Brush blackBrush = Brushes.Black;
        Font titleFont = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Font contentFont = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        Image topimg = Properties.Resources.lt;
        Image middleimg = Properties.Resources.lm;
        Image bottomimg = Properties.Resources.lb;
        Image topimgR = Properties.Resources.rt;
        Image middleimgR = Properties.Resources.rm;
        Image bottomimgR = Properties.Resources.rb;
        string message;
        int messageHeight;
        public sms(string _message)
        {
            message = _message;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);
            SetHeight();
            //  this.Size = new Size(300, 50);
        }

        private void SetHeight()
        {
            int textLen = message.Length;
            int count = textLen / 27 + (textLen % 27 == 0 ? 0 : 1);
            messageHeight = count * 18 + 18;
            this.Size = new Size(200, messageHeight + 20);
        }

        private void sms_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.
            //Pen p = new Pen(Color.Red, 2);//定义了一个蓝色,宽度为的画笔
            //g.DrawLine(p, 10, 10, 110, 110);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            //g.DrawRectangle(p, 10, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            //g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            //g.DrawString(message, titleFont, blackBrush, 10f, 2f);

            //base.OnPaint(e);
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(this.BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量 
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            //Graphics g = e.Graphics;


            piccyBounds = new Point[3];

            g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            int ptop = 4;

            Rectangle rectImg = new Rectangle(0, 0, 388, 17);
            string lxrxm, stime, scontent, lxrdh, title;
            int leftR = this.ClientRectangle.Width - 388 - 5;
            Random rd = new Random(100);
            int ran = DateTime.Now.Second * 10;
            int leftOrRight = 0;
            SizeF textSize;


            lxrxm = "联系人姓名";
            stime = DateTime.Now.ToLongTimeString();
            scontent = message;
            lxrdh = "12235435546";

            title = lxrxm + "(" + lxrdh + ")";
            int pleft = 5;


            Rectangle rectArea = new Rectangle(pleft, ptop, 388, 17);
            g.DrawImage(topimg, rectArea);


            ptop += 17;
            piccyBounds[0] = new Point(pleft, ptop);
            piccyBounds[1] = new Point(388 + pleft, ptop);
            piccyBounds[2] = new Point(pleft, ptop + messageHeight);




            g.DrawImage(middleimg, piccyBounds, rectImg, GraphicsUnit.Pixel, imgAtt);


            textSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, blackBrush, new PointF(pleft + 10, ptop));
            g.DrawString(stime, contentFont, blackBrush, new PointF(pleft + 10 + textSize.Width, ptop));
            ptop += 18;
            rectArea = new Rectangle(pleft + 10, ptop, 388, messageHeight - 18);

            g.DrawString(scontent, contentFont, blackBrush, rectArea);
            ptop += messageHeight - 18;
            rectArea = new Rectangle(pleft, ptop, 388, 17);
            g.DrawImage(bottomimg, rectArea);
            ptop += 23;

            this.Size = new Size(400, ptop);


            e.Graphics.DrawImage(bmp, 0, 0);

            // this.AutoScrollMinSize = new Size(0, ptop);
        }
    }
}
