using Newtonsoft.Json;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.User
{
    public class Parameters
    {
        [JsonProperty("color_scheme")]
        public ColorScheme ColorScheme { get; set; }

        [JsonProperty("hfp_purchase")]
        public bool? HfpPurchase { get; set; }

        [JsonProperty("hires_purchases_streaming")]
        public bool? HiresPurchasesStreaming { get; set; }

        [JsonProperty("hires_streaming")]
        public bool? HiresStreaming { get; set; }

        [JsonProperty("included_format_group_ids")]
        public List<long?> IncludedFormatGroupIds { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("lossless_streaming")]
        public bool? LosslessStreaming { get; set; }

        [JsonProperty("lossy_streaming")]
        public bool? LossyStreaming { get; set; }

        [JsonProperty("mobile_streaming")]
        public bool? MobileStreaming { get; set; }

        [JsonProperty("offline_streaming")]
        public bool? OfflineStreaming { get; set; }

        [JsonProperty("short_label")]
        public string ShortLabel { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}