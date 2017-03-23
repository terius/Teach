using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace TeacherUser.Controls
{
    public partial class SMSPanelEx : UserControl
    {
        DataSet ds;
        string xm, sjh;
        public SMSPanelEx(DataSet _ds, string _xm, string _sjh)
        {
            InitializeComponent();
            ds = _ds;
            xm = _xm;
            sjh = _sjh;
            //  content += content;
            //  content += content;
            //  content += content;
            //    content += content;
            //  createDS();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);



        }

       
        ImageAttributes imgAtt;
        private Point[] piccyBounds;

        Brush blackBrush = Brushes.Black;
        Font titleFont = new Font("Œ¢»Ì—≈∫⁄", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134 )));
        Font contentFont = new Font("Œ¢»Ì—≈∫⁄", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));

       
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(this.BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality; //∏ﬂ÷ ¡ø 
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //∏ﬂœÒÀÿ∆´“∆÷ ¡ø
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
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                lxrxm = dr["lxrxm"].ToString();
                stime = dr["dxsj"].ToString();
                scontent = dr["dxnr"].ToString();
                lxrdh = dr["dxlxrdh"].ToString();
                leftOrRight = dr["sfzt"].ToString() == " ’" ? 0 : 1;
                title = leftOrRight == 0 ? lxrxm + "(" + lxrdh + ")" : xm + "(" + sjh + ")";
                int pleft = 5;
                int textLen = scontent.Length;
                int count = textLen / 27 + (textLen % 27 == 0 ? 0 : 1);

                int MiddleHeight = count * 18 + 18;//
                if (leftOrRight == 0)
                {
                    Rectangle rectArea = new Rectangle(pleft, ptop, 388, 17);
                    g.DrawImage(topimg, rectArea);


                    ptop += 17;
                    piccyBounds[0] = new Point(pleft, ptop);
                    piccyBounds[1] = new Point(388 + pleft, ptop);
                    piccyBounds[2] = new Point(pleft, ptop + MiddleHeight);




                    g.DrawImage(middleimg, piccyBounds, rectImg, GraphicsUnit.Pixel, imgAtt);


                    textSize = g.MeasureString(title, titleFont);
                    g.DrawString(title, titleFont, blackBrush, new PointF(pleft + 10, ptop));
                    g.DrawString(stime, contentFont, blackBrush, new PointF(pleft + 10 + textSize.Width, ptop));
                    ptop += 18;
                    rectArea = new Rectangle(pleft + 10, ptop, 388, MiddleHeight - 18);

                    g.DrawString(scontent, contentFont, blackBrush, rectArea);
                    ptop += MiddleHeight - 18;
                    rectArea = new Rectangle(pleft, ptop, 388, 17);
                    g.DrawImage(bottomimg, rectArea);
                    ptop += 23;
                }
                else
                {
                    pleft = leftR;
                    Rectangle rectArea = new Rectangle(pleft, ptop, 388, 17);
                    g.DrawImage(topimgR, rectArea);


                    ptop += 17;
                    piccyBounds[0] = new Point(pleft, ptop);
                    piccyBounds[1] = new Point(388 + pleft, ptop);
                    piccyBounds[2] = new Point(pleft, ptop + MiddleHeight);




                    g.DrawImage(middleimgR, piccyBounds, rectImg, GraphicsUnit.Pixel, imgAtt);

                    textSize = g.MeasureString(title, titleFont);
                    g.DrawString(title, titleFont, blackBrush, new PointF(pleft + 10, ptop));
                    g.DrawString(stime, contentFont, blackBrush, new PointF(pleft + 10 + textSize.Width, ptop));
                    ptop += 18;
                    rectArea = new Rectangle(pleft + 10, ptop, 388, MiddleHeight - 18);
                    g.DrawString(scontent, contentFont, blackBrush, rectArea);
                    ptop += MiddleHeight - 18;
                    rectArea = new Rectangle(pleft, ptop, 388, 17);
                    g.DrawImage(bottomimgR, rectArea);
                    ptop += 23;
                }
            }

            e.Graphics.DrawImage(bmp, 0, 0);

            this.AutoScrollMinSize = new Size(0, ptop);

        }

      


    }
}
