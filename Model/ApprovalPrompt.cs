using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of the possible authorization prompt behavior.</summary>
    public enum ApprovalPrompt
    {
        /// <summary>
        /// To only show the authorization prompt if the user has not yet authorized the current application
        /// </summary>
        [EnumMember(Value = "auto")]
        Auto,
        /// <summary>
        /// To always show the authorization prompt even if the user has already authorized the current application
        /// </summary>
        [EnumMember(Value = "force")]
        Force,
    }
}

