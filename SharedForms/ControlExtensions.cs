using Common;
using DevExpress.XtraNavBar;
using Model;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace SharedForms
{
    public static class ControlExtensions
    {

        public static void SetButtonHoverLeave(this Control control)
        {
            if (control.GetType() == typeof(Button))
            {
                control.MouseHover += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 240, 59);
                control.MouseLeave += (sender, e) => ((Button)sender).BackColor = Color.FromArgb(0, 201, 59);
            }
        }

        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        public static AddChatRequest ToAddChatRequest(this PrivateChatRequest response)
        {
            AddChatRequest request = new AddChatRequest();
            request.UserName = response.SendUserName;
            request.DisplayName = response.SendDisplayName;
            request.ChatType = ChatType.PrivateChat;
            request.Message = response.msg;
            request.UserType = response.clientRole;
            return request;
        }

        public static AddChatRequest ToAddChatRequest(this TeamChatRequest response)
        {
            AddChatRequest request = new AddChatRequest();
            request.UserName = response.groupid;
            request.DisplayName = response.SendDisplayName;
            request.ChatType = ChatType.TeamChat;
            request.Message = response.msg;
            request.UserType = response.clientRole;
            return request;
        }

        public static ChatItem CreateItem(this NavBarControl source,AddChatRequest request)
        {
            ChatItem item = new ChatItem(source, request.UserName,
                request.DisplayName, request.ChatType, request.UserType);
          
            return item;
        }
        public static ChatItem CreateItem(this NavBarControl source, ChatStore store)
        {
            ChatItem item = new ChatItem(source, store.ChatUserName,
                store.ChatDisplayName, store.ChatType, store.UserType);

            return item;
        }

        public static bool IsMySelf(this string userName)
        {
            return userName == GlobalVariable.LoginUserInfo.UserName;
        }

       
    }
}
