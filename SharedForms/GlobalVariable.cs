using CCWin.SkinControl;
using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SharedForms
{
    public static class GlobalVariable
    {
        public static MyTcpClient client;
        public static LoginUserInfo LoginUserInfo;

        public static List<ChatStore> ChatList { get; set; }

        public static int Num { get; set; }

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
                info.UserType = request.UserType;
                info.MessageList = new List<ChatMessage>();
                ChatList.Add(info);
            }
            SaveChatMessage(request);

        }

        static Font messageFont = new Font("微软雅黑", 9);
        static Color messageColor = Color.FromArgb(255, 32, 32, 32);
        private static void SaveChatMessage(AddChatRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Message))
            {
                ChatBoxContent content = new ChatBoxContent(request.Message, messageFont, messageColor);
                var message = new ChatMessage(request.UserName, request.DisplayName, LoginUserInfo.UserName, content);
                SaveChatMessage(message, false);
            }
        }

        public static ChatStore GetChatStore(string userName)
        {
            return ChatList.FirstOrDefault(d => d.ChatUserName == userName);
        }
        public static void SaveChatMessage(ChatMessage message, bool isSend)
        {
            string userName = isSend ? message.ReceieveUserName : message.SendUserName;
            if (ChatList == null)
            {
                return;

            }
            var chat = ChatList.FirstOrDefault(d => d.ChatUserName == userName);
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
