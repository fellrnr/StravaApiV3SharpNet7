using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="SummaryAthlete"/> and <see cref="DetailedAthlete"/></summary>
    public interface ISummaryAthlete
    {

        /// <summary>The unique identifier of the athlete</summary>
        long? Id { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1 -> "meta", 2 -> "summary", 3 -> "detail"</summary>
        ResourceState? ResourceState { get; }

        /// <summary>The athlete's first name.</summary>
        string Firstname { get; }

        /// <summary>The athlete's last name.</summary>
        string Lastname { get; }

        /// <summary>URL to a 62x62 pixel profile picture.</summary>
        Uri ProfileMedium { get; }

        /// <summary>URL to a 124x124 pixel profile picture.</summary>
        Uri Profile { get; }

        /// <summary>The athlete's city.</summary>
        string City { get; }

        /// <summary>The athlete's state or geographical region.</summary>
        string State { get; }

        /// <summary>The athlete's country.</summary>
        string Country { get; }

        /// <summary>The athlete's sex. May take one of the following values: M, F</summary>
        Gender? Sex { get; }

        /// <summary>Deprecated.  Use summit field instead. Whether the athlete has any Summit subscription.</summary>
        bool? Premium { get; }

        /// <summary>Whether the athlete has any Summit subscription.</summary>
        bool? Summit { get; }

        /// <summary>The time at which the athlete was created.</summary>
        DateTime? CreatedAt { get; }

        /// <summary>The time at which the athlete was last updated.</summary>
        DateTime? UpdatedAt { get; }

        /// <summary>The name the user profile can be found under https://www.strava.com/athletes/{username}</summary>
        string Username { get; }

        /// <summary>Not documented</summary>
        int? BadgeTypeId { get; }

        /// <summary>The profile short biography</summary>
        string Bio { get; }

    }
}

