using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>The available streams</summary>
    [System.Flags]
    public enum StreamTypes
    {
        /// <summary>
        /// An instance of TimeStream.
        /// </summary>
        [EnumMember(Value = "time")]
        Time = 1,
        /// <summary>
        /// An instance of DistanceStream.
        /// </summary>
        [EnumMember(Value = "distance")]
        Distance = 2,
        /// <summary>
        /// An instance of LatLngStream.
        /// </summary>
        [EnumMember(Value = "latlng")]
        Latlng = 4,
        /// <summary>
        /// An instance of AltitudeStream.
        /// </summary>
        [EnumMember(Value = "altitude")]
        Altitude = 8,
        /// <summary>
        /// An instance of SmoothVelocityStream.
        /// </summary>
        [EnumMember(Value = "velocity_smooth")]
        VelocitySmooth = 16,
        /// <summary>
        /// An instance of HeartrateStream.
        /// </summary>
        [EnumMember(Value = "heartrate")]
        Heartrate = 32,
        /// <summary>
        /// An instance of CadenceStream.
        /// </summary>
        [EnumMember(Value = "cadence")]
        Cadence = 64,
        /// <summary>
        /// An instance of PowerStream.
        /// </summary>
        [EnumMember(Value = "watts")]
        Watts = 128,
        /// <summary>
        /// An instance of TemperatureStream.
        /// </summary>
        [EnumMember(Value = "temp")]
        Temp = 256,
        /// <summary>
        /// An instance of MovingStream.
        /// </summary>
        [EnumMember(Value = "moving")]
        Moving = 512,
        /// <summary>
        /// An instance of SmoothGradeStream.
        /// </summary>
        [EnumMember(Value = "grade_smooth")]
        GradeSmooth = 1024,
    }
}

