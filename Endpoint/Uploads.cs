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
    /// <summary>The Uploads endpoint</summary>
    public class Uploads
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Uploads(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Uploads a new data file to create an activity from. Requires activity:write scope.</summary>
        /// <param name="file">The uploaded file.</param>
        /// <param name="name">The desired name of the resulting activity.</param>
        /// <param name="description">The desired description of the resulting activity.</param>
        /// <param name="trainer">Whether the resulting activity should be marked as having been performed on a trainer.</param>
        /// <param name="commute">Whether the resulting activity should be tagged as a commute.</param>
        /// <param name="dataType">The format of the uploaded file. May take one of the following values: fit, fit.gz, tcx, tcx.gz, gpx, gpx.gz</param>
        /// <param name="externalId">The desired external identifier of the resulting activity.</param>
        /// <returns>A representation of the created upload. An instance of Upload.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Upload CreateUpload(FileInfo file, DataType dataType, string name = null, string description = null, bool? trainer = null, bool? commute = null, string externalId = null)
        {
            string resourcePath = "/uploads";
            Method method = Method.Post;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            if (name != null) queryParam.Add("name", name);
            if (description != null) queryParam.Add("description", description);
            if (trainer != null) queryParam.Add("trainer", ((bool)trainer).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (commute != null) queryParam.Add("commute", ((bool)commute).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            queryParam.Add("data_type", EnumUtil.GetEnumAttrValue(((DataType)dataType)));
            if (externalId != null) queryParam.Add("external_id", externalId);
            string bodyParam = null;
            var fileParam = new System.Collections.Generic.Dictionary<string, FileInfo>();
            fileParam.Add("file", file);

            return RestClient.Execute<Upload>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns an upload for a given identifier. Requires activity:write scope.</summary>
        /// <param name="uploadId">The identifier of the upload.</param>
        /// <returns>Representation of the upload. An instance of Upload.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Upload GetUploadById(long uploadId)
        {
            string resourcePath = "/uploads/{uploadId}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("uploadId", ((long)uploadId).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<Upload>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

