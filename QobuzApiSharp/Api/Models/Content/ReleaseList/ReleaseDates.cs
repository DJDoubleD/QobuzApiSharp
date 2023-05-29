using Newtonsoft.Json;
using System;

namespace QobuzApiSharp.Models.Content
{
    public class ReleaseDates
    {
        [JsonProperty("download")]
        public DateTimeOffset? Download { get; set; }

        [JsonProperty("original")]
        public DateTimeOffset? Original { get; set; }

        [JsonProperty("stream")]
        public DateTimeOffset? Stream { get; set; }
    }
}