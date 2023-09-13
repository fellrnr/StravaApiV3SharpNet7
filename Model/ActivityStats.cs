using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>A set of rolled-up statistics and totals for an athlete</summary>
    public class ActivityStats
    {
        private ActivityStats() {}

        /// <summary>The longest distance ridden by the athlete.</summary>
        [JsonProperty("biggest_ride_distance")]
        public double? BiggestRideDistance { get; private set; }

        /// <summary>The highest climb ridden by the athlete.</summary>
        [JsonProperty("biggest_climb_elevation_gain")]
        public double? BiggestClimbElevationGain { get; private set; }

        /// <summary>The recent (last 4 weeks) ride stats for the athlete.</summary>
        [JsonProperty("recent_ride_totals")]
        public ActivityTotal RecentRideTotals { get; private set; }

        /// <summary>The recent (last 4 weeks) run stats for the athlete.</summary>
        [JsonProperty("recent_run_totals")]
        public ActivityTotal RecentRunTotals { get; private set; }

        /// <summary>The recent (last 4 weeks) swim stats for the athlete.</summary>
        [JsonProperty("recent_swim_totals")]
        public ActivityTotal RecentSwimTotals { get; private set; }

        /// <summary>The year to date ride stats for the athlete.</summary>
        [JsonProperty("ytd_ride_totals")]
        public ActivityTotal YtdRideTotals { get; private set; }

        /// <summary>The year to date run stats for the athlete.</summary>
        [JsonProperty("ytd_run_totals")]
        public ActivityTotal YtdRunTotals { get; private set; }

        /// <summary>The year to date swim stats for the athlete.</summary>
        [JsonProperty("ytd_swim_totals")]
        public ActivityTotal YtdSwimTotals { get; private set; }

        /// <summary>The all time ride stats for the athlete.</summary>
        [JsonProperty("all_ride_totals")]
        public ActivityTotal AllRideTotals { get; private set; }

        /// <summary>The all time run stats for the athlete.</summary>
        [JsonProperty("all_run_totals")]
        public ActivityTotal AllRunTotals { get; private set; }

        /// <summary>The all time swim stats for the athlete.</summary>
        [JsonProperty("all_swim_totals")]
        public ActivityTotal AllSwimTotals { get; private set; }

    }
}

