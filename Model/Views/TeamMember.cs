using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeamMember
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }

        public bool IsOnline { get; set; }
    }
}
