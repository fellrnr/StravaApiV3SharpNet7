using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class UpdatableActivity
    {
        public UpdatableActivity() {}

        /// <summary>Whether this activity is a commute</summary>
        [JsonProperty("commute")]
        public bool? Commute { get; set; }

        /// <summary>Whether this activity was recorded on a training machine</summary>
        [JsonProperty("trainer")]
        public bool? Trainer { get; set; }

        /// <summary>Whether this activity is muted</summary>
        [JsonProperty("hide_from_home")]
        public bool? HideFromHome { get; set; }

        /// <summary>The description of the activity</summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>The name of the activity</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Deprecated. Prefer to use sport_type. In a request where both type and sport_type are present, this field will be ignored</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type")]
        [Obsolete("Deprecated. Prefer to use sport_type.", false)]
        public ActivityType? Type { get; set; }

        /// <summary>An instance of SportType.</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("sport_type")]
        public ActivitySportType? SportType { get; set; }

        /// <summary>Identifier for the gear associated with the activity. ‘none’ clears gear from activity</summary>
        [JsonProperty("gear_id")]
        public string GearId { get; set; }

    }
}

