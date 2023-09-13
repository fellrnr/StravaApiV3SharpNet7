using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>A roll-up of metrics pertaining to a set of activities. Values are in seconds and meters.</summary>
    public class ActivityTotal
    {
        private ActivityTotal() {}

        /// <summary>The number of activities considered in this total.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("count")]
        public int? Count { get; private set; }

        /// <summary>The total distance covered by the considered activities.</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The total moving time of the considered activities.</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("moving_time")]
        public TimeSpan? MovingTime { get; private set; }

        /// <summary>The total elapsed time of the considered activities.</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("elapsed_time")]
        public TimeSpan? ElapsedTime { get; private set; }

        /// <summary>The total elevation gain of the considered activities.</summary>
        [JsonProperty("elevation_gain")]
        public float? ElevationGain { get; private set; }

        /// <summary>The total number of achievements of the considered activities.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("achievement_count")]
        public int? AchievementCount { get; private set; }

    }
}

