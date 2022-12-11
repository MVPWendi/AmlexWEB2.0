using AmlexWEB.Models;
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
                    Port = "27015"
                }
            };
        }


        public void UpdateServerInfo(Server server)
        {
            var findedServer = Servers.ToList().FirstOrDefault(x => x.Name == server.Name);
            _logger.LogInformation($"INCOME: {JsonConvert.SerializeObject(server)}");
            _logger.LogInformation($"FINDED: {JsonConvert.SerializeObject(findedServer)}");
            if (findedServer == null) throw new KeyNotFoundException();
            findedServer.IP = server.IP;
            findedServer.Port = server.Port;
            findedServer.CurrentPlayers = server.CurrentPlayers;
            findedServer.MaxPlayers = server.CurrentPlayers;
            findedServer.Enabled = server.Enabled;
        }
    }
}
