using DMSkin.Controls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class DMForm : DMSkin.Main
    {
        public DMForm()
        {
            InitializeComponent();
        }


        Font Fo = new Font("微软雅黑", 12);
        Pen p = new Pen(Color.FromArgb(236, 236, 236), 4);
        SolidBrush NoSelectSb = new SolidBrush(Color.White);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality; //高质量
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            e.Graphics.DrawString(this.Text, new Font("微软雅黑", 12), new SolidBrush(Color.White), 3, 5);
        }

        private void dmButtonCloseLight1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dmButtonMinLight1_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dmButtonMax1_Click(object sender, System.EventArgs e)
        {
            WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void metroTile1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("aaaaaa");
        }

        private void metroToolBar1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var list = (MetroToolBar)sender;
            MessageBox.Show(list.Items[list.SelectedIndex].Text);
        }

        private void DMForm_Load(object sender, System.EventArgs e)
        {
            
        }
    }



}
