using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CreateTeamRequest
    {
        public string nickname { get; set; }
        public string username { get; set; }
        public string groupname { get; set; }
        public string groupguid { get; set; }

        public string[] groupuserList { get; set; }


    }
}
