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
    /// <summary>The Activities endpoint</summary>
    public class Activities
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Activities(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Creates a manual activity for an athlete, requires activity:write scope.</summary>
        /// <param name="name">The name of the activity.</param>
        /// <param name="type">Type of activity. For example - Run, Ride etc.</param>
        /// <param name="startDateLocal">ISO 8601 formatted date time.</param>
        /// <param name="elapsedTime">In seconds.</param>
        /// <param name="description">Description of the activity.</param>
        /// <param name="distance">In meters.</param>
        /// <param name="trainer">Set to 1 to mark as a trainer activity.</param>
        /// <param name="commute">Set to 1 to mark as commute.</param>
        /// <param name="hideFromHome">Set to true to mute activity.</param>
        /// <returns>The activity's detailed representation. An instance of DetailedActivity.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        [Obsolete("Old version of the createActivity method. Not documented anymore but currently still working. The official documented actually does not work.", false)]
        public DetailedActivity CreateActivity(string name, ActivityType type, DateTime startDateLocal, TimeSpan elapsedTime, string description = null, float? distance = null, bool? trainer = null, bool? commute = null, bool? hideFromHome = null)
        {
            string resourcePath = "/activities";
            Method method = Method.Post;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            queryParam.Add("name", name);
            queryParam.Add("type", EnumUtil.GetEnumAttrValue(((ActivityType)type)));
            queryParam.Add("start_date_local", ((DateTime)startDateLocal).ToString("yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            queryParam.Add("elapsed_time", ((TimeSpan)elapsedTime).TotalSeconds.ToString("0", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (description != null) queryParam.Add("description", description);
            if (distance != null) queryParam.Add("distance", ((float)distance).ToString("0.000000000000000", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (trainer != null) queryParam.Add("trainer", ((bool)trainer).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (commute != null) queryParam.Add("commute", ((bool)commute).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (hideFromHome != null) queryParam.Add("hide_from_home", ((bool)hideFromHome).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedActivity>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the given activity that is owned by the authenticated athlete. Requires activity:read for Everyone and Followers activities. Requires activity:read_all for Only Me activities.</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <param name="includeAllEfforts">To include all segments efforts.</param>
        /// <returns>The activity's detailed representation. An instance of DetailedActivity.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedActivity GetActivityById(long id, bool? includeAllEfforts = null)
        {
            string resourcePath = "/activities/{id}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            if (includeAllEfforts != null) queryParam.Add("include_all_efforts", ((bool)includeAllEfforts).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")).ToLower(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedActivity>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the comments on the given activity. Requires activity:read for Everyone and Followers activities. Requires activity:read_all for Only Me activities.</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <param name="page">Deprecated. Prefer to use after_cursor.</param>
        /// <param name="perPage">Deprecated. Prefer to use page_size.</param>
        /// <param name="pageSize">Number of items per page. Defaults to 30.</param>
        /// <param name="afterCursor">Cursor of the last item in the previous page of results, used to request the subsequent page of results.  When omitted, the first page of results is fetched.</param>
        /// <returns>An array of Comment objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Comment[] GetCommentsByActivityId(long id, int? page = null, int? perPage = null, int? pageSize = null, Comment afterComment = null)
        {
            string resourcePath = "/activities/{id}/comments";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (pageSize != null) queryParam.Add("page_size", ((int)pageSize).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (afterComment != null) queryParam.Add("after_cursor", afterComment.Cursor);
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<Comment[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the athletes who kudoed an activity identified by an identifier. Requires activity:read for Everyone and Followers activities. Requires activity:read_all for Only Me activities.</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummaryAthlete objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummaryAthlete[] GetKudoersByActivityId(long id, int? page = null, int? perPage = null)
        {
            string resourcePath = "/activities/{id}/kudos";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<SummaryAthlete[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the laps of an activity identified by an identifier. Requires activity:read for Everyone and Followers activities. Requires activity:read_all for Only Me activities.</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <returns>An array of Lap objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public Lap[] GetLapsByActivityId(long id)
        {
            string resourcePath = "/activities/{id}/laps";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<Lap[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns the activities of an athlete for a specific identifier. Requires activity:read. Only Me activities will be filtered out unless requested by a token with activity:read_all.</summary>
        /// <param name="before">An epoch timestamp to use for filtering activities that have taken place before a certain time.</param>
        /// <param name="after">An epoch timestamp to use for filtering activities that have taken place after a certain time.</param>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummaryActivity objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummaryActivity[] GetLoggedInAthleteActivities(DateTime? before = null, DateTime? after = null, int? page = null, int? perPage = null)
        {
            string resourcePath = "/athlete/activities";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            if (before != null) queryParam.Add("before", (((DateTime)before).Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString("0", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (after != null) queryParam.Add("after", (((DateTime)after).Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString("0", System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<SummaryActivity[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Summit Feature. Returns the zones of a given activity. Requires activity:read for Everyone and Followers activities. Requires activity:read_all for Only Me activities.</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <returns>An array of ActivityZone objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public ActivityZone[] GetZonesByActivityId(long id)
        {
            string resourcePath = "/activities/{id}/zones";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<ActivityZone[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Updates the given activity that is owned by the authenticated athlete. Requires activity:write. Also requires activity:read_all in order to update Only Me activities</summary>
        /// <param name="id">The identifier of the activity.</param>
        /// <param name="data">An instance of UpdatableActivity.</param>
        /// <returns>The activity's detailed representation. An instance of DetailedActivity.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedActivity UpdateActivityById(long id, UpdatableActivity data = null)
        {
            string resourcePath = "/activities/{id}";
            Method method = Method.Put;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = "";
            if (data != null) bodyParam = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore});
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedActivity>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

