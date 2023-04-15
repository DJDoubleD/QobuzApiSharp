using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public abstract class MostPopularContent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}