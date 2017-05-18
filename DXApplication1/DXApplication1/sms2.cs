using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class sms2 : UserControl
    {
        public sms2(string message)
        {
            InitializeComponent();
            this.labelControl1.Text = message;
        }
    }
}
