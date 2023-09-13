using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class DetailedAthlete : IMetaAthlete, ISummaryAthlete
    {
        private DetailedAthlete() {}

        /// <summary>The unique identifier of the athlete</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1 -> "meta", 2 -> "summary", 3 -> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>The athlete's first name.</summary>
        [JsonProperty("firstname")]
        public string Firstname { get; private set; }

        /// <summary>The athlete's last name.</summary>
        [JsonProperty("lastname")]
        public string Lastname { get; private set; }

        /// <summary>URL to a 62x62 pixel profile picture.</summary>
        [JsonProperty("profile_medium")]
        public Uri ProfileMedium { get; private set; }

        /// <summary>URL to a 124x124 pixel profile picture.</summary>
        [JsonProperty("profile")]
        public Uri Profile { get; private set; }

        /// <summary>The athlete's city.</summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>The athlete's state or geographical region.</summary>
        [JsonProperty("state")]
        public string State { get; private set; }

        /// <summary>The athlete's country.</summary>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>The athlete's sex. May take one of the following values: M, F</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("sex")]
        public Gender? Sex { get; private set; }

        /// <summary>Deprecated.  Use summit field instead. Whether the athlete has any Summit subscription.</summary>
        [JsonProperty("premium")]
        [Obsolete("Deprecated.  Use summit field instead.", false)]
        public bool? Premium { get; private set; }

        /// <summary>Whether the athlete has any Summit subscription.</summary>
        [JsonProperty("summit")]
        public bool? Summit { get; private set; }

        /// <summary>The time at which the athlete was created.</summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>The time at which the athlete was last updated.</summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>The athlete's follower count.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("follower_count")]
        public int? FollowerCount { get; private set; }

        /// <summary>The athlete's friend count.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("friend_count")]
        public int? FriendCount { get; private set; }

        /// <summary>The athlete's preferred unit system. May take one of the following values: feet, meters</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("measurement_preference")]
        public MeasurementPreference? MeasurementPreference { get; private set; }

        /// <summary>The athlete's FTP (Functional Threshold Power).</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("ftp")]
        public int? Ftp { get; private set; }

        /// <summary>The athlete's weight.</summary>
        [JsonProperty("weight")]
        public float? Weight { get; private set; }

        /// <summary>The athlete's clubs.</summary>
        [JsonProperty("clubs")]
        public SummaryClub[] Clubs 
        {
            get => (SummaryClub[])_Clubs?.Clone();
            private set => _Clubs = value;
        }
        private SummaryClub[] _Clubs;

        /// <summary>The athlete's bikes.</summary>
        [JsonProperty("bikes")]
        public SummaryGear[] Bikes 
        {
            get => (SummaryGear[])_Bikes?.Clone();
            private set => _Bikes = value;
        }
        private SummaryGear[] _Bikes;

        /// <summary>The athlete's shoes.</summary>
        [JsonProperty("shoes")]
        public SummaryGear[] Shoes 
        {
            get => (SummaryGear[])_Shoes?.Clone();
            private set => _Shoes = value;
        }
        private SummaryGear[] _Shoes;

        /// <summary>The name the user profile can be found under https://www.strava.com/athletes/{username}</summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("badge_type_id")]
        public int? BadgeTypeId { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("athlete_type")]
        public int? AthleteType { get; private set; }

        /// <summary>The way the user wants the date to be presented</summary>
        [JsonProperty("date_preference")]
        public string DatePreference { get; private set; }

        /// <summary>The profile short biography</summary>
        [JsonProperty("bio")]
        public string Bio { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("mutual_friend_count")]
        public int? MutualFriendCount { get; private set; }

    }
}

