using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="SummaryActivity"/> and <see cref="DetailedActivity"/></summary>
    public interface ISummaryActivity
    {

        /// <summary>The unique identifier of the activity</summary>
        long? Id { get; }

        /// <summary>The identifier provided at upload time</summary>
        string ExternalId { get; }

        /// <summary>The identifier of the upload that resulted in this activity</summary>
        long? UploadId { get; }

        /// <summary>An instance of MetaAthlete.</summary>
        MetaAthlete Athlete { get; }

        /// <summary>The name of the activity</summary>
        string Name { get; }

        /// <summary>The activity's distance, in meters</summary>
        float? Distance { get; }

        /// <summary>The activity's moving time, in seconds</summary>
        TimeSpan? MovingTime { get; }

        /// <summary>The activity's elapsed time, in seconds</summary>
        TimeSpan? ElapsedTime { get; }

        /// <summary>The activity's total elevation gain.</summary>
        float? TotalElevationGain { get; }

        /// <summary>The activity's highest elevation, in meters</summary>
        float? ElevHigh { get; }

        /// <summary>The activity's lowest elevation, in meters</summary>
        float? ElevLow { get; }

        /// <summary>Deprecated. Prefer to use sport_type</summary>
        ActivityType? Type { get; }

        /// <summary>An instance of SportType.</summary>
        ActivitySportType? SportType { get; }

        /// <summary>The time at which the activity was started.</summary>
        DateTime? StartDate { get; }

        /// <summary>The time at which the activity was started in the local timezone.</summary>
        DateTime? StartDateLocal { get; }

        /// <summary>The timezone of the activity</summary>
        string Timezone { get; }

        /// <summary>An instance of LatLng.</summary>
        LatLng StartLatlng { get; }

        /// <summary>An instance of LatLng.</summary>
        LatLng EndLatlng { get; }

        /// <summary>The number of achievements gained during this activity</summary>
        int? AchievementCount { get; }

        /// <summary>The number of kudos given for this activity</summary>
        int? KudosCount { get; }

        /// <summary>The number of comments for this activity</summary>
        int? CommentCount { get; }

        /// <summary>The number of athletes for taking part in a group activity</summary>
        int? AthleteCount { get; }

        /// <summary>The number of Instagram photos for this activity</summary>
        int? PhotoCount { get; }

        /// <summary>The number of Instagram and Strava photos for this activity</summary>
        int? TotalPhotoCount { get; }

        /// <summary>An instance of PolylineMap.</summary>
        PolylineMap Map { get; }

        /// <summary>Whether this activity was recorded on a training machine</summary>
        bool? Trainer { get; }

        /// <summary>Whether this activity is a commute</summary>
        bool? Commute { get; }

        /// <summary>Whether this activity was created manually</summary>
        bool? Manual { get; }

        /// <summary>Whether this activity is private</summary>
        bool? Private { get; }

        /// <summary>Whether this activity is flagged</summary>
        bool? Flagged { get; }

        /// <summary>The activity's workout type</summary>
        WorkoutType? WorkoutType { get; }

        /// <summary>The unique identifier of the upload in string format</summary>
        string UploadIdStr { get; }

        /// <summary>The activity's average speed, in meters per second</summary>
        float? AverageSpeed { get; }

        /// <summary>The activity's max speed, in meters per second</summary>
        float? MaxSpeed { get; }

        /// <summary>Whether the logged-in athlete has kudoed this activity</summary>
        bool? HasKudoed { get; }

        /// <summary>The id of the gear for the activity</summary>
        string GearId { get; }

        /// <summary>The total work done in kilojoules during this activity. Rides only</summary>
        float? Kilojoules { get; }

        /// <summary>Average power output in watts during this activity. Rides only</summary>
        float? AverageWatts { get; }

        /// <summary>Whether the watts are from a power meter, false if estimated</summary>
        bool? DeviceWatts { get; }

        /// <summary>Rides with power meter data only</summary>
        int? MaxWatts { get; }

        /// <summary>Similar to Normalized Power. Rides with power meter data only</summary>
        int? WeightedAverageWatts { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        ResourceState? ResourceState { get; }

        /// <summary>Not documented</summary>
        double? UtcOffset { get; }

        /// <summary>Not documented</summary>
        string LocationCity { get; }

        /// <summary>Not documented</summary>
        string LocationState { get; }

        /// <summary>Not documented</summary>
        string LocationCountry { get; }

        /// <summary>Not documented</summary>
        Visibility? Visibility { get; }

        /// <summary>Not documented</summary>
        bool? FromAcceptedTag { get; }

        /// <summary>Not documented</summary>
        float? AverageCadence { get; }

        /// <summary>Not documented</summary>
        bool? HasHeartrate { get; }

        /// <summary>Not documented</summary>
        float? AverageHeartrate { get; }

        /// <summary>Not documented</summary>
        float? MaxHeartrate { get; }

        /// <summary>Not documented</summary>
        bool? HeartrateOptOut { get; }

        /// <summary>Not documented</summary>
        bool? DisplayHideHeartrateOption { get; }

        /// <summary>Not documented</summary>
        int? PrCount { get; }

    }
}

