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
        Font titleFont = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Font contentFont = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        Image topimg = Resource1.lt;
        Image middleimg = Resource1.lm;
        Image bottomimg = Resource1.lb;
        Image topimgR = Resource1.rt;
        Image middleimgR = Resource1.rm;
        Image bottomimgR = Resource1.rb;
        string _message;
        string _title;
        bool _isMySelf;
        int _messageHeight;
        public bool IsMySelf { get { return _isMySelf; } }
        public sms(string title, string message, bool isMySelf)
        {
            _title = title;
            _message = message;
            _isMySelf = isMySelf;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);
            SetHeight();
        }

        private void SetHeight()
        {
            int textLen = _message.Length;
            int count = textLen / 27 + (textLen % 27 == 0 ? 0 : 1);
            _messageHeight = count * 18 + 18;
          //  this.Size = new Size(400, _messageHeight + 45);
            this.BackColor = Color.Green;
            //TextBox lab = new TextBox();
            //lab.BackColor = this.BackColor;
            //lab.ForeColor = Color.Blue;
            //lab.Location = new Point(20, 17);
            //lab.Text = DateTime.Now.ToLongTimeString();
            //lab.BorderStyle = BorderStyle.None;
            //this.Controls.Add(lab);
        }

        private void sms_Paint(object sender, PaintEventArgs e)
        {
            this.Parent.Parent.Text = DateTime.Now.ToLongTimeString();

            //base.OnPaint(e);
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(this.BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量 
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            piccyBounds = new Point[3];

        //    g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            int ptop = 4;
            int pleft = 5;
            Rectangle rectArea = new Rectangle(pleft, ptop, 388, 17);
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
                g.DrawImage(middleimgR, piccyBounds, new Rectangle(0, 0, 388, 17), GraphicsUnit.Pixel, imgAtt);
            }
            else
            {
                g.DrawImage(middleimg, piccyBounds, new Rectangle(0, 0, 388, 17), GraphicsUnit.Pixel, imgAtt);
            }
            g.DrawString(_title, titleFont, blackBrush, new PointF(pleft + 10, ptop));
            ptop += 18;
            rectArea = new Rectangle(pleft + 10, ptop, 388, _messageHeight - 18);
            g.DrawString(_message, contentFont, blackBrush, rectArea);
            ptop += _messageHeight - 18;
            rectArea = new Rectangle(pleft, ptop, 388, 17);
            if (IsMySelf)
            {
                g.DrawImage(bottomimgR, rectArea);
            }
            else
            {
                g.DrawImage(bottomimg, rectArea);
            }
           

            e.Graphics.DrawImage(bmp, 0, 0);
            //this.Size = new Size(400, _messageHeight + 45);
        }
    }
}
