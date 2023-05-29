using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Release: ReleaseItem
    {
        [JsonProperty("dates")]
        public ReleaseDates Dates { get; set; }

        [JsonProperty("duration")]
        public long? Duration { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("label")]
        public Label Label { get; set; }

        [JsonProperty("release_tags")]
        public List<string> ReleaseTags { get; set; }

        [JsonProperty("release_type")]
        public string ReleaseType { get; set; }

        [JsonProperty("tracks")]
        public ReleaseTrackList Tracks { get; set; }

        [JsonProperty("tracks_count")]
        public long? TracksCount { get; set; }
    }
}