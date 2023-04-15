using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class UserFavoritesIds
    {
        [JsonProperty("albums")]
        public List<string> Albums { get; set; }

        [JsonProperty("articles")]
        public List<long> Articles { get; set; }

        [JsonProperty("artists")]
        public List<int> Artists { get; set; }

        [JsonProperty("tracks")]
        public List<int> Tracks { get; set; }
    }
}