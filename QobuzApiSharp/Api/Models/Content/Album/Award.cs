using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Award
    {
        [JsonProperty("awarded_at")]
        public long? AwardedAt { get; set; }

        [JsonProperty("award_id")]
        public string AwardId { get; set; }

        [JsonProperty("award_slug")]
        public string AwardSlug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("publication_id")]
        public string PublicationId { get; set; }

        [JsonProperty("publication_name")]
        public string PublicationName { get; set; }
        [JsonProperty("publication_slug")]
        public string PublicationSlug { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}