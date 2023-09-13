using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Lap
    {
        private Lap() {}

        /// <summary>The unique identifier of this lap</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>An instance of MetaActivity.</summary>
        [JsonProperty("activity")]
        public MetaActivity Activity { get; private set; }

        /// <summary>An instance of MetaAthlete.</summary>
        [JsonProperty("athlete")]
        public MetaAthlete Athlete { get; private set; }

        /// <summary>The lap's average cadence</summary>
        [JsonProperty("average_cadence")]
        public float? AverageCadence { get; private set; }

        /// <summary>The lap's average speed</summary>
        [JsonProperty("average_speed")]
        public float? AverageSpeed { get; private set; }

        /// <summary>The lap's distance, in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The lap's elapsed time, in seconds</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("elapsed_time")]
        public TimeSpan? ElapsedTime { get; private set; }

        /// <summary>The start index of this effort in its activity's stream</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("start_index")]
        public int? StartIndex { get; private set; }

        /// <summary>The end index of this effort in its activity's stream</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("end_index")]
        public int? EndIndex { get; private set; }

        /// <summary>The index of this lap in the activity it belongs to</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("lap_index")]
        public int? LapIndex { get; private set; }

        /// <summary>The maximum speed of this lat, in meters per second</summary>
        [JsonProperty("max_speed")]
        public float? MaxSpeed { get; private set; }

        /// <summary>The lap's moving time, in seconds</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("moving_time")]
        public TimeSpan? MovingTime { get; private set; }

        /// <summary>The name of the lap</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>The athlete's pace zone during this lap</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("pace_zone")]
        public int? PaceZone { get; private set; }

        /// <summary>An instance of integer.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("split")]
        public int? Split { get; private set; }

        /// <summary>The time at which the lap was started.</summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; private set; }

        /// <summary>The time at which the lap was started in the local timezone.</summary>
        [JsonProperty("start_date_local")]
        public DateTime? StartDateLocal { get; private set; }

        /// <summary>The elevation gain of this lap, in meters</summary>
        [JsonProperty("total_elevation_gain")]
        public float? TotalElevationGain { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("average_heartrate")]
        public float? AverageHeartrate { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("max_heartrate")]
        public float? MaxHeartrate { get; private set; }

    }
}

