using System;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class ChatItem : UserControl
    {

        public string UserName { get; set; }
        public delegate void ChatItemSelectHandle(object sender, ChatItemSelectEventArgs e);
        public event ChatItemSelectHandle ChatItemSelect;
        private int newChatNumber;
        public ChatItem(string userName, string displayName)
        {
            InitializeComponent();
            this.labName.Text = displayName;
            UserName = userName;
            this.labName.MouseEnter += ChatItem_MouseEnter;
            this.labName.MouseLeave += ChatItem_MouseLeave;
            this.labName.MouseClick += ChatItem_MouseClick;
            this.cp2.MouseEnter += ChatItem_MouseEnter;
            this.cp2.MouseLeave += ChatItem_MouseLeave;
            this.cp2.MouseClick += ChatItem_MouseClick;
            this.labNewMsg.MouseEnter += ChatItem_MouseEnter;
            this.labNewMsg.MouseLeave += ChatItem_MouseLeave;
            this.labNewMsg.MouseClick += ChatItem_MouseClick;
            this.labNewMsg.Text = "";
        }

        private void CheckNewChat()
        {
            if (this.newChatNumber <=0)
            {
                labNewMsg.Text = "";
            }
            else
            {
                labNewMsg.Text = newChatNumber +"新消息";
            }
        }




        private void ChatItem_MouseEnter(object sender, System.EventArgs e)
        {
            if (Tag != null && Tag.ToString() == "selected")
            {
                return;
            }
            this.BackColor = System.Drawing.Color.FromArgb(211, 219, 206);
            // this.labName.ForeColor = System.Drawing.Color.DodgerBlue;
        }

        private void ChatItem_MouseLeave(object sender, System.EventArgs e)
        {
            if (Tag != null && Tag.ToString() == "selected")
            {
                return;
            }
            this.BackColor = System.Drawing.Color.White;
            // this.labName.ForeColor = System.Drawing.Color.DodgerBlue;
        }

        private void ChatItem_MouseClick(object sender, MouseEventArgs e)
        {
            SetSelect();

        }

        public void SetSelect()
        {
            foreach (Control control in this.Parent.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "selected")
                {
                    control.Tag = "";
                    control.BackColor = System.Drawing.Color.White;
                    break;
                }
            }

            this.BackColor = System.Drawing.Color.FromArgb(211, 219, 206);

            this.Tag = "selected";
            this.newChatNumber = 0;
            CheckNewChat();
            ChatItemSelect.Invoke(this, new ChatItemSelectEventArgs(this.labName.Text, UserName));
        }
    }

    public class ChatItemSelectEventArgs : EventArgs

    {
        private string _displayName;
        private string _userName;
        public ChatItemSelectEventArgs(string displayName, string userName)
        {
            this._displayName = displayName;
            this._userName = userName;
        }
        public string DisplayName
        {
            get { return _displayName; }
        }

        public string UserName
        {
            get { return _userName; }
        }
    }
}
