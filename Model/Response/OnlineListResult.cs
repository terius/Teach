using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OnlineListResult
    {
        public string username { get; set; }
        public string nickname { get; set; }
        public ClientStyle clientStyle { get; set; }
        public ClientRole clientRole { get; set; }

        public int no { get; set; }
    }
}
