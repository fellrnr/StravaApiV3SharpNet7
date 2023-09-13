using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="SummarySegment"/> and <see cref="DetailedSegment"/></summary>
    public interface ISummarySegment
    {

        /// <summary>The unique identifier of this segment</summary>
        long? Id { get; }

        /// <summary>The name of this segment</summary>
        string Name { get; }

        /// <summary>May take one of the following values: Ride, Run</summary>
        ActivityType? ActivityType { get; }

        /// <summary>The segment's distance, in meters</summary>
        float? Distance { get; }

        /// <summary>The segment's average grade, in percents</summary>
        float? AverageGrade { get; }

        /// <summary>The segments's maximum grade, in percents</summary>
        float? MaximumGrade { get; }

        /// <summary>The segments's highest elevation, in meters</summary>
        float? ElevationHigh { get; }

        /// <summary>The segments's lowest elevation, in meters</summary>
        float? ElevationLow { get; }

        /// <summary>An instance of LatLng.</summary>
        LatLng StartLatlng { get; }

        /// <summary>An instance of LatLng.</summary>
        LatLng EndLatlng { get; }

        /// <summary>The category of the climb [0, 5]. Higher is harder ie. 5 is Hors catégorie, 0 is uncategorized in climb_category.</summary>
        int? ClimbCategory { get; }

        /// <summary>The segments's city.</summary>
        string City { get; }

        /// <summary>The segments's state or geographical region.</summary>
        string State { get; }

        /// <summary>The segment's country.</summary>
        string Country { get; }

        /// <summary>Whether this segment is private.</summary>
        bool? Private { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        ResourceState? ResourceState { get; }

        /// <summary>Whether this segment is marked as hazardous</summary>
        bool? Hazardous { get; }

        /// <summary>Whether this segment is starred by the logged-in athlete</summary>
        bool? Starred { get; }

    }
}

