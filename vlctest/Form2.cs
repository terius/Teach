using System;
using System.Windows.Forms;

namespace vlctest
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            PictureBox box = new PictureBox();
            box.Width = 300;
            box.Height = 200;
            box.Image = Properties.Resources.Send;
            box.Margin = new Padding(10, 10, 10, 10);

            this.flowLayoutPanel1.Controls.Add(box);
        }
    }
}
