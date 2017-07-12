using System.Collections.Generic;

namespace Model
{
    public class TeamChatCreateOrUpdateRequest
    {
        public IList<TeamInfo> TeamInfos { get; set; }


    }

    public class TeamInfo
    {
        public string groupname { get; set; }
        public string groupid { get; set; }
        public List<TeamMember> groupuserList { get; set; }
    }
}
