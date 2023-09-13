using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class PhotosSummary
    {
        private PhotosSummary() {}

        /// <summary>The number of photos</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("count")]
        public int? Count { get; private set; }

        /// <summary>An instance of PhotosSummary_primary.</summary>
        [JsonProperty("primary")]
        public PhotosSummary_primary Primary { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("use_primary_photo")]
        public bool? UsePrimaryPhoto { get; private set; }

    }
}

