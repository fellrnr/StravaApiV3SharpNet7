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
    /// <summary>The Segments endpoint</summary>
    public class Segments
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Segments(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Returns the top 10 segments matching a specified query.</summary>
        /// <param name="bounds">The latitude and longitude for two points describing a rectangular boundary for the search: [southwest corner latitutde, southwest corner longitude, northeast corner latitude, northeast corner longitude]</param>
        /// <param name="activityType">Desired activity type. May take one of the following values: running, riding</param>
        /// <param name="minCat">The minimum climbing category.</param>
        /// <param name="maxCat">The maximum climbing category.</param>
        /// <returns>List of matching segments. An instance of ExplorerResponse.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public ExplorerResponse ExploreSegments(float[] bounds, ActivityTypeRunningRiding? activityType = null, int? minCat = null, int? maxCat = null)
        {
            string resourcePath = "/segments/explore";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("bounds", String.Join(",",bounds.Select(f => f.ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")))));
            if (activityType != null) queryParam.Add("activity_type", EnumUtil.GetEnumAttrValue(((ActivityTypeRunningRiding)activityType)));
            if (minCat != null) queryParam.Add("min_cat", ((int)minCat).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (maxCat != null) queryParam.Add("max_cat", ((int)maxCat).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<ExplorerResponse>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>List of the authenticated athlete&#39;s starred segments. Private segments are filtered out unless requested by a token with read_all scope.</summary>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummarySegment objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummarySegment[] GetLoggedInAthleteStarredSegments(int? page = null, int? perPage = null)
        {
            string resourcePath = "/segments/starred";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<SummarySegment[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the specified segment. read_all scope required in order to retrieve athlete-specific segment information, or to retrieve private segments.</summary>
        /// <param name="id">The identifier of the segment.</param>
        /// <returns>Representation of a segment. An instance of DetailedSegment.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedSegment GetSegmentById(long id)
        {
            string resourcePath = "/segments/{id}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedSegment>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Stars/Unstars the given segment for the authenticated athlete. Requires profile:write scope.</summary>
        /// <param name="id">The identifier of the segment to star.</param>
        /// <param name="starred">If true, star the segment; if false, unstar the segment.</param>
        /// <returns>Representation of a segment. An instance of DetailedSegment.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedSegment StarSegment(long id, bool starred)
        {
            string resourcePath = "/segments/{id}/starred";
            Method method = Method.Put;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("starred", ((bool)starred).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedSegment>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

