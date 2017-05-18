using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vlctest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        sms s;
        sms2 s2;
        int x = 10;
        int y = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            //  s = new sms("asdasdas发水电费水电费水电费" + DateTime.Now.ToLongTimeString());
            s2 = new sms2("发水电费水电费水电费sda" + DateTime.Now.ToLongTimeString());
            //  

            //   s.BringToFront();
            this.panel1.Controls.Add(s2);
            s2.Location = new Point(x, y);
            //  s2.Dock = DockStyle.Top;
            // s2.SendToBack();
            this.Text = panel1.VerticalScroll.Value.ToString();
            y += s2.Height - panel1.VerticalScroll.Value;
            //  x += s.Height;
            panel1.AutoScrollOffset = new Point(0, y);
          
            // this.panel1.AutoScrollMinSize = new Size(0, y);
            // panel1.AutoScrollPosition = new Point(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.Red;
            panel.Size = new Size(30, 30);
            panel1.Controls.Add(panel);
            panel.Location = new Point(0, 0);
            panel.BringToFront();
        }
    }
}
