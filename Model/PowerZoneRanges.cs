using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class PowerZoneRanges
    {
        private PowerZoneRanges() {}

        /// <summary>An instance of ZoneRanges.</summary>
        [JsonProperty("zones")]
        public ZoneRange[] Zones { get; private set; }

    }
}

