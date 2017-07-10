using Common;

namespace Model
{
    public class TeamChatRequest
    {
        public string username { get; set; }
        public string groupname { get; set; }
        public string groupuserList { get; set; }
        public string msg { get; set; }

        public string groupid { get; set; }

        public string SendDisplayName { get; set; }

        public ClientRole clientRole { get; set; }
    }
}
