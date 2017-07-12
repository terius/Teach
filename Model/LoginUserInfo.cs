using Common;

namespace Model
{
    public class LoginUserInfo
    {
        
        public string UserName { get; set; }

        public string No { get; set; }

        public ClientRole UserType { get; set; }

        public string DisplayName { get; set; }

        public bool AllowPrivateChat { get; set; }
        public bool AllowTeamChat { get; set; }
    }
}
