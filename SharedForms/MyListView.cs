using Common;
using Model;
using System.Linq;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class MyListView : ListView
    {
        public MyListView()
        {
            InitializeComponent();
        }
    }


    public class ChatItem3 : ListViewItem
    {
  

        public string UserName { get; set; }


        public ChatStore GetChatStore()
        {
            return GlobalVariable.ChatList.FirstOrDefault(d => d.ChatUserName == UserName);
        }
    }
}
