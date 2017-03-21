using System.Drawing;
using System.Windows.Forms;

namespace StudentUser
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
