using Newtonsoft.Json;
using System;

namespace QobuzApiSharp.Models.User
{
    public class Subscription
    {
        [JsonProperty("end_date")]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty("household_size_max")]
        public long? HouseholdSizeMax { get; set; }

        [JsonProperty("is_canceled")]
        public bool? IsCanceled { get; set; }

        [JsonProperty("offer")]
        public string Offer { get; set; }

        [JsonProperty("periodicity")]
        public string Periodicity { get; set; }

        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; set; }
    }
}