using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="SummarySegmentEffort"/> and <see cref="DetailedSegmentEffort"/></summary>
    public interface ISummarySegmentEffort
    {

        /// <summary>The unique identifier of this effort</summary>
        long? Id { get; }

        /// <summary>The effort's elapsed time</summary>
        TimeSpan? ElapsedTime { get; }

        /// <summary>The time at which the effort was started.</summary>
        DateTime? StartDate { get; }

        /// <summary>The time at which the effort was started in the local timezone.</summary>
        DateTime? StartDateLocal { get; }

        /// <summary>The effort's distance in meters</summary>
        float? Distance { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        ResourceState? ResourceState { get; }

    }
}

