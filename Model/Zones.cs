using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Zones
    {
        private Zones() {}

        /// <summary>An instance of HeartRateZoneRanges.</summary>
        [JsonProperty("heart_rate")]
        public HeartRateZoneRanges HeartRate { get; private set; }

        /// <summary>An instance of PowerZoneRanges.</summary>
        [JsonProperty("power")]
        public PowerZoneRanges Power { get; private set; }

    }
}

