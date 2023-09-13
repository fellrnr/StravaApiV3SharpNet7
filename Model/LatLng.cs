using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>A collection of float objects. A pair of latitude/longitude coordinates, represented as an array of 2 floating point numbers.</summary>
    [JsonConverter(typeof(Util.LatLngConverter))]
    public class LatLng
    {
        private LatLng() {}

        /// <summary>The latitude of the GPS coordinates</summary>
        [JsonProperty("lat")]
        public double? Lat { get; private set; }

        /// <summary>The latitude of the GPS coordinates</summary>
        [JsonProperty("lng")]
        public double? Lng { get; private set; }

    }
}

