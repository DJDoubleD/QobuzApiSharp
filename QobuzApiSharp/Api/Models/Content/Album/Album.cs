using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace QobuzApiSharp.Models.Content
{
    public class Album : MostPopularContent
    {
        [JsonProperty("albums_same_artist")]
        public AlbumsSameArtist AlbumsSameArtist { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("awards")]
        public List<Award> Awards { get; set; }

        [JsonProperty("catchline")]
        public string Catchline { get; set; }

        [JsonProperty("composer")]
        public Artist Composer { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("created_at")]
        public long? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayable")]
        public bool? Displayable { get; set; }

        [JsonProperty("downloadable")]
        public bool? Downloadable { get; set; }

        [JsonProperty("duration")]
        public long? Duration { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("genres_list")]
        public List<string> GenresList { get; set; }

        [JsonProperty("goodies")]
        public List<Goody> Goodies { get; set; }

        [JsonProperty("hires")]
        public bool? Hires { get; set; }

        [JsonProperty("hires_streamable")]
        public bool? HiresStreamable { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("is_official")]
        public bool? IsOfficial { get; set; }

        [JsonProperty("items_focus")]
        public List<Focus> ItemsFocus { get; set; }

        [JsonProperty("label")]
        public Label Label { get; set; }

        [JsonProperty("maximum_bit_depth")]
        public double? MaximumBitDepth { get; set; }

        [JsonProperty("maximum_channel_count")]
        public double? MaximumChannelCount { get; set; }

        [JsonProperty("maximum_sampling_rate")]
        public double? MaximumSamplingRate { get; set; }

        [JsonProperty("maximum_technical_specifications")]
        public string MaximumTechnicalSpecifications { get; set; }

        [JsonProperty("media_count")]
        public int? MediaCount { get; set; }

        [JsonProperty("parental_warning")]
        public bool? ParentalWarning { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("popularity")]
        public int? Popularity { get; set; }

        [JsonProperty("previewable")]
        public bool? Previewable { get; set; }

        [JsonProperty("product_sales_factors_monthly")]
        public double? ProductSalesFactorsMonthly { get; set; }

        [JsonProperty("product_sales_factors_weekly")]
        public double? ProductSalesFactorsWeekly { get; set; }

        [JsonProperty("product_sales_factors_yearly")]
        public double? ProductSalesFactorsYearly { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        [JsonProperty("purchasable")]
        public bool? Purchasable { get; set; }

        [JsonProperty("purchasable_at")]
        public long? PurchasableAt { get; set; }

        [JsonProperty("qobuz_id")]
        public int? QobuzId { get; set; }

        [JsonProperty("recording_information")]
        public string RecordingInformation { get; set; }

        [JsonProperty("relative_url")]
        public string RelativeUrl { get; set; }

        [JsonProperty("released_at")]
        public long? ReleasedAt { get; set; }

        [JsonProperty("release_date_download")]
        public DateTimeOffset? ReleaseDateDownload { get; set; }

        [JsonProperty("release_date_original")]
        public DateTimeOffset? ReleaseDateOriginal { get; set; }

        [JsonProperty("release_date_stream")]
        public DateTimeOffset? ReleaseDateStream { get; set; }

        [JsonProperty("release_tags")]
        public List<object> ReleaseTags { get; set; }

        [JsonProperty("release_type")]
        public string ReleaseType { get; set; }

        [JsonProperty("sampleable")]
        public bool? Sampleable { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("streamable")]
        public bool? Streamable { get; set; }

        [JsonProperty("streamable_at")]
        public long? StreamableAt { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("track_ids")]
        public List<int> TrackIds { get; set; }

        [JsonProperty("tracks")]
        public ItemSearchResult<Track> Tracks { get; set; }

        [JsonProperty("tracks_count")]
        public int? TracksCount { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}