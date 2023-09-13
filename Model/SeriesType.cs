using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values series_type can have</summary>
    public enum SeriesType
    {
        [EnumMember(Value = "distance")]
        Distance,
        [EnumMember(Value = "time")]
        Time,
    }
}

