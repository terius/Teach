using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;

namespace TeacherUser
{
    public static class GlobalVariable
    {
        public static MyTcpClient client;
        public static LoginUserInfo LoginUserInfo;

        public static List<ChatStore> ChatList { get; set; }

        public static void AddPrivateChatToChatList(string receivename,string sendname,string msg)
        {
            if (ChatList == null)
            {
                ChatList = new List<ChatStore>();
            }
            var store = new ChatStore();
            store.ChatType = ChatType.PrivateChat;
            store.Message = msg;
            store.ReceieveName = receivename;
            store.SendName = sendname;
            store.SendTime = DateTime.Now;
            ChatList.Add(store);

        }
    }
}
