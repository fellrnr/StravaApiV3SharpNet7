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
    /// <summary>The Routes endpoint</summary>
    public class Routes
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Routes(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Returns a GPX file of the route. Requires read_all scope for private routes.</summary>
        /// <param name="id">The identifier of the route.</param>
        /// <returns>A GPX file with the route.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Stream GetRouteAsGPX(long id)
        {
            string resourcePath = "/routes/{id}/export_gpx";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a TCX file of the route. Requires read_all scope for private routes.</summary>
        /// <param name="id">The identifier of the route.</param>
        /// <returns>A TCX file with the route.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Stream GetRouteAsTCX(long id)
        {
            string resourcePath = "/routes/{id}/export_tcx";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a route using its identifier. Requires read_all scope for private routes.</summary>
        /// <param name="id">The identifier of the route.</param>
        /// <returns>A representation of the route. An instance of Route.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Route GetRouteById(long id)
        {
            string resourcePath = "/routes/{id}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<Route>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a list of the routes created by the authenticated athlete. Private routes are filtered out unless requested by a token with read_all scope.</summary>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <param name="id">The identifier of the athlete. (Not documented in api documentation anymore but required)</param>
        /// <returns>An array of Route objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Route[] GetRoutesByAthleteId(long id, int? page = null, int? perPage = null)
        {
            string resourcePath = "/athletes/{id}/routes";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<Route[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

