using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Period
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}