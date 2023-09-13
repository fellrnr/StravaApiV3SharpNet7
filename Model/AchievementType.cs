using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of the types an achievement can have.</summary>
    public enum AchievementType
    {
        [EnumMember(Value = "overall")]
        Overall,
        [EnumMember(Value = "pr")]
        PersonalRecord,
        [EnumMember(Value = "segment_effort_count_leader")]
        SegmentEffortCountLeader,
    }
}

