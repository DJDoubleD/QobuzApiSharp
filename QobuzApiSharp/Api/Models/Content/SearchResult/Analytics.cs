using Newtonsoft.Json;

namespace QobuzApiSharp.Models.Content
{
    public class Analytics
    {
        [JsonProperty("search_external_id")]
        public string SearchExternalId { get; set; }
    }
}