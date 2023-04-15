using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Story
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("section_slugs")]
        public List<string> SectionSlugs { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description_short")]
        public string DescriptionShort { get; set; }

        [JsonProperty("authors")]
        public List<Author> Authors { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("display_date")]
        public long? DisplayDate { get; set; }
    }
}
