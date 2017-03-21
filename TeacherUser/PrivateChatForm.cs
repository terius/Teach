using System.Windows.Forms;

namespace TeacherUser
{
    public partial class PrivateChatForm : Form
    {
        private string _receieveName;
        public PrivateChatForm(string receName)
        {
            _receieveName = receName;
            InitializeComponent();
          
        }
    }
}
