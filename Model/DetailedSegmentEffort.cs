using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class DetailedSegmentEffort : ISummarySegmentEffort
    {
        private DetailedSegmentEffort() {}

        /// <summary>The unique identifier of this effort</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

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

        /// <summary>The name of the segment on which this effort was performed</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>An instance of MetaActivity.</summary>
        [JsonProperty("activity")]
        public MetaActivity Activity { get; private set; }

        /// <summary>An instance of MetaAthlete.</summary>
        [JsonProperty("athlete")]
        public MetaAthlete Athlete { get; private set; }

        /// <summary>The effort's moving time</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("moving_time")]
        public TimeSpan? MovingTime { get; private set; }

        /// <summary>The start index of this effort in its activity's stream</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("start_index")]
        public int? StartIndex { get; private set; }

        /// <summary>The end index of this effort in its activity's stream</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("end_index")]
        public int? EndIndex { get; private set; }

        /// <summary>The effort's average cadence</summary>
        [JsonProperty("average_cadence")]
        public float? AverageCadence { get; private set; }

        /// <summary>The average wattage of this effort</summary>
        [JsonProperty("average_watts")]
        public float? AverageWatts { get; private set; }

        /// <summary>For riding efforts, whether the wattage was reported by a dedicated recording device</summary>
        [JsonProperty("device_watts")]
        public bool? DeviceWatts { get; private set; }

        /// <summary>The heart heart rate of the athlete during this effort</summary>
        [JsonProperty("average_heartrate")]
        public float? AverageHeartrate { get; private set; }

        /// <summary>The maximum heart rate of the athlete during this effort</summary>
        [JsonProperty("max_heartrate")]
        public float? MaxHeartrate { get; private set; }

        /// <summary>An instance of SummarySegment.</summary>
        [JsonProperty("segment")]
        public SummarySegment Segment { get; private set; }

        /// <summary>The rank of the effort on the global leaderboard if it belongs in the top 10 at the time of upload</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("kom_rank")]
        public int? KomRank { get; private set; }

        /// <summary>The rank of the effort on the athlete's leaderboard if it belongs in the top 3 at the time of upload</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("pr_rank")]
        public int? PrRank { get; private set; }

        /// <summary>Whether this effort should be hidden when viewed within an activity</summary>
        [JsonProperty("hidden")]
        public bool? Hidden { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("achievements")]
        public Achievement[] Achievements 
        {
            get => (Achievement[])_Achievements?.Clone();
            private set => _Achievements = value;
        }
        private Achievement[] _Achievements;

        /// <summary>The statistics of the logged-in athlete for this segment</summary>
        [JsonProperty("athlete_segment_stats")]
        public SummaryPRSegmentEffort AthleteSegmentStats { get; private set; }

    }
}

