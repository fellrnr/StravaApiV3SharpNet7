using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class HeartRateZoneRanges
    {
        private HeartRateZoneRanges() {}

        /// <summary>Whether the athlete has set their own custom heart rate zones</summary>
        [JsonProperty("custom_zones")]
        public bool? CustomZones { get; private set; }

        /// <summary>An instance of ZoneRanges.</summary>
        [JsonProperty("zones")]
        public ZoneRange[] Zones { get; private set; }

    }
}

