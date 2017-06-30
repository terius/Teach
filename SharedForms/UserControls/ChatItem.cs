using Common;
using DevExpress.XtraNavBar;
using System.Linq;

namespace SharedForms
{
    public class ChatItem : NavBarItem
    {
        public ChatItem()
        {

        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }

        public ChatType ChatType { get; set; }

        public ChatItem(NavBarControl source, string userName, string displayName, ChatType chatType, ClientRole userType)
        {
            Name = "item_" + userName;
            Caption = displayName;
            switch (chatType)
            {
                case ChatType.PrivateChat:
                    switch (userType)
                    {
                        case ClientRole.Teacher:
                        case ClientRole.Assistant:
                            SmallImage = Resource1.老师24;
                            break;
                        case ClientRole.Student:
                            SmallImage = Resource1.学生24;
                            break;
                        default:
                            break;
                    }
                    source.Groups[2].ItemLinks.Add(this);
                    //  this.paren = source.Groups[2];

                    break;
                case ChatType.GroupChat:
                    SmallImage = Resource1.所有人24;
                    source.Groups[0].ItemLinks.Add(this);
                    //   this.Group = source.Groups[0];
                    break;
                case ChatType.TeamChat:
                    SmallImage = Resource1.群组24;
                    source.Groups[1].ItemLinks.Add(this);
                    //  this.Group = source.Groups[1];
                    var childList = GlobalVariable.GetTeamMemberDisplayNames(userName);
                    Caption = displayName + " 【" + childList.Count + "】";
                    Hint= string.Join("\r\n", childList);
                    // this.ToolTipText = string.Join("\r\n", childList);
                    break;
                default:
                    break;
            }
            this.UserName = userName;
            this.DisplayName = displayName;
            this.ChatType = chatType;
           
            //  this.AppearanceHotTracked.BorderColor = System.Drawing.Color.Black;
            //    this.AppearanceHotTracked.Options.UseBorderColor = true;
            source.Items.Add(this);
        }

        public ChatStore GetChatStore()
        {
            return GlobalVariable.ChatList.FirstOrDefault(d => d.ChatUserName == UserName);
        }

        public string GetTeamMemUserNames()
        {
            var chat = GetChatStore();
            return string.Join(",", chat.TeamMembers.Select(d => d.UserName));
        }
    }
}
