using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>A union type representing the time spent in a given zone.</summary>
    public class TimedZoneRange
    {
        private TimedZoneRange() {}

        /// <summary>The minimum value in the range.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("min")]
        public int? Min { get; private set; }

        /// <summary>The maximum value in the range.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("max")]
        public int? Max { get; private set; }

        /// <summary>The number of seconds spent in this zone</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("time")]
        public int? Time { get; private set; }

    }
}

