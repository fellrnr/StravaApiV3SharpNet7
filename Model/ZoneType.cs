using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values type can have</summary>
    public enum ZoneType
    {
        [EnumMember(Value = "heartrate")]
        Heartrate,
        [EnumMember(Value = "power")]
        Power,
    }
}

