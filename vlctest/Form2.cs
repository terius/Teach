using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace vlctest
{
    public partial class Form2 : DevExpress.XtraEditors.XtraForm
    {
        private IList<MyPanel> pans;
        public Form2()
        {
            InitializeComponent();
            pans = new List<MyPanel>();
            MyPanel mypan = new MyPanel();
            mypan.Panel = new smsPanel();
            mypan.Name = mypan.Panel.Name = "pan1";
            mypan.Panel.Dock = DockStyle.Fill;
            mypan.Panel.BackColor = Color.Green;
            this.Controls.Add(mypan.Panel);
            pans.Add(mypan);

             mypan = new MyPanel();
            mypan.Panel = new smsPanel();
            mypan.Name = mypan.Panel.Name = "pan2";
            mypan.Panel.Dock = DockStyle.Fill;
            mypan.Panel.BackColor = Color.Blue;
            this.Controls.Add(mypan.Panel);
            pans.Add(mypan);

            
        }



        int index = 1;
      //  MyPanel selectPanel;
        private void button1_Click(object sender, EventArgs e)
        {
            bool ism =  index % 2 == 0 ? true : false;
            panel1.AddMessage("王菲 (" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")", textBox1.Text.Trim(), ism);
            index++;
         
            //我爱祖国天安们和人民我爱祖国天安们和人民我爱祖国天安们和
            //测试测试测试测试测试测测试测试测试测试测试测测测试测试试
            //1111111111111111111111111111
        }

        int lastY = 10;
        int inum = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.Red;
            panel.Size = new Size(30, 30);
            Label lab = new Label();
            lab.Text = inum.ToString();
            panel.Controls.Add(lab);

            //  panel.Location = new Point(0, lastY - panel1.VerticalScroll.Value);
            panel.Dock = DockStyle.Top;
            lastY += panel.Height + 10;
            inum++;
            panel1.Controls.Add(panel);

            panel.BringToFront();
            //  panel1.VerticalScroll.Value = panel.VerticalScroll.Maximum;
            // panel1.AutoScrollMinSize = new Size(0, lastY);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (MyPanel item in pans)
            {
                if (item.Name == "pan1")
                {
                    panel1 = item.Panel;
                    item.Panel.BringToFront();
                    break;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (MyPanel item in pans)
            {
                if (item.Name == "pan2")
                {
                    panel1 = item.Panel;
                    item.Panel.BringToFront();
                    break;
                }
            }
        }
    }

    public class MyPanel
    {
       // public int LastY { get; set; }
        public string Name { get; set; }
        public smsPanel Panel { get; set; }
    }
}
