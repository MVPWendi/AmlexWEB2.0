using AmlexWEB.Models.User;
using System.ComponentModel;

namespace AmlexWEB.Services
{
    public class DatabaseUsers : DatabaseUtils
    {

        private const string SQLSelectPlayerByID = "SELECT TOP 1 * FROM PLAYERS WHERE SteamID = '{0}'";
        public void CreateUser(string steamID, string name)
        {
            ExecuteCrud("CreatePlayer", new Dictionary<string, object> {
                {"SteamID", steamID},
                {"Name", name }
            });
        }



        public UserDto GetUser(string steamID)
        {
            var row = GetTable(string.Format(SQLSelectPlayerByID, steamID)).FirstOrDefault();
            return new UserDto
            {
                SteamID = row.TryGetValue("SteamID", out var ID) ? (string)ID : throw new NullReferenceException(),
                Balance = row.TryGetValue("Balance", out var balance) ? (decimal)balance : throw new NullReferenceException(),
                UserName = row.TryGetValue("Name", out var name) ? (string)name : throw new NullReferenceException()
            };
        }
    }
}
