using CCWin.SkinControl;
using Common;
using Model;

namespace SharedForms
{
    public class ChatItem2 : ChatListSubItem
    {
        public ChatItem2(ChatListItem ParentItem, AddChatRequest ChatRequest)
        {
            CreateChatItem(ParentItem, ChatRequest.UserName,
                ChatRequest.DisplayName, ChatRequest.ChatType, ChatRequest.UserType);
        }


        public ChatItem2(ChatListItem ParentItem, ChatStore chatStore)
        {
            CreateChatItem(ParentItem, chatStore.ChatUserName,
                chatStore.ChatDisplayName, chatStore.ChatType, chatStore.UserType);
        }


        private void CreateChatItem(ChatListItem ParentItem,
            string userName,string displayName, ChatType type,ClientRole userType )
        {
            this.DisplayName = displayName;
            switch (type)
            {
                case ChatType.PrivateChat:
                    switch (userType)
                    {
                        case ClientRole.Teacher:
                        case ClientRole.Assistant:
                            this.HeadImage = Resource1.老师;
                            break;
                        case ClientRole.Student:
                            this.HeadImage = Resource1.学生;
                            break;
                        default:
                            break;
                    }

                    break;
                case ChatType.GroupChat:
                    this.HeadImage = Resource1.所有人;
                    break;
                case ChatType.TeamChat:
                    this.HeadImage = Resource1.群聊;
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
            this.Tag = userName;
            ParentItem.SubItems.Add(this);
            // this.TcpPort = 0;
            // this.UpdPort = 0;
        }
    }
}
