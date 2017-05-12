using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeamChatRequest
    {
        public string username { get; set; }
        public string groupname { get; set; }
        public string groupuserList { get; set; }
        public string msg { get; set; }
    }
}
