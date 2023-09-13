using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values measurement_preference can have</summary>
    public enum MeasurementPreference
    {
        [EnumMember(Value = "feet")]
        Feet,
        [EnumMember(Value = "meters")]
        Meters,
    }
}

