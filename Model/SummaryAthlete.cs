using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class SummaryAthlete : IMetaAthlete, ISummaryAthlete
    {
        private SummaryAthlete() {}

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

        /// <summary>The name the user profile can be found under https://www.strava.com/athletes/{username}</summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("badge_type_id")]
        public int? BadgeTypeId { get; private set; }

        /// <summary>The profile short biography</summary>
        [JsonProperty("bio")]
        public string Bio { get; private set; }

    }
}

