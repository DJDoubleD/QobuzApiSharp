using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Area
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}