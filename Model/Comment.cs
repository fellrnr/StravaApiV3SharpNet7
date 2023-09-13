using Newtonsoft.Json;
using System;

#pragma warning disable CA1819

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>No comment for this Model existing</summary>
    public class Comment
    {
        private Comment() {}

        /// <summary>The unique identifier of this comment</summary>
        [JsonProperty("id")]
        public long? Id { get; private set; }

        /// <summary>The identifier of the activity this comment is related to</summary>
        [JsonProperty("activity_id")]
        public long? ActivityId { get; private set; }

        /// <summary>The content of the comment</summary>
        [JsonProperty("text")]
        public string Text { get; private set; }

        /// <summary>An instance of SummaryAthlete.</summary>
        [JsonProperty("athlete")]
        public SummaryAthlete Athlete { get; private set; }

        /// <summary>The time at which this comment was created.</summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>Resource state, indicates level of detail. Possible values: 1-> "meta", 2-> "summary", 3-> "detail"</summary>
        [JsonProperty("resource_state")]
        public ResourceState? ResourceState { get; private set; }

        /// <summary>An identifier that can be used to get all following comments of the activity</summary>
        [JsonProperty("cursor")]
        public string Cursor { get; private set; }

    }
}

