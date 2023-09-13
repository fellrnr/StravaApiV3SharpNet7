using de.schumacher_bw.Strava.Model;
using de.schumacher_bw.Strava.Util;
using RestSharp;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

#pragma warning disable IDE0028

namespace de.schumacher_bw.Strava.Endpoint
{
    /// <summary>The Gears endpoint</summary>
    public class Gears
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Gears(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Returns an equipment using its identifier.</summary>
        /// <param name="id">The identifier of the gear.</param>
        /// <returns>A representation of the gear. An instance of DetailedGear.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedGear GetGearById(string id)
        {
            string resourcePath = "/gear/{id}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", id);
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedGear>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

