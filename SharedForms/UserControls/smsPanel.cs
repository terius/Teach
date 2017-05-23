using Common;
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
        sms chatItem;
        public smsPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            HorizontalScroll.Enabled = false;
            FireScrollEventOnMouseWheel = true;
            ControlAdded += SmsPanel_ControlAdded;
            Resize += SmsPanel_Resize;
            MouseEnter += SmsPanel_MouseEnter;
        }

        private void SmsPanel_MouseEnter(object sender, EventArgs e)
        {
            //  this.Focus();
        }



        private void SmsPanel_Resize(object sender, EventArgs e)
        {
            sms s;
            foreach (Control item in Controls)
            {
                s = (sms)item;
                if (s.IsMySelf)
                {
                    s.Location = new Point(Width - 420 - SystemInformation.VerticalScrollBarWidth - 5, s.Location.Y);
                }
            }
        }

        private void SmsPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            ScrollControlIntoView(e.Control);
        }


        public void AddMessage(ChatMessage messageInfo, bool isMySelf)
        {
            chatItem = new sms(messageInfo, isMySelf);
            if (isMySelf)
            {
                X = Width - chatItem.SizeWidth - SystemInformation.VerticalScrollBarWidth - 5;
            }
            else
            {
                X = 10;
            }

            Controls.Add(chatItem);
            chatItem.Location = new Point(X - HorizontalScroll.Value, LastY - VerticalScroll.Value);
            LastY += chatItem.Height;
            ScrollControlIntoView(Controls[Controls.Count - 1]);

        }
    }
}
