using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class GenreTag
    {
        [JsonProperty("genre_id")]
        public string GenreId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
