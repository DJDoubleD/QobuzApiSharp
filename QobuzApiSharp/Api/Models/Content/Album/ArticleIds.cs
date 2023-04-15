using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class ArticleIds
    {
        [JsonProperty("LLS")]
        public int? LLS { get; set; }

        [JsonProperty("SHP")]
        public int? SHP { get; set; }

        [JsonProperty("SMR")]
        public int? SMR { get; set; }
    }
}