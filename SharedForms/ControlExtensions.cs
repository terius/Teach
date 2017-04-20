using System;
using System.Drawing;
using System.Windows.Forms;


namespace SharedForms
{
    public static class ControlExtensions
    {

        public static void SetButtonHoverLeave(this Control control)
        {
            if (control.GetType() == typeof(Button))
            {
                control.MouseHover += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 240, 59);
                control.MouseLeave += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 201, 59);
            }
        }

        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }


      
    }
}
