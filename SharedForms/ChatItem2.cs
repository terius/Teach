using CCWin.SkinControl;
using Model;

namespace SharedForms
{
    public class ChatItem2 : ChatListSubItem
    {
        public ChatItem2(ChatListItem ParentItem, AddChatRequest ChatRequest)
        {
           // this.Bounds = new System.Drawing.Rectangle(0, 27, 247, 53);
            this.DisplayName = ChatRequest.DisplayName;
            switch (ChatRequest.ChatType)
            {
                case Common.ChatType.PrivateChat:
                    switch (ChatRequest.UserType)
                    {
                        case Common.ClientRole.Teacher:
                        case Common.ClientRole.Assistant:
                            this.HeadImage = Resource1.老师;
                            break;
                        case Common.ClientRole.Student:
                            this.HeadImage = Resource1.学生;
                            break;
                        default:
                            break;
                    }
                 
                    break;
                case Common.ChatType.GroupChat:
                    break;
                case Common.ChatType.TeamChat:
                    break;
                default:
                    break;
            }
           
            //   this.HeadRect = new System.Drawing.Rectangle(5, 33, 40, 40);
            this.ID = 1;
            this.IpAddress = null;
            //   this.IsTwinkle = false;
            //   this.IsTwinkleHide = false;
            //   this.IsVip = false;
            this.NicName = "";
            this.OwnerListItem = ParentItem;
            this.PersonalMsg = "";
            //  this.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            // this.QQShow = null;
            //  this.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            this.Tag = ChatRequest.UserName;
            ParentItem.SubItems.Add(this);
            // this.TcpPort = 0;
            // this.UpdPort = 0;
           
        }
    }
}
