using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class AudioInfo
    {
        [JsonProperty("replaygain_track_gain")]
        public double? ReplaygainTrackGain { get; set; }

        [JsonProperty("replaygain_track_peak")]
        public double? ReplaygainTrackPeak { get; set; }
    }
}