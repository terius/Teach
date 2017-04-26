using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class BlackScreen : Form, IMessageFilter
    {
        bool _isSlient = false;
        public BlackScreen(bool isSlient)
        {
            InitializeComponent();
            _isSlient = isSlient;
        }

        private void BlackScreen_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);//***********   加上这两句可以实现窗口全屏，并隐藏任务栏
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = _isSlient ? Color.Black : Color.White;
            //if (!_isSlient)
            //{
            //    this.Opacity = 0;
            //}
            this.ShowInTaskbar = false;
            this.SetVisibleCore(true);//************
            NativeMethods.BlockInput(TimeSpan.FromSeconds(20));
        }


        Rectangle BoundRect;
        Rectangle OldRect = Rectangle.Empty;

        private void EnableMouse()
        {
            Cursor.Clip = OldRect;
            Cursor.Show();
            Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x203) return true;
            if (m.Msg == 0x204 || m.Msg == 0x205 || m.Msg == 0x206) return true;
            return false;
        }
        private void DisableMouse()
        {
            OldRect = Cursor.Clip;
            // Arbitrary location.
            BoundRect = new Rectangle(50, 50, 1, 1);
            Cursor.Clip = BoundRect;
            Cursor.Hide();
            Application.AddMessageFilter(this);
        }
    }

    public partial class NativeMethods
    {

        /// Return Type: BOOL->int
        ///fBlockIt: BOOL->int
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);

        public static void BlockInput(TimeSpan span)
        {
            try
            {
                NativeMethods.BlockInput(true);
                Thread.Sleep(span);
            }
            finally
            {
                NativeMethods.BlockInput(false);
            }
        }

    }


}
