using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class FileUrl
    {
        [JsonProperty("track_id")]
        public int TrackId { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("format_id")]
        public int FormatId { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("sampling_rate")]
        public double SamplingRate { get; set; }

        [JsonProperty("bit_depth")]
        public int BitDepth { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}