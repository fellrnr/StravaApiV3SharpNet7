using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Resource state, indicates level of detail. Possible values: 1 -> "meta", 2 -> "summary", 3 -> "detail"</summary>
    public enum ResourceState
    {
        Meta = 1,
        Summary = 2,
        Detail = 3,
    }
}

