using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class ReleasesList
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("items")]
        public List<Release> Items { get; set; }
    }
}