using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class ReleasePhysicalSupport
    {
        [JsonProperty("media_number")]
        public long? MediaNumber { get; set; }

        [JsonProperty("track_number")]
        public long? TrackNumber { get; set; }
    }
}