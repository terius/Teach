using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeacherUser
{
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

            if (!ChatList.Any(d => d.ChatUserName == request.ChatUserName))
            {
                ChatStore info = new ChatStore();
                info.ChatDisplatName = request.ChatDisplatName;
                info.ChatStartTime = DateTime.Now;
                info.ChatType = request.ChatType;
                info.ChatUserName = request.ChatUserName;
                info.MessageList = new List<ChatMessage>();
                ChatList.Add(info);
            }
        }
    }
}
