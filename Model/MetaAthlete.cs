using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class MetaAthlete : IMetaAthlete
    {
        private MetaAthlete() {}

        /// <summary>The unique identifier of the athlete</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>The athlete's first name.</summary>
        [JsonProperty("firstname")]
        public string Firstname { get; private set; }

        /// <summary>The athlete's last name.</summary>
        [JsonProperty("lastname")]
        public string Lastname { get; private set; }

    }
}

