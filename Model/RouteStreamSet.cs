using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Model is not described on the Api-Website</summary>
    [JsonConverter(typeof(Util.RouteStreamSetConverter))]
    public class RouteStreamSet : IRouteStreamSet
    {
        private RouteStreamSet() {}

        /// <summary>An instance of DistanceStream.</summary>
        [JsonProperty("distance")]
        public DistanceStream Distance { get; private set; }

        /// <summary>An instance of LatLngStream.</summary>
        [JsonProperty("latlng")]
        public LatLngStream Latlng { get; private set; }

        /// <summary>An instance of AltitudeStream.</summary>
        [JsonProperty("altitude")]
        public AltitudeStream Altitude { get; private set; }

    }
}

