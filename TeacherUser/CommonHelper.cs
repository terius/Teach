using DMSkin.Metro.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace TeacherUser
{
    public class CommonHelper
    {
        public static void SetButtonHoverLeave(Control control)
        {
            if (control.GetType() == typeof(Button))
            {
                control.MouseHover += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 240, 59);
                control.MouseLeave += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 201, 59);
            }
        }

        public static void SetMetroTileHoverLeave(MetroTile control)
        {
            if (control.GetType() == typeof(MetroTile))
            {
                control.MouseEnter += (sender, e) => ((MetroTile)sender).BackColor = Color.SteelBlue;
                control.MouseLeave += (sender, e) => ((MetroTile)sender).BackColor = Color.Transparent;
            }
        }


    }
}
