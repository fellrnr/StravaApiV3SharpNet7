using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class SummaryGear : ISummaryGear
    {
        private SummaryGear() {}

        /// <summary>The gear's unique identifier.</summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 2 -> "summary", 3 -> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Whether this gear's is the owner's default one.</summary>
        [JsonProperty("primary")]
        public bool? Primary { get; private set; }

        /// <summary>The gear's name.</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>The distance logged with this gear.</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The given nickname to the gear</summary>
        [JsonProperty("nickname")]
        public string Nickname { get; private set; }

        /// <summary>Whether the gear is marked as retired</summary>
        [JsonProperty("retired")]
        public bool? Retired { get; private set; }

    }
}

