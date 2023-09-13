using System;

namespace de.schumacher_bw.Strava.Model
{
    /// <summary>Interface that is implemented by <see cref="RouteStreamSet"/> and <see cref="StreamSet"/></summary>
    public interface IRouteStreamSet
    {

        /// <summary>An instance of DistanceStream.</summary>
        DistanceStream Distance { get; }

        /// <summary>An instance of LatLngStream.</summary>
        LatLngStream Latlng { get; }

        /// <summary>An instance of AltitudeStream.</summary>
        AltitudeStream Altitude { get; }

    }
}

