using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class SummarySegment : ISummarySegment
    {
        private SummarySegment() {}

        /// <summary>The unique identifier of this segment</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>The name of this segment</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>May take one of the following values: Ride, Run</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("activity_type")]
        public ActivityType? ActivityType { get; private set; }

        /// <summary>The segment's distance, in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The segment's average grade, in percents</summary>
        [JsonProperty("average_grade")]
        public float? AverageGrade { get; private set; }

        /// <summary>The segments's maximum grade, in percents</summary>
        [JsonProperty("maximum_grade")]
        public float? MaximumGrade { get; private set; }

        /// <summary>The segments's highest elevation, in meters</summary>
        [JsonProperty("elevation_high")]
        public float? ElevationHigh { get; private set; }

        /// <summary>The segments's lowest elevation, in meters</summary>
        [JsonProperty("elevation_low")]
        public float? ElevationLow { get; private set; }

        /// <summary>An instance of LatLng.</summary>
        [JsonProperty("start_latlng")]
        public LatLng StartLatlng { get; private set; }

        /// <summary>An instance of LatLng.</summary>
        [JsonProperty("end_latlng")]
        public LatLng EndLatlng { get; private set; }

        /// <summary>The category of the climb [0, 5]. Higher is harder ie. 5 is Hors catégorie, 0 is uncategorized in climb_category.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("climb_category")]
        public int? ClimbCategory { get; private set; }

        /// <summary>The segments's city.</summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>The segments's state or geographical region.</summary>
        [JsonProperty("state")]
        public string State { get; private set; }

        /// <summary>The segment's country.</summary>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>Whether this segment is private.</summary>
        [JsonProperty("private")]
        public bool? Private { get; private set; }

        /// <summary>An instance of SummarySegmentEffort.</summary>
        [JsonProperty("athlete_pr_effort")]
        public SummarySegmentEffort AthletePrEffort { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Whether this segment is marked as hazardous</summary>
        [JsonProperty("hazardous")]
        public bool? Hazardous { get; private set; }

        /// <summary>Whether this segment is starred by the logged-in athlete</summary>
        [JsonProperty("starred")]
        public bool? Starred { get; private set; }

        /// <summary>The date this segment was starred by the logged-in athlete</summary>
        [JsonProperty("starred_date")]
        public DateTime? StarredDate { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("pr_time")]
        public TimeSpan? PrTime { get; private set; }

    }
}

