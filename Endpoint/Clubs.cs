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
    /// <summary>The Clubs endpoint</summary>
    public class Clubs
    {
        private StravaApiV3Sharp.StravaRestClient RestClient { get; }

        /// <summary>Constructor of the Endpoint</summary>
        /// <param name="stravaApi">An instance of the StravaApiV3Sharp</param>
        internal Clubs(StravaApiV3Sharp stravaApi)
        {
            if (stravaApi == null) throw new ArgumentNullException(nameof(stravaApi));
            RestClient = stravaApi.RestClient;
        }
        
        /// <summary>Retrieve recent activities from members of a specific club. The authenticated athlete must belong to the requested club in order to hit this endpoint. Pagination is supported. Athlete profile visibility is respected for all activities.</summary>
        /// <param name="id">The identifier of the club.</param>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummaryActivity objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummaryActivity[] GetClubActivitiesById(long id, int? page = null, int? perPage = null)
        {
            string resourcePath = "/clubs/{id}/activities";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = new NameValueCollection();
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<SummaryActivity[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a list of the administrators of a given club.</summary>
        /// <param name="id">The identifier of the club.</param>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummaryAthlete objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummaryAthlete[] GetClubAdminsById(long id, int? page = null, int? perPage = null)
        {
            string resourcePath = "/clubs/{id}/admins";
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
        /// <summary>Returns a given club using its identifier.</summary>
        /// <param name="id">The identifier of the club.</param>
        /// <returns>The detailed representation of a club. An instance of DetailedClub.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public DetailedClub GetClubById(long id)
        {
            string resourcePath = "/clubs/{id}";
            Method method = Method.Get;

            NameValueCollection urlParam = new NameValueCollection();
            urlParam.Add("id", ((long)id).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            NameValueCollection queryParam = null;
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<DetailedClub>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
        /// <summary>Returns a list of the athletes who are members of a given club.</summary>
        /// <param name="id">The identifier of the club.</param>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummaryAthlete objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummaryAthlete[] GetClubMembersById(long id, int? page = null, int? perPage = null)
        {
            string resourcePath = "/clubs/{id}/members";
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
        /// <summary>Returns a list of the clubs whose membership includes the authenticated athlete.</summary>
        /// <param name="page">Page number. Defaults to 1.</param>
        /// <param name="perPage">Number of items per page. Defaults to 30.</param>
        /// <returns>An array of SummaryClub objects.</returns>
        /// <exception cref="FaultException">In case the Api returns an error</exception>
        public SummaryClub[] GetLoggedInAthleteClubs(int? page = null, int? perPage = null)
        {
            string resourcePath = "/athlete/clubs";
            Method method = Method.Get;

            NameValueCollection urlParam = null;
            NameValueCollection queryParam = new NameValueCollection();
            if (page != null) queryParam.Add("page", ((int)page).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            if (perPage != null) queryParam.Add("per_page", ((int)perPage).ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US")));
            string bodyParam = null;
            System.Collections.Generic.Dictionary<string, FileInfo> fileParam = null;

            return RestClient.Execute<SummaryClub[]>(resourcePath, method, urlParam, queryParam, bodyParam, fileParam);
        }
    }
}

