using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class StreamSet : IRouteStreamSet
    {
        private StreamSet() {}

        /// <summary>An instance of TimeStream.</summary>
        [JsonProperty("time")]
        public TimeStream Time { get; private set; }

        /// <summary>An instance of DistanceStream.</summary>
        [JsonProperty("distance")]
        public DistanceStream Distance { get; private set; }

        /// <summary>An instance of LatLngStream.</summary>
        [JsonProperty("latlng")]
        public LatLngStream Latlng { get; private set; }

        /// <summary>An instance of AltitudeStream.</summary>
        [JsonProperty("altitude")]
        public AltitudeStream Altitude { get; private set; }

        /// <summary>An instance of SmoothVelocityStream.</summary>
        [JsonProperty("velocity_smooth")]
        public SmoothVelocityStream VelocitySmooth { get; private set; }

        /// <summary>An instance of HeartrateStream.</summary>
        [JsonProperty("heartrate")]
        public HeartrateStream Heartrate { get; private set; }

        /// <summary>An instance of CadenceStream.</summary>
        [JsonProperty("cadence")]
        public CadenceStream Cadence { get; private set; }

        /// <summary>An instance of PowerStream.</summary>
        [JsonProperty("watts")]
        public PowerStream Watts { get; private set; }

        /// <summary>An instance of TemperatureStream.</summary>
        [JsonProperty("temp")]
        public TemperatureStream Temp { get; private set; }

        /// <summary>An instance of MovingStream.</summary>
        [JsonProperty("moving")]
        public MovingStream Moving { get; private set; }

        /// <summary>An instance of SmoothGradeStream.</summary>
        [JsonProperty("grade_smooth")]
        public SmoothGradeStream GradeSmooth { get; private set; }

    }
}

