using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Split
    {
        private Split() {}

        /// <summary>The average speed of this split, in meters per second</summary>
        [JsonProperty("average_speed")]
        public float? AverageSpeed { get; private set; }

        /// <summary>The distance of this split, in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The elapsed time of this split, in seconds</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("elapsed_time")]
        public TimeSpan? ElapsedTime { get; private set; }

        /// <summary>The elevation difference of this split, in meters</summary>
        [JsonProperty("elevation_difference")]
        public float? ElevationDifference { get; private set; }

        /// <summary>The pacing zone of this split</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("pace_zone")]
        public int? PaceZone { get; private set; }

        /// <summary>The moving time of this split, in seconds</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("moving_time")]
        public TimeSpan? MovingTime { get; private set; }

        /// <summary>N/A</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("split")]
        public int? Split_ { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("average_grade_adjusted_speed")]
        public float? AverageGradeAdjustedSpeed { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("average_heartrate")]
        public double? AverageHeartrate { get; private set; }

    }
}

