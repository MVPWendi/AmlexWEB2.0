using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlexWebPlugin
{
    public class Plugin : RocketPlugin<Configuration>
    {
        public static Plugin Instance;
        private Monitoring Monitoring;
        protected override void Load()
        {
            Instance = this;
            Monitoring = new Monitoring();
            Monitoring.SendRequestJson("update", new Server
            {
                MaxPlayers = 24,
                CurrentPlayers = 0,
                Enabled = true,
                IP = "127.0.0.1",
                Name = "Test",
                Port = "27015"
            });
        }

        protected override void Unload()
        {
            Monitoring.SendRequestJson("update", new Server
            {
                MaxPlayers = 24,
                CurrentPlayers = 0,
                Enabled = false,
                IP = "127.0.0.1",
                Name = "Test",
                Port = "27015"
            });
            Instance = null;
        }
    }
}
