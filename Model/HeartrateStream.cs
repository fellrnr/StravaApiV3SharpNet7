using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class HeartrateStream : IStream
    {
        private HeartrateStream() {}

        /// <summary>The number of data points in this stream</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("original_size")]
        public int? OriginalSize { get; private set; }

        /// <summary>The level of detail (sampling) in which this stream was returned May take one of the following values: low, medium, high</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("resolution")]
        public Resolution? Resolution { get; private set; }

        /// <summary>The base series used in the case the stream was downsampled May take one of the following values: distance, time</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("series_type")]
        public SeriesType? SeriesType { get; private set; }

        /// <summary>The sequence of heart rate values for this stream, in beats per minute</summary>
        [JsonConverter(typeof(Util.DoubleToIntArrayConverter))]
        [JsonProperty("data")]
        public int[] Data 
        {
            get => (int[])_Data?.Clone();
            private set => _Data = value;
        }
        private int[] _Data;

    }
}

