using Newtonsoft.Json;

namespace QobuzApiSharp.Models
{
    /// <summary>
    /// A general qobuz api status response.
    /// </summary>
    public class QobuzApiStatusResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}