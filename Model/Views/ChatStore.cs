using CCWin.SkinControl;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChatStore
    {
        public ChatType ChatType { get; set; }
      
        public string ChatUserName { get; set; }

        public string ChatDisplayName { get; set; }

        public DateTime ChatStartTime { get; set; }

        public ClientRole UserType { get; set; }


        public IList<ChatMessage> MessageList { get; set; }
    }

    public class ChatMessage
    {
        public string SendUserName { get; set; }

        public string SendDisplayName { get; set; }

        public string ReceieveUserName { get; set; }

        public DateTime SendTime { get; set; }

        public string Message { get; set; }

        public  ChatBoxContent Content { get; set; }


        public ChatMessage(string _sendUserName,
            string _sendDisplayName,
            string _receieveUserName, ChatBoxContent _content)
        {
            this.SendUserName = _sendUserName;
            this.SendDisplayName = _sendDisplayName;
            this.ReceieveUserName = _receieveUserName;
            this.SendTime = DateTime.Now;
            this.Message = _content.Text;
            _content.Text = "    " + _content.Text.Replace("\n", "\n    ");
            this.Content = _content;
        }
    }

}
