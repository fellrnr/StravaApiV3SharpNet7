using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="MetaActivity"/>, <see cref="SummaryActivity"/> and <see cref="DetailedActivity"/></summary>
    public interface IMetaActivity
    {

        /// <summary>The unique identifier of the activity</summary>
        long? Id { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        ResourceState? ResourceState { get; }

    }
}

