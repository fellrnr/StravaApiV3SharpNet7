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
    /// <summary>The SegmentEfforts endpoint</summary>
    public class SegmentEfforts
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal SegmentEfforts(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Returns a set of the authenticated athlete&#39;s segment efforts for a given segment.  Requires subscription.</summary>
        /// <param name="segmentId">The identifier of the segment.</param>
        /// <param name="startDateLocal">ISO 8601 formatted date time.</param>
        /// <param name="endDateLocal">ISO 8601 formatted date time.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of DetailedSegmentEffort objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedSegmentEffort[] GetEffortsBySegmentId(int segmentId, DateTime? startDateLocal = null, DateTime? endDateLocal = null, int? perPage = null)
        {
            string resourcePath = "/segment_efforts";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("segment_id", ((int)segmentId).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (startDateLocal != null) queryParam.Add("start_date_local", ((DateTime)startDateLocal).ToString("yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (endDateLocal != null) queryParam.Add("end_date_local", ((DateTime)endDateLocal).ToString("yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedSegmentEffort[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a segment effort from an activity that is owned by the authenticated athlete. Requires subscription.</summary>
        /// <param name="id">The identifier of the segment effort.</param>
        /// <returns>Representation of a segment effort. An instance of DetailedSegmentEffort.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedSegmentEffort GetSegmentEffortById(long id)
        {
            string resourcePath = "/segment_efforts/{id}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedSegmentEffort>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

