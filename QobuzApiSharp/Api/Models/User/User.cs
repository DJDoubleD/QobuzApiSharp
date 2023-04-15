using Newtonsoft.Json;
using System;

namespace QobuzApiSharp.Models.User
{
    public class User
    {
        [JsonProperty("age")]
        public long? Age { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("credential")]
        public Credential Credential { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }

        [JsonProperty("last_update")]
        public LastUpdate LastUpdate { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("publicId")]
        public string PublicId { get; set; }

        [JsonProperty("store")]
        public string Store { get; set; }

        [JsonProperty("store_features")]
        public StoreFeatures StoreFeatures { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("zone")]
        public string Zone { get; set; }
    }
}