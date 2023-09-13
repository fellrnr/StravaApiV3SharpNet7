using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class ZoneRange
    {
        private ZoneRange() {}

        /// <summary>The minimum value in the range.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("min")]
        public int? Min { get; private set; }

        /// <summary>The maximum value in the range.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("max")]
        public int? Max { get; private set; }

    }
}

