using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AmlexWebPlugin
{
    public class PlayerComponent : UnturnedPlayerComponent
    {


        protected override void Load()
        {
            Monitoring.SendRequestJson("update", Monitoring.GetServerInfo());
            Monitoring.SendRequestJson("connect", new UserMonitoring
            {
                SteamID = base.Player.CSteamID.ToString(),
                ServerName = Plugin.Instance.Configuration.Instance.ServerName,
                Connect = true,
                ConnectTime = DateTime.Now,
                UserName = base.Player.CharacterName
            });
        }
        protected override void Unload()
        {
            Monitoring.SendRequestJson("update", Monitoring.GetServerInfo());
            Monitoring.SendRequestJson("connect", new UserMonitoring
            {
                SteamID = base.Player.CSteamID.ToString(),
                ServerName = Plugin.Instance.Configuration.Instance.ServerName,
                Connect = false,
                ConnectTime = DateTime.Now,
                UserName = base.Player.CharacterName
            });
        }
    }
}
