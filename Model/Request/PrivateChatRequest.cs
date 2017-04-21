using Common;

namespace Model
{
    public class PrivateChatRequest
    {
        public string receivename { get; set; }

        public string SendUserName { get; set; }

        public string msg { get; set; }

        public string guid { get; set; }

        public string SendDisplayName { get; set; }
    }


    public class AddChatRequest
    {
       
        public ChatType ChatType { get; set; }
        public string ChatUserName { get; set; }

        public string ChatDisplayName { get; set; }
    }
}
