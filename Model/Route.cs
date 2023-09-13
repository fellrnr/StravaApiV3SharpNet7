using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Route
    {
        private Route() {}

        /// <summary>An instance of SummaryAthlete.</summary>
        [JsonProperty("athlete")]
        public SummaryAthlete Athlete { get; private set; }

        /// <summary>The description of the route</summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>The route's distance, in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The route's elevation gain.</summary>
        [JsonProperty("elevation_gain")]
        public float? ElevationGain { get; private set; }

        /// <summary>The unique identifier of this route</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>An instance of PolylineMap.</summary>
        [JsonProperty("map")]
        public PolylineMap Map { get; private set; }

        /// <summary>The name of this route</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>Whether this route is private</summary>
        [JsonProperty("private")]
        public bool? Private { get; private set; }

        /// <summary>Whether this route is starred by the logged-in athlete</summary>
        [JsonProperty("starred")]
        public bool? Starred { get; private set; }

        /// <summary>An epoch timestamp of when the route was created</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("timestamp")]
        public int? Timestamp { get; private set; }

        /// <summary>This route's type (1 for ride, 2 for runs)</summary>
        [JsonProperty("type")]
        public ActivityTypeRideRunWalk? Type { get; private set; }

        /// <summary>This route's sub-type (1 for road, 2 for mountain bike, 3 for cross, 4 for trail, 5 for mixed)</summary>
        [JsonProperty("sub_type")]
        public ActivitySubType? SubType { get; private set; }

        /// <summary>The time at which the route was created</summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>The time at which the route was last updated</summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>Estimated time in seconds for the authenticated athlete to complete route</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("estimated_moving_time")]
        public TimeSpan? EstimatedMovingTime { get; private set; }

        /// <summary>The segments traversed by this route</summary>
        [JsonProperty("segments")]
        public SummarySegment[] Segments 
        {
            get => (SummarySegment[])_Segments?.Clone();
            private set => _Segments = value;
        }
        private SummarySegment[] _Segments;

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

    }
}

