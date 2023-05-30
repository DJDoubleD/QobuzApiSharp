using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Owner
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Playlist
    {
        [JsonProperty("created_at")]
        public long? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("featured_artists")]
        public List<Artist> FeaturedArtists { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("image_rectangle")]
        public List<string> ImageRectangle { get; set; }

        [JsonProperty("image_rectangle_mini")]
        public List<string> ImageRectangleMini { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("images150")]
        public List<string> Images150 { get; set; }

        [JsonProperty("images300")]
        public List<string> Images300 { get; set; }

        [JsonProperty("is_collaborative")]
        public bool? IsCollaborative { get; set; }

        [JsonProperty("is_featured")]
        public bool? IsFeatured { get; set; }

        [JsonProperty("is_public")]
        public bool? IsPublic { get; set; }

        [JsonProperty("is_published")]
        public bool? IsPublished { get; set; }

        [JsonProperty("items_focus")]
        public List<Focus> ItemsFocus { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("public_at")]
        public long? PublicAt { get; set; }

        [JsonProperty("published_from")]
        public long? PublishedFrom { get; set; }

        [JsonProperty("published_to")]
        public long? PublishedTo { get; set; }

        [JsonProperty("similarPlaylist")]
        public ItemSearchResult<Playlist> SimilarPlaylists { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("stores")]
        public List<string> Stores { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("timestamp_position")]
        public long? TimestampPosition { get; set; }

        [JsonProperty("track_ids")]
        public List<long> TrackIds { get; set; }

        [JsonProperty("tracks")]
        public ItemSearchResult<Track> Tracks { get; set; }

        [JsonProperty("tracks_count")]
        public int? TracksCount { get; set; }

        [JsonProperty("updated_at")]
        public long? UpdatedAt { get; set; }

        [JsonProperty("users_count")]
        public long? UsersCount { get; set; }
    }
}