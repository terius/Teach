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
        public ChatItem3()
        {

        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }

        public ChatType ChatType { get; set; }

        public ChatItem3(MyListView source, string userName, string displayName, ChatType chatType, ClientRole userType)
        {
          
            this.Text = displayName;
            switch (chatType)
            {
                case ChatType.PrivateChat:
                    switch (userType)
                    {
                        case ClientRole.Teacher:
                        case ClientRole.Assistant:
                            this.ImageIndex = 3;
                            break;
                        case ClientRole.Student:
                            this.ImageIndex = 2;
                            break;
                        default:
                            break;
                    }
                    this.Group = source.Groups[2];

                    break;
                case ChatType.GroupChat:
                    this.ImageIndex = 0;
                    this.Group = source.Groups[0];
                    break;
                case ChatType.TeamChat:
                    this.ImageIndex = 1;
                    this.Group = source.Groups[1];
                    break;
                default:
                    break;
            }
            this.UserName = userName;
            this.DisplayName = displayName;
            this.ChatType = chatType;
            source.Items.Add(this);
        }

        public ChatStore GetChatStore()
        {
            return GlobalVariable.ChatList.FirstOrDefault(d => d.ChatUserName == UserName);
        }
    }
}
