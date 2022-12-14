using AmlexWEB.Models.User;
using System.Diagnostics;

namespace AmlexWEB.Models
{

    
    public class Server
    {
        public string Name { get; set; }
        public int MaxPlayers { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public bool Enabled { get; set; }
        public int CurrentPlayers { get; set; }
        public IEnumerable<UserMonitoring> Players { get; set; }
    }
}
