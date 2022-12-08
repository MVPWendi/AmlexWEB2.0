using AmlexWEB.Services;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AmlexWEB.Models
{
    public class UserModel : UserDto
    {
        private readonly DatabaseUsers _Db;
        private readonly ILogger<UserModel> _logger;
        public UserModel(DatabaseUsers db, ILogger<UserModel> logger)
        {            
            _Db = db;
            _logger = logger;
        }
        public void CreateIfNotExist(string UserClaimName)
        {
            //http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=6C693BCD04975E2A69F2445252F3F19A&steamids=76561197960435530
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SteamID = UserClaimName.Replace("https://steamcommunity.com/openid/id/", "");
                    string uri = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=6C693BCD04975E2A69F2445252F3F19A&steamids={SteamID}";
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    var SteamInfo = response.Content.ReadAsStringAsync().Result;
                    var info = JsonConvert.DeserializeObject<Root>(SteamInfo);
                    _Db.CreateUser(SteamID, info.response.players[0].personaname);
                   
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
        }

        public UserModel GetUser(string UserClaimName)
        {
            SteamID = UserClaimName.Replace("https://steamcommunity.com/openid/id/", "");
            var UserDto = _Db.GetUser(SteamID);
            SteamID = UserDto.SteamID;
            UserName = UserDto.UserName;
            Balance = UserDto.Balance;
            return this;
        }
    }
}
