using System.Windows.Forms;

namespace TeacherUser.controls
{
    public partial class ChatItem : UserControl
    {
        
        public string UserName { get; set; }
        public ChatItem(string userName,string displayName)
        {
            InitializeComponent();
            this.labName.Text = displayName;
            UserName = userName;
           
        }

      

        private void panel1_MouseEnter(object sender, System.EventArgs e)
        {
            this.panel1.BackColor = System.Drawing.Color.LightGray;
        }

        private void panel1_MouseLeave(object sender, System.EventArgs e)
        {
            this.panel1.BackColor = System.Drawing.Color.White;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("ok");
            this.panel1.BackColor = System.Drawing.Color.LightGray;
        }
    }
}
