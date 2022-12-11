namespace AmlexWEB.Models.User
{
    public class UserMonitoring : UserDto
    {
        public DateTime ConnectTime { get; set; }
        public string ServerName { get; set; }
        public bool Connect { get; set; }

    }

}
