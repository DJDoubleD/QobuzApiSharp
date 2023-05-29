using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public abstract class ReleaseItem
    {
        [JsonProperty("artist")]
        public ReleaseArtist Artist { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("audio_info")]
        public AudioInfo AudioInfo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parental_warning")]
        public bool? ParentalWarning { get; set; }

        [JsonProperty("rights")]
        public ReleaseRights Rights { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}