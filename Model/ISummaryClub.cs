using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="SummaryClub"/> and <see cref="DetailedClub"/></summary>
    public interface ISummaryClub
    {

        /// <summary>The club's unique identifier.</summary>
        long? Id { get; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1 -> "meta", 2 -> "summary", 3 -> "detail"</summary>
        ResourceState? ResourceState { get; }

        /// <summary>The club's name.</summary>
        string Name { get; }

        /// <summary>URL to a 60x60 pixel profile picture.</summary>
        Uri ProfileMedium { get; }

        /// <summary>URL to a ~1185x580 pixel cover photo.</summary>
        Uri CoverPhoto { get; }

        /// <summary>URL to a ~360x176  pixel cover photo.</summary>
        Uri CoverPhotoSmall { get; }

        /// <summary>Deprecated. Prefer to use activity_types. May take one of the following values: cycling, running, triathlon, other</summary>
        SportType? SportType { get; }

        /// <summary>The activity types that count for a club. This takes precedence over sport_type.</summary>
        ActivityType[] ActivityTypes { get; }

        /// <summary>The club's city.</summary>
        string City { get; }

        /// <summary>The club's state or geographical region.</summary>
        string State { get; }

        /// <summary>The club's country.</summary>
        string Country { get; }

        /// <summary>Whether the club is private.</summary>
        bool? Private { get; }

        /// <summary>The club's member count.</summary>
        int? MemberCount { get; }

        /// <summary>Whether the club is featured or not.</summary>
        bool? Featured { get; }

        /// <summary>Whether the club is verified or not.</summary>
        bool? Verified { get; }

        /// <summary>The club's vanity URL.</summary>
        string Url { get; }

        /// <summary>URL to a 124x124 pixel profile picture.</summary>
        Uri Profile { get; }

        /// <summary>Not documented</summary>
        Membership? Membership { get; }

        /// <summary>Not documented</summary>
        bool? Admin { get; }

        /// <summary>Not documented</summary>
        bool? Owner { get; }

    }
}

