using Newtonsoft.Json;
using QobuzApiSharp.Converters;

namespace QobuzApiSharp.Models.Content
{
    public class MostPopular
    {
        [JsonProperty("content")]
        [JsonConverter(typeof(MostPopularContentConverter))]
        public MostPopularContent Content { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class SearchResult
    {
        [JsonProperty("albums")]
        public ItemSearchResult<Album> Albums { get; set; }

        [JsonProperty("articles")]
        public ItemSearchResult<Article> Articles { get; set; }

        [JsonProperty("artists")]
        public ItemSearchResult<Artist> Artists { get; set; }
        [JsonProperty("focus")]
        public ItemSearchResult<Story> Focus { get; set; }

        [JsonProperty("most_popular")]
        public ItemSearchResult<MostPopular> MostPopular { get; set; }

        [JsonProperty("playlists")]
        public ItemSearchResult<Playlist> Playlists { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("stories")]
        public ItemSearchResult<Story> Stories { get; set; }

        [JsonProperty("tracks")]
        public ItemSearchResult<Track> Tracks { get; set; }
    }
}