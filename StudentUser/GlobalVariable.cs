using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;

namespace StudentUser
{
    public static class GlobalVariable
    {
        public static MyTcpClient client { get; set; }
        public static LoginUserInfo LoginUserInfo { get; set; }

        public static List<ChatStore> ChatList { get; set; }


        public static void AddToChatList(PrivateChatRequest request)
        {
            if (ChatList == null)
            {
                ChatList = new List<ChatStore>();
            }
            var store = new ChatStore();
            //store.ChatType = ChatType.PrivateChat;
            //store.Message = request.msg;
            //store.ReceieveName = request.receivename;
            //store.SendName = request.sendname;
            //store.SendTime = DateTime.Now;
            ChatList.Add(store);

        }
    }


}
