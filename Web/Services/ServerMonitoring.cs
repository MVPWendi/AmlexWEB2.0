using AmlexWEB.Models;
using AmlexWEB.Models.User;
using Newtonsoft.Json;

namespace AmlexWEB.Services
{
    public class ServerMonitoring
    {
        public IEnumerable<Server> Servers;

        private ILogger<ServerMonitoring> _logger;

        public ServerMonitoring(ILogger<ServerMonitoring> logger)
        {
            _logger = logger;
            Servers = new List<Server>
            {
                new Server
                {
                    MaxPlayers = 24,
                    CurrentPlayers = 0,
                    Enabled = false,
                    IP = "127.0.0.1",
                    Name = "Test",
                    Port = "27015",
                    Players = new List<UserMonitoring>()
                }
            };
        }


        public void UpdateServerInfo(Server server)
        {
            var findedServer = Servers.ToList().FirstOrDefault(x => x.Name == server.Name);
            if (findedServer == null) throw new KeyNotFoundException();
            findedServer.IP = server.IP;
            findedServer.Port = server.Port;
            findedServer.CurrentPlayers = server.CurrentPlayers;
            findedServer.MaxPlayers = server.CurrentPlayers;
            findedServer.Enabled = server.Enabled;
        }

        public void UpdateServerPlayer(UserMonitoring pl)
        {
            var findedServer = Servers.ToList().FirstOrDefault(x => x.Name == pl.ServerName);      
            List<UserMonitoring> Players = findedServer.Players.ToList();
            var player = Players.Find(x => x.SteamID == pl.SteamID);
            if (pl.Connect && player == null)
            {
                _logger.LogInformation($"ADD USER");
                Players.Add(pl);
            }
            if (pl.Connect == false && player != null)
            {
                _logger.LogInformation($"REMOVE USER");
                Players.Remove(player);

                
            }
            findedServer.Players = new List<UserMonitoring>(Players);
            for (int i = 0; i < findedServer.Players.Count(); i++)
            {
                _logger.LogInformation($"US INFO START: {findedServer.Players.ElementAt(0).UserName}");
            }
        }
    }
}
