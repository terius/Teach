using System.Xml.Serialization;

namespace Model
{
    public class TeamMember
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        [XmlIgnore]
        public bool IsOnline { get; set; }
    }
}
