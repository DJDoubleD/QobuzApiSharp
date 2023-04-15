using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Goody
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("file_format_id")]
        public int? FileFormatId { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}