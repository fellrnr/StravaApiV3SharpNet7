using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class SummaryPRSegmentEffort
    {
        private SummaryPRSegmentEffort() {}

        /// <summary>The unique identifier of the activity related to the PR effort.</summary>
        [JsonProperty("pr_activity_id")]
        public long? PrActivityId { get; private set; }

        /// <summary>The elapsed time ot the PR effort.</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("pr_elapsed_time")]
        public TimeSpan? PrElapsedTime { get; private set; }

        /// <summary>The time at which the PR effort was started.</summary>
        [JsonProperty("pr_date")]
        public DateTime? PrDate { get; private set; }

        /// <summary>Number of efforts by the authenticated athlete on this segment.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("effort_count")]
        public int? EffortCount { get; private set; }

    }
}

