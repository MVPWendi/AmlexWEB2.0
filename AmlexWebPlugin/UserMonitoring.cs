using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlexWebPlugin
{
    public class UserMonitoring
    {
        public string ServerName { get; set; }
        public bool Connect { get; set; }
        public DateTime ConnectTime { get; set; }
        public string UserName { get; set; }
        public string SteamID { get; set; }
    }
}
