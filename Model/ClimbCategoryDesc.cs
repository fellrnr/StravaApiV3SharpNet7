using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values climb_category_desc can have</summary>
    public enum ClimbCategoryDesc
    {
        [EnumMember(Value = "NC")]
        NC,
        [EnumMember(Value = "4")]
        _4,
        [EnumMember(Value = "3")]
        _3,
        [EnumMember(Value = "2")]
        _2,
        [EnumMember(Value = "1")]
        _1,
        [EnumMember(Value = "HC")]
        HC,
    }
}

