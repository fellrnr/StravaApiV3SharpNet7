using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of the possible authorization scopes</summary>
    [System.Flags]
    public enum Scopes
    {
        /// <summary>
        /// No scope defined
        /// </summary>
        [EnumMember(Value = "")]
        None_Unknown = 0,
        /// <summary>
        /// Read public segments, public routes, public profile data, public posts, public events, club feeds, and leaderboards
        /// </summary>
        [EnumMember(Value = "read")]
        Read = 1,
        /// <summary>
        /// Read private routes, private segments, and private events for the user
        /// </summary>
        [EnumMember(Value = "read_all")]
        ReadAll = 2,
        /// <summary>
        /// Read all profile information even if the user has set their profile visibility to Followers or Only You
        /// </summary>
        [EnumMember(Value = "profile:read_all")]
        ProfileReadAll = 4,
        /// <summary>
        /// Update the user's weight and Functional Threshold Power (FTP), and access to star or unstar segments on their behalf
        /// </summary>
        [EnumMember(Value = "profile:write")]
        ProfileWrite = 8,
        /// <summary>
        /// Read the user's activity data for activities that are visible to Everyone and Followers, excluding privacy zone data
        /// </summary>
        [EnumMember(Value = "activity:read")]
        ActivityRead = 16,
        /// <summary>
        /// The same access as activity:read, plus privacy zone data and access to read the user's activities with visibility set to Only You
        /// </summary>
        [EnumMember(Value = "activity:read_all")]
        ActivityReadAll = 32,
        /// <summary>
        /// Access to create manual activities and uploads, and access to edit any activities that are visible to the app, based on activity read access level
        /// </summary>
        [EnumMember(Value = "activity:write")]
        ActivityWrite = 64,
    }
}

