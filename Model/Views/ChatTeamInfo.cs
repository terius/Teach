using System;
using System.Collections.Generic;

namespace Model.Views
{
    [Serializable]
    public class TeamXmlInfo
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public List<TeamInfo> Teams { get; set; }

    }

  



}
