using System.Runtime.Serialization;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>An enumeration of values data_type can have</summary>
    public enum DataType
    {
        [EnumMember(Value = "fit")]
        Fit,
        [EnumMember(Value = "fit.gz")]
        FitGz,
        [EnumMember(Value = "tcx")]
        Tcx,
        [EnumMember(Value = "tcx.gz")]
        TcxGz,
        [EnumMember(Value = "gpx")]
        Gpx,
        [EnumMember(Value = "gpx.gz")]
        GpxGz,
    }
}

