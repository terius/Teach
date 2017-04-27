using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class BlackScreen : Form, IMessageFilter
    {
        bool _isSlient = false;
        Cls.UserActivityHook actHook;
        public BlackScreen(bool isSlient)
        {
            InitializeComponent();
            _isSlient = isSlient;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void BlockInput([In, MarshalAs(UnmanagedType.Bool)]bool fBlockIt);

        //[DllImport("WinLockDll.dll", CallingConvention = CallingConvention.StdCall)]
        //public static extern int CtrlAltDel_Enable_Disable(bool bEnableDisable);

        private void BlackScreen_Load(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);//***********   加上这两句可以实现窗口全屏，并隐藏任务栏
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = _isSlient ? Color.Black : Color.White;
            if (!_isSlient)
            {
                this.Opacity = 0;
            }
            this.ShowInTaskbar = false;
            this.SetVisibleCore(true);
            DisableMouseAndKeyboard();
          //  DisableMouse();
          //   BlockInput(true);

            //   NativeMethods.BlockInput(TimeSpan.FromSeconds(30));

        }

        private void DisableMouseAndKeyboard()
        {
            actHook = new Cls.UserActivityHook();
            actHook.Start();
            System.Diagnostics.Process.Start("d.bat");
            BlockInput(true);
        }

        public void EnableMouseAndKeyboard()
        {
            if (actHook != null)
            {
                actHook.Stop();
            }
            BlockInput(false);
            System.Diagnostics.Process.Start("e.bat");
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




}
