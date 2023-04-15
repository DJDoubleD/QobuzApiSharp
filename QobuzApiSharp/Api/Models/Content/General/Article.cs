using Newtonsoft.Json;
using System;

namespace QobuzApiSharp.Models.Content
{
    public class Article
    {
        [JsonProperty("abstract")]
        public string Abstract { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("image_original")]
        public Uri ImageOriginal { get; set; }

        [JsonProperty("published_at")]
        public long? PublishedAt { get; set; }

        [JsonProperty("root_category")]
        public int? RootCategory { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_image")]
        public Uri SourceImage { get; set; }

        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
