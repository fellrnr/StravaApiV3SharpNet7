using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values sex can have</summary>
    public enum Gender
    {
        [EnumMember(Value = "M")]
        M,
        [EnumMember(Value = "F")]
        F,
    }
}

