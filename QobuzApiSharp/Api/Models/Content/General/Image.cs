using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Image
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("extralarge")]
        public string Extralarge { get; set; }

        [JsonProperty("mega")]
        public string Mega { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("back")]
        public string Back { get; set; }
    }
}