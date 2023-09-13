using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class ActivityZone
    {
        private ActivityZone() {}

        /// <summary>An instance of integer.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("score")]
        public int? Score { get; private set; }

        /// <summary>An instance of #/TimedZoneDistribution.</summary>
        [JsonProperty("distribution_buckets")]
        public TimedZoneRange[] DistributionBuckets { get; private set; }

        /// <summary>May take one of the following values: heartrate, power</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type")]
        public ZoneType? Type { get; private set; }

        /// <summary>An instance of boolean.</summary>
        [JsonProperty("sensor_based")]
        public bool? SensorBased { get; private set; }

        /// <summary>An instance of integer.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("points")]
        public int? Points { get; private set; }

        /// <summary>An instance of boolean.</summary>
        [JsonProperty("custom_zones")]
        public bool? CustomZones { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

    }
}

