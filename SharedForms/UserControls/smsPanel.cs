using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class smsPanel : XtraScrollableControl
    {
        private int _lastY = 0;

        public int LastY
        {
            get
            {
                return _lastY;
            }

            set
            {
                _lastY = value;
            }
        }

        int X = 10;
        //   sms chatItem;
        public smsPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            HorizontalScroll.Enabled = false;
            FireScrollEventOnMouseWheel = true;
            //  ControlAdded += SmsPanel_ControlAdded;
            //  Resize += SmsPanel_Resize;
            //  MouseEnter += SmsPanel_MouseEnter;
        }

        private void SmsPanel_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }



        private void SmsPanel_Resize(object sender, EventArgs e)
        {
            sms s;
            foreach (Control item in Controls)
            {
                s = (sms)item;
                if (s.IsMySelf)
                {
                    s.Location = new Point(Width - 400 - 20, s.Location.Y);
                }
            }
        }

        private void SmsPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            ScrollControlIntoView(e.Control);
        }


        public void AddMessage(string title, string message, bool isMySelf)
        {
            sms chatItem = new sms(title, message, isMySelf);
            if (isMySelf)
            {
                X = Width - 400 - 20;
            }
            else
            {
                X = 10;
            }
            // var height = Controls.Count > 0 ? Controls[Controls.Count - 1].Location.Y + Controls[Controls.Count - 1].Height : 10;
            chatItem.Location = new Point(X, LastY);// LastY - VerticalScroll.Value

            Controls.Add(chatItem);
            chatItem.BringToFront();
            LastY += 82;
            //   LastY += chatItem.Height;
        }
    }
}
