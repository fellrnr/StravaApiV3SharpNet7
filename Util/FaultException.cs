using System;
using de.schumacher_bw.Strava.Model;

namespace de.schumacher_bw.Strava.Util
{
    /// <summary>Exception that is thrown in case the Api returns an error</summary>
    public class FaultException : Exception
    {
        /// <summary>A Fault describing the reason for the error.</summary>
        public Fault Fault { get; }

        /// <summary>The constructor for a FaultException</summary>
        /// <param name="fault">The Fault from the strava api</param>
        internal FaultException(Fault fault) => Fault = fault;
    }
}
