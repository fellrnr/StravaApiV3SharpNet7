using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Error
    {
        private Error() {}

        /// <summary>The code associated with this error.</summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        /// <summary>The specific field or aspect of the resource associated with this error.</summary>
        [JsonProperty("field")]
        public string Field { get; private set; }

        /// <summary>The type of resource associated with this error.</summary>
        [JsonProperty("resource")]
        public string Resource { get; private set; }

    }
}

