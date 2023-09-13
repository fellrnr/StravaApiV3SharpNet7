using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values activity_type can have</summary>
    public enum ActivityTypeRunningRiding
    {
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "riding")]
        Riding,
    }
}

