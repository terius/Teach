using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace NewTeacher.Controls
{
    public partial class StudentScreen : UserControl
    {
        public string UserName { get; set; }
        public StudentScreen(ScreenCaptureInfo info)
        {
            InitializeComponent();
            this.picScreen.Image = info.Image;
            this.labName.Text = info.DisplayName;
            this.UserName = info.UserName;
        }

        public void UpdateScreen(Image img)
        {
            this.picScreen.Image = img;
        }
    }
}
