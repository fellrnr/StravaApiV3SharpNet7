using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of the sport types an activity may have. Distinct from ActivityType in that it has new types (e.g. MountainBikeRide)</summary>
    public enum ActivitySportType
    {
        [EnumMember(Value = "AlpineSki")]
        AlpineSki,
        [EnumMember(Value = "BackcountrySki")]
        BackcountrySki,
        [EnumMember(Value = "Canoeing")]
        Canoeing,
        [EnumMember(Value = "Crossfit")]
        Crossfit,
        [EnumMember(Value = "EBikeRide")]
        EBikeRide,
        [EnumMember(Value = "Elliptical")]
        Elliptical,
        [EnumMember(Value = "EMountainBikeRide")]
        EMountainBikeRide,
        [EnumMember(Value = "Golf")]
        Golf,
        [EnumMember(Value = "GravelRide")]
        GravelRide,
        [EnumMember(Value = "Handcycle")]
        Handcycle,
        [EnumMember(Value = "Hike")]
        Hike,
        [EnumMember(Value = "IceSkate")]
        IceSkate,
        [EnumMember(Value = "InlineSkate")]
        InlineSkate,
        [EnumMember(Value = "Kayaking")]
        Kayaking,
        [EnumMember(Value = "Kitesurf")]
        Kitesurf,
        [EnumMember(Value = "MountainBikeRide")]
        MountainBikeRide,
        [EnumMember(Value = "NordicSki")]
        NordicSki,
        [EnumMember(Value = "Ride")]
        Ride,
        [EnumMember(Value = "RockClimbing")]
        RockClimbing,
        [EnumMember(Value = "RollerSki")]
        RollerSki,
        [EnumMember(Value = "Rowing")]
        Rowing,
        [EnumMember(Value = "Run")]
        Run,
        [EnumMember(Value = "Sail")]
        Sail,
        [EnumMember(Value = "Skateboard")]
        Skateboard,
        [EnumMember(Value = "Snowboard")]
        Snowboard,
        [EnumMember(Value = "Snowshoe")]
        Snowshoe,
        [EnumMember(Value = "Soccer")]
        Soccer,
        [EnumMember(Value = "StairStepper")]
        StairStepper,
        [EnumMember(Value = "StandUpPaddling")]
        StandUpPaddling,
        [EnumMember(Value = "Surfing")]
        Surfing,
        [EnumMember(Value = "Swim")]
        Swim,
        [EnumMember(Value = "TrailRun")]
        TrailRun,
        [EnumMember(Value = "Velomobile")]
        Velomobile,
        [EnumMember(Value = "VirtualRide")]
        VirtualRide,
        [EnumMember(Value = "VirtualRun")]
        VirtualRun,
        [EnumMember(Value = "Walk")]
        Walk,
        [EnumMember(Value = "WeightTraining")]
        WeightTraining,
        [EnumMember(Value = "Wheelchair")]
        Wheelchair,
        [EnumMember(Value = "Windsurf")]
        Windsurf,
        [EnumMember(Value = "Workout")]
        Workout,
        [EnumMember(Value = "Yoga")]
        Yoga,
    }
}

