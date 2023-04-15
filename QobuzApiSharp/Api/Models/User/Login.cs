using Newtonsoft.Json;

namespace QobuzApiSharp.Models.User
{
    public class Login
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("user_auth_token")]
        public string AuthToken { get; set; }
    }
}