using Common;

namespace Model
{
    public class PrivateChatRequest
    {
        public string receivename { get; set; }

        public string sendname { get; set; }

        public string msg { get; set; }

        public string guid { get; set; }
    }


    public class AddChatRequest
    {
       
        public ChatType ChatType { get; set; }
        public string ChatUserName { get; set; }

        public string ChatDisplatName { get; set; }
    }
}
