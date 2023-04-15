using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Label
    {
        [JsonProperty("albums")]
        public ItemSearchResult<Album> Albums { get; set; }

        [JsonProperty("albums_count")]
        public int? AlbumsCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_language")]
        public string DescriptionLanguage { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("items_focus")]
        public List<Focus> ItemsFocus { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("supplier_id")]
        public int? SupplierId { get; set; }
    }
}