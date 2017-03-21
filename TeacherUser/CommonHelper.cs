using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherUser
{
    public class CommonHelper
    {
        public static void SetButtonHoverLeave(Control control)
        {
            if (control.GetType() == typeof(Button))
            {
                ((Button)control).MouseHover +=(sender,e)=> ((Button)sender).BackColor= Color.FromArgb(0, 240, 59);
                ((Button)control).MouseLeave += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 201, 59);
            }
        }



       
    }
}
