using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class DetailedClub : ISummaryClub
    {
        private DetailedClub() {}

        /// <summary>The club's unique identifier.</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1 -> "meta", 2 -> "summary", 3 -> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>The club's name.</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>URL to a 60x60 pixel profile picture.</summary>
        [JsonProperty("profile_medium")]
        public Uri ProfileMedium { get; private set; }

        /// <summary>URL to a ~1185x580 pixel cover photo.</summary>
        [JsonProperty("cover_photo")]
        public Uri CoverPhoto { get; private set; }

        /// <summary>URL to a ~360x176  pixel cover photo.</summary>
        [JsonProperty("cover_photo_small")]
        public Uri CoverPhotoSmall { get; private set; }

        /// <summary>Deprecated. Prefer to use activity_types. May take one of the following values: cycling, running, triathlon, other</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("sport_type")]
        [Obsolete("Deprecated. Prefer to use activity_types.", false)]
        public SportType? SportType { get; private set; }

        /// <summary>The activity types that count for a club. This takes precedence over sport_type.</summary>
        [JsonProperty("activity_types", ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ActivityType[] ActivityTypes 
        {
            get => (ActivityType[])_ActivityTypes?.Clone();
            private set => _ActivityTypes = value;
        }
        private ActivityType[] _ActivityTypes;

        /// <summary>The club's city.</summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>The club's state or geographical region.</summary>
        [JsonProperty("state")]
        public string State { get; private set; }

        /// <summary>The club's country.</summary>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>Whether the club is private.</summary>
        [JsonProperty("private")]
        public bool? Private { get; private set; }

        /// <summary>The club's member count.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("member_count")]
        public int? MemberCount { get; private set; }

        /// <summary>Whether the club is featured or not.</summary>
        [JsonProperty("featured")]
        public bool? Featured { get; private set; }

        /// <summary>Whether the club is verified or not.</summary>
        [JsonProperty("verified")]
        public bool? Verified { get; private set; }

        /// <summary>The club's vanity URL.</summary>
        [JsonProperty("url")]
        public string Url { get; private set; }

        /// <summary>The membership status of the logged-in athlete. May take one of the following values: member, pending</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("membership")]
        public Membership? Membership { get; private set; }

        /// <summary>Whether the currently logged-in athlete is an administrator of this club.</summary>
        [JsonProperty("admin")]
        public bool? Admin { get; private set; }

        /// <summary>Whether the currently logged-in athlete is the owner of this club.</summary>
        [JsonProperty("owner")]
        public bool? Owner { get; private set; }

        /// <summary>The number of athletes in the club that the logged-in athlete follows.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("following_count")]
        public int? FollowingCount { get; private set; }

        /// <summary>URL to a 124x124 pixel profile picture.</summary>
        [JsonProperty("profile")]
        public Uri Profile { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("club_type")]
        public string ClubType { get; private set; }

    }
}

