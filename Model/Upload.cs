using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Upload
    {
        private Upload() {}

        /// <summary>The unique identifier of the upload</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>The external identifier of the upload</summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; private set; }

        /// <summary>The error associated with this upload</summary>
        [JsonProperty("error")]
        public string Error { get; private set; }

        /// <summary>The status of this upload</summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>The identifier of the activity this upload resulted into</summary>
        [JsonProperty("activity_id")]
        public long? ActivityId { get; private set; }

    }
}

