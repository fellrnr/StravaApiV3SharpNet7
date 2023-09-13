using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values membership can have</summary>
    public enum Membership
    {
        [EnumMember(Value = "member")]
        Member,
        [EnumMember(Value = "pending")]
        Pending,
    }
}

