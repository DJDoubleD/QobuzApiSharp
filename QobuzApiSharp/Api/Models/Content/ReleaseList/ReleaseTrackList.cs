using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class ReleaseTrackList
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("tracks")]
        public List<Release> Items { get; set; }
    }
}