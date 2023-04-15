using Newtonsoft.Json;

namespace QobuzApiSharp.Models.User
{
    public class StoreFeatures
    {
        [JsonProperty("autoplay")]
        public bool? Autoplay { get; set; }

        [JsonProperty("download")]
        public bool? Download { get; set; }

        [JsonProperty("editorial")]
        public bool? Editorial { get; set; }

        [JsonProperty("inapp_purchase_subscripton")]
        public bool? InappPurchaseSubscripton { get; set; }

        [JsonProperty("music_import")]
        public bool? MusicImport { get; set; }

        [JsonProperty("opt_in")]
        public bool? OptIn { get; set; }

        [JsonProperty("streaming")]
        public bool? Streaming { get; set; }

        [JsonProperty("wallet")]
        public bool? Wallet { get; set; }

        [JsonProperty("weeklyq")]
        public bool? Weeklyq { get; set; }
    }
}