using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class SummarySegmentEffort : ISummarySegmentEffort
    {
        private SummarySegmentEffort() {}

        /// <summary>The unique identifier of this effort</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>The unique identifier of the activity related to this effort</summary>
        [JsonProperty("activity_id")]
        public long? ActivityId { get; private set; }

        /// <summary>The effort's elapsed time</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("elapsed_time")]
        public TimeSpan? ElapsedTime { get; private set; }

        /// <summary>The time at which the effort was started.</summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; private set; }

        /// <summary>The time at which the effort was started in the local timezone.</summary>
        [JsonProperty("start_date_local")]
        public DateTime? StartDateLocal { get; private set; }

        /// <summary>The effort's distance in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>Whether this effort is the current best on the leaderboard</summary>
        [JsonProperty("is_kom")]
        public bool? IsKom { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        public ResourceState? ResourceState => (ResourceState?)2;

    }
}

