using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class ReleaseArtist
    {
        [JsonProperty("name")]
        public ReleaseArtistName Name { get; set; }
    }

    public class ReleaseArtistName
    {
        [JsonProperty("display")]
        public string Display { get; set; }
    }
}