using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values sport_type can have</summary>
    public enum SportType
    {
        [EnumMember(Value = "cycling")]
        Cycling,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "triathlon")]
        Triathlon,
        [EnumMember(Value = "other")]
        Other,
    }
}

