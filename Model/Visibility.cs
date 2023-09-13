using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of the possible visibility settings.</summary>
    public enum Visibility
    {
        [EnumMember(Value = "only_me")]
        OnlyMe,
        [EnumMember(Value = "followers_only")]
        FollowersOnly,
        [EnumMember(Value = "everyone")]
        Everyone,
    }
}

