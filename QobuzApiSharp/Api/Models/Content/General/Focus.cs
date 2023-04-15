using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Focus
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("name_superbloc")]
        public string NameSuperbloc { get; set; }

        [JsonProperty("accroche")]
        public string Accroche { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("genre_ids")]
        public List<string> GenreIds { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }
    }
}
