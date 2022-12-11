using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
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
        protected override void Load()
        {
            Instance = this;
            Monitoring.SendRequestJson("update", Monitoring.GetServerInfo());
        }

        protected override void Unload()
        {
            var server = Monitoring.GetServerInfo();
            server.Enabled = false;
            var a = 2;
            Monitoring.SendRequestJson("update", server);
            Instance = null;
        }


        
    }
}
