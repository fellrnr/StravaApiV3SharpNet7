using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values resolution can have</summary>
    public enum Resolution
    {
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "high")]
        High,
    }
}

