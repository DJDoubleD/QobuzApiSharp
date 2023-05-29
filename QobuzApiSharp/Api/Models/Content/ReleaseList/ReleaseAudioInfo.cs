using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class ReleaseAudioInfo
    {
        [JsonProperty("maximum_bit_depth")]
        public int? MaximumBitDepth { get; set; }

        [JsonProperty("maximum_channel_count")]
        public int? MaximumChannelCount { get; set; }

        [JsonProperty("maximum_sampling_rate")]
        public double? MaximumSamplingRate { get; set; }
    }
}