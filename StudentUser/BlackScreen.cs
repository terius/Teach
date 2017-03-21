using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class BlackScreen : Form
    {
        public BlackScreen()
        {
            InitializeComponent();
        }

        private void BlackScreen_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);//***********   加上这两句可以实现窗口全屏，并隐藏任务栏
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.ShowInTaskbar = false;
            this.SetVisibleCore(true);//************
        }
    }
}
