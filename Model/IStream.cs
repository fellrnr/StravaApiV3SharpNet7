using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="AltitudeStream"/>, <see cref="CadenceStream"/>, <see cref="DistanceStream"/>, <see cref="HeartrateStream"/>, <see cref="LatLngStream"/>, <see cref="MovingStream"/>, <see cref="PowerStream"/>, <see cref="SmoothGradeStream"/>, <see cref="SmoothVelocityStream"/>, <see cref="TemperatureStream"/> and <see cref="TimeStream"/></summary>
    public interface IStream
    {

        /// <summary>The number of data points in this stream</summary>
        int? OriginalSize { get; }

        /// <summary>The level of detail (sampling) in which this stream was returned May take one of the following values: low, medium, high</summary>
        Resolution? Resolution { get; }

        /// <summary>The base series used in the case the stream was downsampled May take one of the following values: distance, time</summary>
        SeriesType? SeriesType { get; }

    }
}

