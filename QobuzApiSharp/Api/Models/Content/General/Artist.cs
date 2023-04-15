using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Artist
    {
        [JsonProperty("album_last_release")]
        public Album AlbumLastRelease { get; set; }

        [JsonProperty("albums")]
        public ItemSearchResult<Album> Albums { get; set; }

        [JsonProperty("albums_as_primary_artist_count")]
        public int? AlbumsAsPrimaryArtistCount { get; set; }

        [JsonProperty("albums_as_primary_composer_count")]
        public int? AlbumsAsPrimaryComposerCount { get; set; }

        [JsonProperty("albums_count")]
        public int? AlbumsCount { get; set; }

        [JsonProperty("albums_without_last_release")]
        public ItemSearchResult<Album> AlbumsWithoutLastRelease { get; set; }

        [JsonProperty("biography")]
        public Biography Biography { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("information")]
        public object Information { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("playlists")]
        public ItemSearchResult<Playlist> Playlists { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("similar_artist_ids")]
        public List<int> SimilarArtistIds { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}