using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyConfig
    {
        public static readonly string UploadFileServer = System.Configuration.ConfigurationManager.AppSettings["UploadFileServer"];
        public static readonly string ServerIp = System.Configuration.ConfigurationManager.AppSettings["serverIP"];
    }
}
