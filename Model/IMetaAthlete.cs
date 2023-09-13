using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="MetaAthlete"/>, <see cref="SummaryAthlete"/> and <see cref="DetailedAthlete"/></summary>
    public interface IMetaAthlete
    {

        /// <summary>The unique identifier of the athlete</summary>
        long? Id { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        ResourceState? ResourceState { get; }

        /// <summary>The athlete's first name.</summary>
        string Firstname { get; }

        /// <summary>The athlete's last name.</summary>
        string Lastname { get; }

    }
}

