using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Model is not described on the Api-Website</summary>
    public class Achievement
    {
        private Achievement() {}

        /// <summary>The id of the achievement</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("type_id")]
        public int? TypeId { get; private set; }

        /// <summary>The type of the achievement</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type")]
        public AchievementType? Type { get; private set; }

        /// <summary>The rank in the achievement type</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("rank")]
        public int? Rank { get; private set; }

    }
}

