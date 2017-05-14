﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeamChatListRequest
    {
        public IList<TeamInfo> TeamInfos { get; set; }


    }

    public class TeamInfo
    {
        public string groupname { get; set; }
        public string groupid { get; set; }
        public IList<TeamMember> groupuserList { get; set; }
    }
}
