using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class ExplorerSegment
    {
        private ExplorerSegment() {}

        /// <summary>The unique identifier of this segment</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>The name of this segment</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>The category of the climb [0, 5]. Higher is harder ie. 5 is Hors catégorie, 0 is uncategorized in climb_category. If climb_category = 5, climb_category_desc = HC. If climb_category = 2, climb_category_desc = 3.</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("climb_category")]
        public int? ClimbCategory { get; private set; }

        /// <summary>The description for the category of the climb May take one of the following values: NC, 4, 3, 2, 1, HC</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("climb_category_desc")]
        public ClimbCategoryDesc? ClimbCategoryDesc { get; private set; }

        /// <summary>The segment's average grade, in percents</summary>
        [JsonProperty("avg_grade")]
        public float? AvgGrade { get; private set; }

        /// <summary>An instance of LatLng.</summary>
        [JsonProperty("start_latlng")]
        public LatLng StartLatlng { get; private set; }

        /// <summary>An instance of LatLng.</summary>
        [JsonProperty("end_latlng")]
        public LatLng EndLatlng { get; private set; }

        /// <summary>The segments's evelation difference, in meters</summary>
        [JsonProperty("elev_difference")]
        public float? ElevDifference { get; private set; }

        /// <summary>The segment's distance, in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The polyline of the segment</summary>
        [JsonProperty("points")]
        public string Points { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Whether this segment is starred by the logged-in athlete</summary>
        [JsonProperty("starred")]
        public bool? Starred { get; private set; }

    }
}

