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
    /// <summary>The Athletes endpoint</summary>
    public class Athletes
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Athletes(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Returns the currently authenticated athlete. Tokens with profile:read_all scope will receive a detailed athlete representation; all others will receive a summary representation.</summary>
        /// <returns>Profile information for the authenticated athlete. An instance of DetailedAthlete.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedAthlete GetLoggedInAthlete()
        {
            string resourcePath = "/athlete";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedAthlete>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the the authenticated athlete&#39;s heart rate and power zones. Requires profile:read_all.</summary>
        /// <returns>Heart rate and power zones. An instance of Zones.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Zones GetLoggedInAthleteZones()
        {
            string resourcePath = "/athlete/zones";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<Zones>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the activity stats of an athlete. Only includes data from activities set to Everyone visibilty.</summary>
        /// <param name="id">The identifier of the athlete. Must match the authenticated athlete.</param>
        /// <returns>Activity stats of the athlete. An instance of ActivityStats.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public ActivityStats GetStats(long id)
        {
            string resourcePath = "/athletes/{id}/stats";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<ActivityStats>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Update the currently authenticated athlete. Requires profile:write scope.</summary>
        /// <param name="weight">The weight of the athlete in kilograms.</param>
        /// <returns>Profile information for the authenticated athlete. An instance of DetailedAthlete.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedAthlete UpdateLoggedInAthlete(float weight)
        {
            string resourcePath = "/athlete?weight={weight}";
            Method method = Method.Put;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("weight", ((float)weight).ToString("0.000000000000000", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedAthlete>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

