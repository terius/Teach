using System;
using System.Windows.Forms;

namespace TeacherUser.controls
{
    public partial class ChatItem : UserControl
    {

        public string UserName { get; set; }
        public delegate void ChatItemSelectHandle(object sender, ChatItemSelectEventArgs e);
        public event ChatItemSelectHandle ChatItemSelect;
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
        }






        private void ChatItem_MouseEnter(object sender, System.EventArgs e)
        {
            if (Tag != null && Tag.ToString() == "selected")
            {
                return;
            }
            this.BackColor = System.Drawing.Color.LightGray;
            this.labName.ForeColor = System.Drawing.Color.DodgerBlue;
        }

        private void ChatItem_MouseLeave(object sender, System.EventArgs e)
        {
            if (Tag != null && Tag.ToString() == "selected")
            {
                return;
            }
            this.BackColor = System.Drawing.Color.White;
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

            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.labName.ForeColor = System.Drawing.Color.White;
            this.Tag = "selected";


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
