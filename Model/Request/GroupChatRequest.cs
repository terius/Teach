﻿using Common;

namespace Model
{
    public class GroupChatRequest
    {
       

        public string SendUserName { get; set; }

        public string msg { get; set; }

        public string SendDisplayName { get; set; }
        public ClientRole clientRole { get; set; }


    }
}
