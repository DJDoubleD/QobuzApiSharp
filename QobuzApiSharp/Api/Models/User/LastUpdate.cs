using Newtonsoft.Json;

namespace QobuzApiSharp.Models.User
{
    public class LastUpdate
    {
        [JsonProperty("favorite")]
        public long? Favorite { get; set; }

        [JsonProperty("playlist")]
        public long? Playlist { get; set; }

        [JsonProperty("purchase")]
        public long? Purchase { get; set; }
    }
}