using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class DetailedActivity : IMetaActivity, ISummaryActivity
    {
        private DetailedActivity() {}

        /// <summary>The unique identifier of the activity</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>The identifier provided at upload time</summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; private set; }

        /// <summary>The identifier of the upload that resulted in this activity</summary>
        [JsonProperty("upload_id")]
        public long? UploadId { get; private set; }

        /// <summary>An instance of MetaAthlete.</summary>
        [JsonProperty("athlete")]
        public MetaAthlete Athlete { get; private set; }

        /// <summary>The name of the activity</summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>The activity's distance, in meters</summary>
        [JsonProperty("distance")]
        public float? Distance { get; private set; }

        /// <summary>The activity's moving time, in seconds</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("moving_time")]
        public TimeSpan? MovingTime { get; private set; }

        /// <summary>The activity's elapsed time, in seconds</summary>
        [JsonConverter(typeof(Util.TimeSpanConverter))]
        [JsonProperty("elapsed_time")]
        public TimeSpan? ElapsedTime { get; private set; }

        /// <summary>The activity's total elevation gain.</summary>
        [JsonProperty("total_elevation_gain")]
        public float? TotalElevationGain { get; private set; }

        /// <summary>The activity's highest elevation, in meters</summary>
        [JsonProperty("elev_high")]
        public float? ElevHigh { get; private set; }

        /// <summary>The activity's lowest elevation, in meters</summary>
        [JsonProperty("elev_low")]
        public float? ElevLow { get; private set; }

        /// <summary>Deprecated. Prefer to use sport_type</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("type")]
        [Obsolete("Deprecated. Prefer to use sport_type", false)]
        public ActivityType? Type { get; private set; }

        /// <summary>An instance of SportType.</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("sport_type")]
        public ActivitySportType? SportType { get; private set; }

        /// <summary>The time at which the activity was started.</summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; private set; }

        /// <summary>The time at which the activity was started in the local timezone.</summary>
        [JsonProperty("start_date_local")]
        public DateTime? StartDateLocal { get; private set; }

        /// <summary>The timezone of the activity</summary>
        [JsonProperty("timezone")]
        public string Timezone { get; private set; }

        /// <summary>An instance of LatLng.</summary>
        [JsonProperty("start_latlng")]
        public LatLng StartLatlng { get; private set; }

        /// <summary>An instance of LatLng.</summary>
        [JsonProperty("end_latlng")]
        public LatLng EndLatlng { get; private set; }

        /// <summary>The number of achievements gained during this activity</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("achievement_count")]
        public int? AchievementCount { get; private set; }

        /// <summary>The number of kudos given for this activity</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("kudos_count")]
        public int? KudosCount { get; private set; }

        /// <summary>The number of comments for this activity</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("comment_count")]
        public int? CommentCount { get; private set; }

        /// <summary>The number of athletes for taking part in a group activity</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("athlete_count")]
        public int? AthleteCount { get; private set; }

        /// <summary>The number of Instagram photos for this activity</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("photo_count")]
        public int? PhotoCount { get; private set; }

        /// <summary>The number of Instagram and Strava photos for this activity</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("total_photo_count")]
        public int? TotalPhotoCount { get; private set; }

        /// <summary>An instance of PolylineMap.</summary>
        [JsonProperty("map")]
        public PolylineMap Map { get; private set; }

        /// <summary>Whether this activity was recorded on a training machine</summary>
        [JsonProperty("trainer")]
        public bool? Trainer { get; private set; }

        /// <summary>Whether this activity is a commute</summary>
        [JsonProperty("commute")]
        public bool? Commute { get; private set; }

        /// <summary>Whether this activity was created manually</summary>
        [JsonProperty("manual")]
        public bool? Manual { get; private set; }

        /// <summary>Whether this activity is private</summary>
        [JsonProperty("private")]
        public bool? Private { get; private set; }

        /// <summary>Whether this activity is flagged</summary>
        [JsonProperty("flagged")]
        public bool? Flagged { get; private set; }

        /// <summary>The activity's workout type</summary>
        [JsonProperty("workout_type")]
        public WorkoutType? WorkoutType { get; private set; }

        /// <summary>The unique identifier of the upload in string format</summary>
        [JsonProperty("upload_id_str")]
        public string UploadIdStr { get; private set; }

        /// <summary>The activity's average speed, in meters per second</summary>
        [JsonProperty("average_speed")]
        public float? AverageSpeed { get; private set; }

        /// <summary>The activity's max speed, in meters per second</summary>
        [JsonProperty("max_speed")]
        public float? MaxSpeed { get; private set; }

        /// <summary>Whether the logged-in athlete has kudoed this activity</summary>
        [JsonProperty("has_kudoed")]
        public bool? HasKudoed { get; private set; }

        /// <summary>Whether the activity is muted</summary>
        [JsonProperty("hide_from_home")]
        public bool? HideFromHome { get; private set; }

        /// <summary>The id of the gear for the activity</summary>
        [JsonProperty("gear_id")]
        public string GearId { get; private set; }

        /// <summary>The total work done in kilojoules during this activity. Rides only</summary>
        [JsonProperty("kilojoules")]
        public float? Kilojoules { get; private set; }

        /// <summary>Average power output in watts during this activity. Rides only</summary>
        [JsonProperty("average_watts")]
        public float? AverageWatts { get; private set; }

        /// <summary>Whether the watts are from a power meter, false if estimated</summary>
        [JsonProperty("device_watts")]
        public bool? DeviceWatts { get; private set; }

        /// <summary>Rides with power meter data only</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("max_watts")]
        public int? MaxWatts { get; private set; }

        /// <summary>Similar to Normalized Power. Rides with power meter data only</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("weighted_average_watts")]
        public int? WeightedAverageWatts { get; private set; }

        /// <summary>The description of the activity</summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>An instance of PhotosSummary.</summary>
        [JsonProperty("photos")]
        public PhotosSummary Photos { get; private set; }

        /// <summary>An instance of SummaryGear.</summary>
        [JsonProperty("gear")]
        public SummaryGear Gear { get; private set; }

        /// <summary>The number of kilocalories consumed during this activity</summary>
        [JsonProperty("calories")]
        public float? Calories { get; private set; }

        /// <summary>A collection of DetailedSegmentEffort objects.</summary>
        [JsonProperty("segment_efforts")]
        public DetailedSegmentEffort[] SegmentEfforts 
        {
            get => (DetailedSegmentEffort[])_SegmentEfforts?.Clone();
            private set => _SegmentEfforts = value;
        }
        private DetailedSegmentEffort[] _SegmentEfforts;

        /// <summary>The name of the device used to record the activity</summary>
        [JsonProperty("device_name")]
        public string DeviceName { get; private set; }

        /// <summary>The token used to embed a Strava activity</summary>
        [JsonProperty("embed_token")]
        public string EmbedToken { get; private set; }

        /// <summary>The splits of this activity in metric units (for runs)</summary>
        [JsonProperty("splits_metric")]
        public Split[] SplitsMetric 
        {
            get => (Split[])_SplitsMetric?.Clone();
            private set => _SplitsMetric = value;
        }
        private Split[] _SplitsMetric;

        /// <summary>The splits of this activity in imperial units (for runs)</summary>
        [JsonProperty("splits_standard")]
        public Split[] SplitsStandard 
        {
            get => (Split[])_SplitsStandard?.Clone();
            private set => _SplitsStandard = value;
        }
        private Split[] _SplitsStandard;

        /// <summary>A collection of Lap objects.</summary>
        [JsonProperty("laps")]
        public Lap[] Laps 
        {
            get => (Lap[])_Laps?.Clone();
            private set => _Laps = value;
        }
        private Lap[] _Laps;

        /// <summary>A collection of DetailedSegmentEffort objects.</summary>
        [JsonProperty("best_efforts")]
        public DetailedSegmentEffort[] BestEfforts 
        {
            get => (DetailedSegmentEffort[])_BestEfforts?.Clone();
            private set => _BestEfforts = value;
        }
        private DetailedSegmentEffort[] _BestEfforts;

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("utc_offset")]
        public double? UtcOffset { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("location_city")]
        public string LocationCity { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("location_state")]
        public string LocationState { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("location_country")]
        public string LocationCountry { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [JsonProperty("visibility")]
        public Visibility? Visibility { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("from_accepted_tag")]
        public bool? FromAcceptedTag { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("average_cadence")]
        public float? AverageCadence { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("has_heartrate")]
        public bool? HasHeartrate { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("average_heartrate")]
        public float? AverageHeartrate { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("max_heartrate")]
        public float? MaxHeartrate { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("heartrate_opt_out")]
        public bool? HeartrateOptOut { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("display_hide_heartrate_option")]
        public bool? DisplayHideHeartrateOption { get; private set; }

        /// <summary>Not documented</summary>
        [JsonConverter(typeof(Util.IntConverter))]
        [JsonProperty("pr_count")]
        public int? PrCount { get; private set; }

        /// <summary>Private note of the activity (members only)</summary>
        [JsonProperty("private_note")]
        public string PrivateNote { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("perceived_exertion")]
        public float? PerceivedExertion { get; private set; }

        /// <summary>Not documented</summary>
        [JsonProperty("prefer_perceived_exertion")]
        public bool? PreferPerceivedExertion { get; private set; }

    }
}

