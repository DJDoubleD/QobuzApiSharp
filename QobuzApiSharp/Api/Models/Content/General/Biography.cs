using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Biography
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}