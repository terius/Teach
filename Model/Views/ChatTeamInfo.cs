using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
