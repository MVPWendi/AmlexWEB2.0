using Rocket.API;

namespace AmlexWebPlugin
{
    public class Configuration : IRocketPluginConfiguration
    {

        public string WebAddress;
        public string IP;
        public string BasicAuth;
        public string ServerName;
        public void LoadDefaults()
        {
            BasicAuth = "Amlex:123456q";
            WebAddress = "https://localhost:7264/api";
            IP = "127.0.0.1";
            ServerName = "Test";

        }
    }
}