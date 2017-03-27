using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChatStore
    {
        public ChatType ChatType { get; set; }
        public string Message { get; set; }
        public string TeamGuid { get; set; }

        public string SendName { get; set; }

        public string ReceieveName { get; set; }

        public DateTime SendTime { get; set; }
    }
}
