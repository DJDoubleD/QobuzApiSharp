using Newtonsoft.Json;

namespace QobuzApiSharp.Models.User
{
    public class ColorScheme
    {
        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}