using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace DXApplication1
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        sms s;
        sms2 s2;
        private void Form1_Load(object sender, EventArgs e)
        {

            //Graphics g = this.panelControl1.CreateGraphics(); //创建画板,这里的画板是由Form提供的.
            //Pen p = new Pen(Color.Red, 2);//定义了一个蓝色,宽度为的画笔
            //g.DrawLine(p, 10, 10, 110, 110);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            //g.DrawRectangle(p, 10, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            //g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        int x = 10;
        int y = 10;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  s = new sms("asdasdas发水电费水电费水电费" + DateTime.Now.ToLongTimeString());
            s = new sms("发水电费水电费水电费sda东水电费水电费水电费水电费水电费水电费沙发斯蒂芬" + DateTime.Now.ToLongTimeString());
            s.Location = new Point(x, y);
            //   s.Dock = DockStyle.Top;
            //   s.BringToFront();
            this.panel1.Controls.Add(s);
            y += s.Height;
          //  x += s.Height;
          
            this.panel1.AutoScrollMinSize = new Size(0, y);
           // panel1.AutoScrollPosition = new Point(x, y);
        }
    }
}
