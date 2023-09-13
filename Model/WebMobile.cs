using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of the possible authorization prompt websites.</summary>
    public enum WebMobile
    {
        /// <summary>
        /// This will redirected to a website to complete OAuth.
        /// </summary>
        [EnumMember(Value = "web")]
        Web,
        /// <summary>
        /// If used correctly the Strava app should open automatically if the user has it installed. For details see http://developers.strava.com/docs/authentication/
        /// </summary>
        [EnumMember(Value = "mobile")]
        Mobile,
    }
}

