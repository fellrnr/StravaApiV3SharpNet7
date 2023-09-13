using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class PolylineMap
    {
        private PolylineMap() {}

        /// <summary>The identifier of the map</summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>The polyline of the map, only returned on detailed representation of an object</summary>
        [JsonProperty("polyline")]
        public string Polyline { get; private set; }

        /// <summary>The summary polyline of the map</summary>
        [JsonProperty("summary_polyline")]
        public string SummaryPolyline { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

    }
}

