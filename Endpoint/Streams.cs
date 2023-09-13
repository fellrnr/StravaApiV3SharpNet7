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
    /// <summary>The Streams endpoint</summary>
    public class Streams
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Streams(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Returns the given activity&#39;s streams. Requires activity:read scope. Requires activity:read_all scope for Only Me activities.</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <param name="keys">Desired stream types. May take one of the following values:</param>
        /// <returns>The set of requested streams. An instance of StreamSet.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public StreamSet GetActivityStreams(long id, StreamTypes keys)
        {
            string resourcePath = "/activities/{id}/streams";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("keys", EnumUtil.GetEnumAttrValue(((StreamTypes)keys)));
            queryParam.Add("key_by_type", ((bool)true).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<StreamSet>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the given route&#39;s streams. Requires read_all scope for private routes.</summary>
        /// <param name="id">The identifier of the route.</param>
        /// <returns>The set of requested streams. An instance of StreamSet.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public RouteStreamSet GetRouteStreams(long id)
        {
            string resourcePath = "/routes/{id}/streams";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<RouteStreamSet>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a set of streams for a segment effort completed by the authenticated athlete. Requires read_all scope.</summary>
        /// <param name="id">The identifier of the segment effort.</param>
        /// <param name="keys">The types of streams to return. May take one of the following values:</param>
        /// <returns>The set of requested streams. An instance of StreamSet.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public StreamSet GetSegmentEffortStreams(long id, StreamTypes keys)
        {
            string resourcePath = "/segment_efforts/{id}/streams";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("keys", EnumUtil.GetEnumAttrValue(((StreamTypes)keys)));
            queryParam.Add("key_by_type", ((bool)true).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<StreamSet>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the given segment&#39;s streams. Requires read_all scope for private segments.</summary>
        /// <param name="id">The identifier of the segment.</param>
        /// <param name="keys">The types of streams to return. May take one of the following values:</param>
        /// <returns>The set of requested streams. An instance of StreamSet.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public StreamSet GetSegmentStreams(long id, StreamTypes keys)
        {
            string resourcePath = "/segments/{id}/streams";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("keys", EnumUtil.GetEnumAttrValue(((StreamTypes)keys)));
            queryParam.Add("key_by_type", ((bool)true).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<StreamSet>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

