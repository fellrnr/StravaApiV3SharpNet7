using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class ExplorerResponse
    {
        private ExplorerResponse() {}

        /// <summary>The set of segments matching an explorer request</summary>
        [JsonProperty("segments")]
        public ExplorerSegment[] Segments 
        {
            get => (ExplorerSegment[])_Segments?.Clone();
            private set => _Segments = value;
        }
        private ExplorerSegment[] _Segments;

    }
}

