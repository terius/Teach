﻿using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedForms
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
                info.ChatDisplayName = request.ChatDisplayName;
                info.ChatStartTime = DateTime.Now;
                info.ChatType = request.ChatType;
                info.ChatUserName = request.ChatUserName;
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