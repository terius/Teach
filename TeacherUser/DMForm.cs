using DMSkin.Controls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class DMForm : DMSkin.Main
    {
        public DMForm()
        {
            InitializeComponent();
            this.panel1.Paint += Panel1_Paint;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(this.Text, Fo, NoSelectSb, 3, 5);
        }

        Font Fo = new Font("微软雅黑", 12);
        SolidBrush NoSelectSb = new SolidBrush(Color.White);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality; //高质量
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            
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

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); //释放鼠标捕捉
                SendMessage(Handle, 0xA1, 0x02, 0);
            }
        }
    }



}
