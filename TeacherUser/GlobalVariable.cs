using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeacherUser
{
    public class ChatStore
    {
        public ChatType ChatType { get; set; }

        public string ChatUserName { get; set; }

        public string ChatDisplayName { get; set; }

        public DateTime ChatStartTime { get; set; }

        public ClientRole UserType { get; set; }
        private IList<TeamMember> teamMembers;




        public IList<ChatMessage> MessageList { get; set; }


        public IList<ChatMessage> NewMessageList { get; set; }

       // public smsPanel HistoryContent { get; set; }

        public IList<TeamMember> TeamMembers
        {
            get
            {
                if (teamMembers == null)
                {
                    teamMembers = new List<TeamMember>();
                }
                return teamMembers;
            }

            set
            {
                teamMembers = value;
            }
        }

        public string GetUserNames()
        {
            return string.Join(",", TeamMembers.Select(d => d.UserName));
        }

        public string[] GetUserNameList()
        {
            return TeamMembers.Select(d => d.UserName).ToArray();
        }
    }




    public class ChatMessage
    {
        public string SendUserName { get; set; }

        public string SendDisplayName { get; set; }

        public string ReceieveUserName { get; set; }

        public DateTime SendTime { get; set; }

        public string Message { get; set; }

        public ClientRole UserType { get; set; }


        public string Title { get { return SendDisplayName + " (" + SendTime.ToString("yyyy-MM-dd HH:mm:ss") + ")"; } }

        // public ChatBoxContent Content { get; set; }


        public ChatMessage(string _sendUserName,
            string _sendDisplayName,
            string _receieveUserName,
            string _message,
            ClientRole _userType
            )
        {
            this.SendUserName = _sendUserName;
            this.SendDisplayName = _sendDisplayName;
            this.ReceieveUserName = _receieveUserName;
            this.SendTime = DateTime.Now;
            this.Message = _message;
            UserType = _userType;
        }
    }
    public static class GlobalVariable
    {
        public static MyTcpClient client;
        public static LoginUserInfo LoginUserInfo;

        public static List<ChatStore> ChatList { get; set; }

        public static void AddNewChat(AddChatRequest request)
        {
            if (ChatList == null)
            {
                ChatList = new List<ChatStore>();

            }

            if (!ChatList.Any(d => d.ChatUserName == request.UserName))
            {
                ChatStore info = new ChatStore();
                info.ChatDisplayName = request.DisplayName;
                info.ChatStartTime = DateTime.Now;
                info.ChatType = request.ChatType;
                info.ChatUserName = request.UserName;
                info.MessageList = new List<ChatMessage>();
                ChatList.Add(info);
            }
        }

        public static ChatStore GetChatStore(string userName)
        {
            return ChatList.FirstOrDefault(d => d.ChatUserName == userName);
        }
        public static void SaveChatMessage(ChatMessage message)
        {
            if (ChatList == null)
            {
                return;

            }
            var chat = ChatList.FirstOrDefault(d => d.ChatUserName == message.ReceieveUserName);
            if (chat == null)
            {
                return;
            }
            if (chat.MessageList == null)
            {
                chat.MessageList = new List<ChatMessage>();
            }
            chat.MessageList.Add(message);
        }
    }
}
