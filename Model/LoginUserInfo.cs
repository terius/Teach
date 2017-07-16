using Common;
using System.ComponentModel;

namespace Model
{
    public class LoginUserInfo
    {
        public LoginUserInfo()
        {
            AllowPrivateChat = true;
            AllowTeamChat = true;
        }
        public string UserName { get; set; }

        public string No { get; set; }

        public ClientRole UserType { get; set; }

        public string DisplayName { get; set; }

        //[DefaultValue(true)]
        public bool AllowPrivateChat { get;  set; }
        //[DefaultValue(true)]
        public bool AllowTeamChat { get; set; }
    }
}
