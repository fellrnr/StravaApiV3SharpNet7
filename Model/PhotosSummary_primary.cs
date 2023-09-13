using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class PhotosSummary_primary
    {
        private PhotosSummary_primary() {}

        /// <summary>An instance of long.</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>An instance of integer.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("source")]
        public int? Source { get; private set; }

        /// <summary>An instance of string.</summary>
        [JsonProperty("unique_id")]
        public string UniqueId { get; private set; }

        /// <summary>An instance of string.</summary>
        [JsonProperty("urls")]
        public System.Collections.Generic.Dictionary<int, Uri> Urls { get; private set; }

    }
}

