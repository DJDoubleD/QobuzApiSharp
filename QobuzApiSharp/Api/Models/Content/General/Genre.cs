using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Genre
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public List<int?> Path { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}