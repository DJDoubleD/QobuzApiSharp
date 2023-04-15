using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class AlbumsSameArtist
    {
        [JsonProperty("items")]
        public List<Album> Items { get; set; }
    }
}