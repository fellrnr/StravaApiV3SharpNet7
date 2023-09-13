using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Encapsulates the errors that may be returned from the API.</summary>
    public class Fault
    {
        private Fault() {}

        /// <summary>The set of specific errors associated with this fault, if any.</summary>
        [JsonProperty("errors")]
        public Error[] Errors 
        {
            get => (Error[])_Errors?.Clone();
            private set => _Errors = value;
        }
        private Error[] _Errors;

        /// <summary>The message of the fault.</summary>
        [JsonProperty("message")]
        public string Message { get; private set; }

    }
}

