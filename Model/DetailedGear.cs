using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class DetailedGear : ISummaryGear
    {
        private DetailedGear() {}

        /// <summary>The gear's unique identifier.</summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 2 -> "summary", 3 -> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Whether this gear's is the owner's default one.</summary>
        [JsonProperty("primary")]
        public bool? Primary { get; private set; }

        /// <summary>The gear's name.</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>The distance logged with this gear.</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The gear's brand name.</summary>
        [JsonProperty("brand_name")]
        public string BrandName { get; private set; }

        /// <summary>The gear's model name.</summary>
        [JsonProperty("model_name")]
        public string ModelName { get; private set; }

        /// <summary>The gear's frame type (bike only).</summary>
        [JsonProperty("frame_type")]
        public FrameType? FrameType { get; private set; }

        /// <summary>The gear's description.</summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>The given nickname to the gear</summary>
        [JsonProperty("nickname")]
        public string Nickname { get; private set; }

        /// <summary>Whether the gear is marked as retired</summary>
        [JsonProperty("retired")]
        public bool? Retired { get; private set; }

        /// <summary>The weight of the gear in kg</summary>
        [JsonProperty("weight")]
        public double? Weight { get; private set; }

        /// <summary>The distance once Strava will notify the user to buy a new pair of shoes in km</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("notification_distance")]
        public int? NotificationDistance { get; private set; }

    }
}

