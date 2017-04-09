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

        public string ChatDisplatName { get; set; }

        public DateTime ChatStartTime { get; set; }


        public IList<ChatMessage> MessageList { get; set; }
    }

    public class ChatMessage
    {
        public string SendName { get; set; }

        public string ReceieveName { get; set; }

        public DateTime SendTime { get; set; }

        public string Message { get; set; }
    }

}
