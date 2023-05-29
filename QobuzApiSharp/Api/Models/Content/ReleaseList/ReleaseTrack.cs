using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class ReleaseTrack: ReleaseItem
    {
        [JsonProperty("composer")]
        public object Composer { get; set; }

        [JsonProperty("duration")]
        public long? Duration { get; set; }

        [JsonProperty("isrc")]
        public string Isrc { get; set; }

        [JsonProperty("physical_support")]
        public ReleasePhysicalSupport PhysicalSupport { get; set; }

        [JsonProperty("work")]
        public string Work { get; set; }
    }
}