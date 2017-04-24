using CCWin.SkinControl;
using Common;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace SharedForms
{
    public static class GlobalVariable
    {
        public static MyTcpClient client;
        public static LoginUserInfo LoginUserInfo;

        private static List<ChatStore> chatList;

        //   public static List<ChatStore> ChatList { get; set; }

        public static bool IsTeamChatChanged { get; set; }

        public static List<ChatStore> ChatList
        {
            get
            {
                if (chatList == null)
                {
                    chatList = new List<ChatStore>();
                }
                return chatList;
            }

            set
            {
                chatList = value;
            }
        }

        public static void AddNewChat(AddChatRequest request)
        {
            ChatStore info = ChatList.FirstOrDefault(d => d.ChatUserName == request.UserName);

            if (info == null)
            {
                info = new ChatStore();
                info.ChatDisplayName = request.DisplayName;
                info.ChatStartTime = DateTime.Now;
                info.ChatType = request.ChatType;
                info.ChatUserName = request.UserName;
                info.UserType = request.UserType;
                info.MessageList = new List<ChatMessage>();
                ChatList.Add(info);
            }

            if (!string.IsNullOrWhiteSpace(request.Message))
            {
                //ChatBoxContent content = new ChatBoxContent(request.Message, messageFont, messageColor);
                var message = request.ToChatMessage();// new ChatMessage(request.UserName, request.DisplayName, LoginUserInfo.UserName, content);

                if (info.NewMessageList == null)
                {
                    info.NewMessageList = new List<ChatMessage>();

                }
                info.NewMessageList.Add(message);
            }

        }

     


        public static ChatMessage ToChatMessage(this AddChatRequest request)
        {
            ChatBoxContent content = new ChatBoxContent(request.Message, messageFont, messageColor);
            return new ChatMessage(request.UserName, request.DisplayName, LoginUserInfo.UserName, content);
        }

        static Font messageFont = new Font("微软雅黑", 9);
        static Color messageColor = Color.FromArgb(255, 32, 32, 32);
        //private static void SaveChatMessage(AddChatRequest request)
        //{
        //    if (!string.IsNullOrWhiteSpace(request.Message))
        //    {
        //        ChatBoxContent content = new ChatBoxContent(request.Message, messageFont, messageColor);
        //        var message = new ChatMessage(request.UserName, request.DisplayName, LoginUserInfo.UserName, content);
        //        SaveNewChatMessage(message, false);
        //    }
        //}

        //public static ChatStore GetChatStore(string userName)
        //{
        //    return ChatList.FirstOrDefault(d => d.ChatUserName == userName);
        //}
        //public static void SaveNewChatMessage(ChatMessage message, bool isSend)
        //{
        //    string userName = isSend ? message.ReceieveUserName : message.SendUserName;

        //    var chat = ChatList.FirstOrDefault(d => d.ChatUserName == userName);
        //    if (chat == null)
        //    {
        //        return;
        //    }
        //    if (chat.MessageList == null)
        //    {
        //        chat.MessageList = new List<ChatMessage>();
        //    }
        //    chat.MessageList.Add(message);
        //}

        public static void SaveChatMessage(ChatBoxContent content, string userName)
        {
            var chatstore = ChatList.FirstOrDefault(d => d.ChatUserName == userName);
            if (chatstore != null)
            {
                chatstore.HistoryContent = content;
                chatstore.NewMessageList = null;
            }
        }


        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarnning(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowSuccess(string msg)
        {
            MessageBox.Show(msg, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static IList<ChatStore> GetTeamChatList()
        {
            return ChatList.Where(d => d.ChatType == ChatType.TeamChat).ToList();
        }

        //public static IList<ChatMessage> GetNewMessageList(string userName)
        //{
        //    var chat = ChatList.FirstOrDefault(d => d.ChatUserName == userName);
        //    if (chat != null)
        //    {
        //        return chat.NewMessageList;
        //    }
        //    return null;
        //}


        public static void CreateTeamChat(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
            {
                ShowError("组名不能为空！");
                return;
            }


            if (ChatList.Any(d => d.ChatDisplayName == teamName))
            {
                ShowError("组名不能重复！");
                return;
            }


            ChatStore info = new ChatStore();
            info.ChatDisplayName = teamName;
            info.ChatStartTime = DateTime.Now;
            info.ChatType = ChatType.TeamChat;
            info.ChatUserName = Guid.NewGuid().ToString();
            info.UserType = ClientRole.Teacher;
            info.MessageList = new List<ChatMessage>();
            ChatList.Add(info);
            ShowSuccess("分组建立成功");
            IsTeamChatChanged = true;
        }

        public static bool AddTeamMember(CheckedListViewItemCollection mems, string guid)
        {
            var info = ChatList.FirstOrDefault(d => d.ChatUserName == guid && d.ChatType == ChatType.TeamChat);
            if (info == null)
            {
                ShowError("未找到添加的分组信息");
                return false;
            }
            string userName = "";
            string displayName = "";
            foreach (ListViewItem item in mems)
            {
                userName = item.SubItems[1].Text;
                displayName = item.Text;
                if (!info.TeamMembers.Any(d => d.UserName == userName))
                {
                    info.TeamMembers.Add(new TeamMember { UserName = userName, DisplayName = displayName });
                }
            }
            IsTeamChatChanged = true;
            //  ShowSuccess("分组成员添加成功");
            return true;
        }

        public static bool DelTeamMember(string teamGuid, string userName)
        {
            var info = ChatList.FirstOrDefault(d => d.ChatUserName == teamGuid && d.ChatType == ChatType.TeamChat);
            if (info == null)
            {
                ShowError("未找到要删除的分组信息");
                return false;
            }
            var mem = info.TeamMembers.FirstOrDefault(d => d.UserName == userName);
            if (mem == null)
            {
                return false;
            }
            IsTeamChatChanged = true;
            return info.TeamMembers.Remove(mem);
        }

        public static bool EditTeamName(string teamGuid, string newName)
        {
            if (ChatList.Any(d => d.ChatDisplayName == newName && d.ChatUserName != teamGuid))
            {
                ShowError("组名不能重复！");
                return false;
            }
            var item = ChatList.FirstOrDefault(d => d.ChatUserName == teamGuid);
            if (item == null)
            {
                ShowError("未找到分组信息！");
                return false;
            }

            item.ChatDisplayName = newName;
            IsTeamChatChanged = true;
            return true;

        }

        public static bool DelTeam(string teamGuid)
        {
            var item = ChatList.FirstOrDefault(d => d.ChatUserName == teamGuid);
            if (item == null)
            {
                ShowError("未找到分组信息！");
                return false;
            }
            ChatList.Remove(item);
            IsTeamChatChanged = true;
            return true;
        }
    }
}
