using de.schumacher_bw.Strava.Endpoint;
using de.schumacher_bw.Strava.Model;
using de.schumacher_bw.Strava.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace de.schumacher_bw.Strava
{
    /// <summary>The main entry point for the Strava Api</summary>
    public class StravaApiV3Sharp
    {
        #region Constructors and Serialization

        internal StravaRestClient RestClient { get; }
        private readonly StravaApiV3SharpDataContainer DataContainer;


        /// <summary>
        /// Constructor to restore a serialized api with all internal tokens.
        /// </summary>
        /// <param name="clientId">The application’s ID, obtained during registration.</param>
        /// <param name="clientSecret">The application’s secret, obtained during registration.</param>
        /// <param name="serializedObject">A serialized version of the api that contains all information created during token exchange</param>
        public StravaApiV3Sharp(int clientId, string clientSecret, string serializedObject) : this(clientId, clientSecret)
            => DataContainer.LoadSerializedData(serializedObject);

        /// <summary>
        /// Initial constructor of the Api when no token are exchanged.
        /// Use the Authentication Endpoint (GetAuthUrl and DoTokenExchange) to get the required tokens.
        /// Please store a serialized version of the api in your application on the OnSerializedObjectChanged event.
        /// To restore the api use the constructor that takes 3 parameter and support the serialized object.
        /// </summary>
        /// <param name="clientId">The application’s ID, obtained during registration.</param>
        /// <param name="clientSecret">The application’s secret, obtained during registration.</param>
        public StravaApiV3Sharp(int clientId, string clientSecret)
        {
            // create the data container
            DataContainer = new StravaApiV3SharpDataContainer(clientId, clientSecret,
                () => SerializedObjectChanged?.Invoke(this, EventArgs.Empty));


            //JFS reverse order of next two calls
            //JFS must be called before access token is accessed
            Authentication = new Endpoint.Authentication(DataContainer);


            RestClient = new StravaRestClient(this); //JFS needs the access token


            Activities = new Activities(this);
            Athletes = new Athletes(this);
            Clubs = new Clubs(this);
            Gears = new Gears(this);
            Routes = new Routes(this);
            SegmentEfforts = new SegmentEfforts(this);
            Segments = new Segments(this);
            Streams = new Streams(this);
            Uploads = new Uploads(this);
        }

        /// <summary>Event in case the internal token have been changed and the api should be stored in your app</summary>
        public event EventHandler SerializedObjectChanged;

        /// <summary>Method to serialize the api</summary>
        /// <returns>A json string with all internal information</returns>
        public string Serialize() => DataContainer.ToString();
        #endregion

        #region public Endpoints
        /// <summary>The endpoint to handle all the authentication topics</summary>
        [JsonIgnore]
        public Authentication Authentication { get; }
        /// <summary>The endpoint to handle all the activities topics</summary>
        [JsonIgnore]
        public Activities Activities { get; }
        /// <summary>The endpoint to handle all the athlete topics</summary>
        [JsonIgnore]
        public Athletes Athletes { get; }
        /// <summary>The endpoint to handle all the club topics</summary>
        [JsonIgnore]
        public Clubs Clubs { get; }
        /// <summary>The endpoint to handle all the club topics</summary>
        [JsonIgnore]
        public Gears Gears { get; }
        /// <summary>The endpoint to handle all the route topics</summary>
        [JsonIgnore]
        public Routes Routes { get; }
        /// <summary>The endpoint to handle all the segment effort topics</summary>
        [JsonIgnore]
        public SegmentEfforts SegmentEfforts { get; }
        /// <summary>The endpoint to handle all the segment topics</summary>
        [JsonIgnore]
        public Segments Segments { get; }
        /// <summary>The endpoint to handle all the stream topics</summary>
        [JsonIgnore]
        public Streams Streams { get; }
        /// <summary>The endpoint to handle all the upload topics</summary>
        [JsonIgnore]
        public Uploads Uploads { get; }
        #endregion

        #region private sub classes
        internal class StravaRestClient
        {
            private RestClient RestClient { get; }

            public StravaRestClient(StravaApiV3Sharp stravaApi)
            {
                //JFS

                //RestClient = new RestClient(StravaApiV3SharpDataContainer.BaseUrlApi) { Authenticator  = new StravaAuthenticator(stravaApi), IgnoreResponseStatusCode = true };


                //JFS - getting access token requires oAuthHanderUpdateAccessToken method to be set

                //JFS - try using the StravaAuthenticator rather than the rest sharp OA2 (we don't have the access token at this point)
                //var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator( stravaApi.DataContainer.AccessToken, "Bearer" );

                var authenticator = new StravaAuthenticator(stravaApi);
                var options = new RestClientOptions(StravaApiV3SharpDataContainer.BaseUrlApi)
                {
                    Authenticator = authenticator
                };
                RestClient = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());

            }

            public T Execute<T>(string Resource, Method method, NameValueCollection urlParam, NameValueCollection queryParam, string jsonBody, Dictionary<string, FileInfo> files)
            {
#if DEBUG
                var FaultLogFile = "FaultLogFile.log";
                if (!File.Exists(FaultLogFile)) File.WriteAllText(FaultLogFile, "");
#endif

                var response = ExecuteInternal(Resource, method, urlParam, queryParam, jsonBody, files);
                string jsonResponse = response.Content;

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    T obj = JsonConvert.DeserializeObject<T>(jsonResponse);

#if CHECK_ALL_ELEMENTS_COVERED
#pragma warning disable CA1303
                    string[] doNotImplementSinceValueIsRedundantOrNotRequired = new string[] {
                        "DetailedActivity/start_latitude", // same info in StartLatlng.Lat
                        "DetailedActivity/start_longitude", // same info in StartLatlng.Lng
                        "DetailedActivity/segment_efforts/i/segment/start_latitude", // same info in StartLatlng.Lat
                        "DetailedActivity/segment_efforts/i/segment/start_longitude", // same info in StartLatlng.Lng
                        "DetailedActivity/segment_efforts/i/segment/end_latitude", // same info in EndLatlng.Lat
                        "DetailedActivity/segment_efforts/i/segment/end_longitude", // same info in EndLatlng.Lng
                        "SummaryActivity[]/start_latitude", // same info in StartLatlng.Lat
                        "SummaryActivity[]/start_longitude", // same info in StartLatlng.Lng
                        "Route/segments/i/start_latitude", // same info in StartLatlng.Lng
                        "Route/segments/i/start_longitude", // same info in StartLatlng.Lat
                        "Route/segments/i/end_latitude", // same info in EndLatlng.Lat
                        "Route/segments/i/end_longitude", // same info in EndLatlng.Lng
                        "DetailedSegmentEffort[]/segment/start_latitude", // same info in StartLatlng.Lat
                        "DetailedSegmentEffort[]/segment/start_longitude", // same info in StartLatlng.Lng
                        "DetailedSegmentEffort[]/segment/end_latitude", // same info in EndLatlng.Lat
                        "DetailedSegmentEffort[]/segment/end_longitude", // same info in EndLatlng.Lng
                        "DetailedSegmentEffort/segment/start_latitude", // same info in StartLatlng.Lat
                        "DetailedSegmentEffort/segment/start_longitude", // same info in StartLatlng.Lng
                        "DetailedSegmentEffort/segment/end_latitude", // same info in EndLatlng.Lat
                        "DetailedSegmentEffort/segment/end_longitude", // same info in EndLatlng.Lng
                        "SummarySegment[]/start_latitude", // same info in StartLatlng.Lat
                        "SummarySegment[]/start_longitude", // same info in StartLatlng.Lng
                        "SummarySegment[]/end_latitude", // same info in EndLatlng.Lat
                        "SummarySegment[]/end_longitude", // same info in EndLatlng.Lng
                        "DetailedSegment/start_latitude", // same info in StartLatlng.Lat
                        "DetailedSegment/start_longitude", // same info in StartLatlng.Lng
                        "DetailedSegment/end_latitude", // same info in EndLatlng.Lat
                        "DetailedSegment/end_longitude", // same info in EndLatlng.Lng

                        "DetailedAthlete/friend", // DetailedAthlete is always the object of the logged in athlete and he will never be friend with himself
                        "DetailedAthlete/follower", // DetailedAthlete is always the object of the logged in athlete and he will never be follow himself
                        "DetailedAthlete/blocked", // DetailedAthlete is always the object of the logged in athlete and it makes no sense to be blocked by myself?
                        "DetailedAthlete/can_follow", // DetailedAthlete is always the object of the logged in athlete => no I can't follow myself

                        "DetailedSegment/starred_date", // not documented and only returned directly after starring... I know the date then...
                        
                        "Upload/id_str", // same info in long id
                        "Route/id_str", // same info in long id
                        "Route[]/id_str", // same info in long id

                        "SummarySegment[]/elevation_profile", // elevation profile was always null for Summary segment
                        "DetailedActivity/segment_efforts/i/segment/elevation_profile", // elevation profile was always null for Summary segment
                        "Route/segments/i/elevation_profile", // elevation profile was always null for Summary segment
                        "DetailedSegmentEffort[]/segment/elevation_profile", // elevation profile was always null for Summary segment
                        "DetailedSegmentEffort/segment/elevation_profile", // elevation profile was always null for Summary segment
                        "ExplorerResponse/segments/i/elevation_profile", // elevation profile was always null for Summary segment

                        "DetailedAthlete/shoes/i/converted_distance", // same value than distance 
                        "DetailedAthlete/bikes/i/converted_distance", // same value than distance 
                        "DetailedActivity/gear/converted_distance", // same value than distance 
                        "DetailedGear/converted_distance", // same value than distance 
                        "Route/athlete/weight", // the weight is only populated if the athlete is the logged in user
                        "Route[]/athlete/weight", // the weight is only populated if the athlete is the logged in user

                    };

                    string[] currentlyNotImplementdToBeChecked = new string[] {
                        "Comment[]/mentions_metadata", // no documentation
                        "Comment[]/post_id", // no documentation

                        "DetailedActivity/laps/i/device_watts", // ???
                        "Lap[]/device_watts", // ???
                        "DetailedActivity/laps/i/average_watts", // ???
                        "Lap[]/average_watts", // ???

                        "DetailedActivity/average_temp", // ???
                        "SummaryActivity[]/average_temp", // ???
                        "DetailedActivity/suffer_score", // ???
                        "SummaryActivity[]/suffer_score", // ???

                        "Route[]/map_urls",
                        "Route/map_urls",

                        "DetailedActivity/stats_visibility",
                        "DetailedActivity/similar_activities", // not yet implemented #35
                        "DetailedActivity/available_zones", // not yet implemented #35

                        "SummaryAthlete[]/membership", // Not implemented in summaryAthlete
                        "SummaryAthlete[]/admin", // Not implemented in summaryAthlete
                        "SummaryAthlete[]/owner", // Not implemented in summaryAthlete

                        "DetailedSegment/local_legend", // is not implemented
                        "DetailedSegment/xoms", // is not implemented

                        "ExplorerResponse/segments/i/local_legend_enabled", // is not implemented

                        "Route/athlete/friend", // is not implemented
                        "Route/athlete/follower", // is not implemented
                        "Route[]/athlete/friend", // is not implemented
                        "Route[]/athlete/follower", // is not implemented




                        "DetailedAthlete/clubs/i/activity_types_icon",
                        "DetailedClub/activity_types_icon",
                        "SummaryClub[]/activity_types_icon",
                        "DetailedClub/dimensions",
                        "SummaryClub[]/dimensions",
                        "DetailedAthlete/clubs/i/dimensions",

                        "DetailedActivity/sport_type",
                        "SummaryActivity[]/sport_type",
                        "DetailedActivity/photos/primary/media_type",

                         "Comment[]/reaction_count",
                         "Comment[]/has_reacted",
                        "DetailedAthlete/is_winback_via_upload",
                        "DetailedAthlete/is_winback_via_view",
                    };

                    string[] ignoreBelowPath = new string[]
                    {
                        "DetailedSegmentEffort/athlete/", // Definition says its a MetaAthlete but sometimes a DetailedAthlete is returned
                        "DetailedSegmentEffort/activity/", // Definition says its a MetaActivity but sometimes a DetailedActivity is returned
                    };

                    var stack = new Stack<Tuple<Newtonsoft.Json.Linq.JToken, Newtonsoft.Json.Linq.JToken, string>>();
                    var throwExceptionProperties = new List<string>();

                    var apiJsonObj = JsonConvert.DeserializeObject(jsonResponse);
                    var locJsonObj = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(obj));

                    if (apiJsonObj is Newtonsoft.Json.Linq.JObject && locJsonObj is Newtonsoft.Json.Linq.JObject)
                        stack.Push(new Tuple<Newtonsoft.Json.Linq.JToken, Newtonsoft.Json.Linq.JToken, string>(
                            (Newtonsoft.Json.Linq.JObject)apiJsonObj, (Newtonsoft.Json.Linq.JObject)locJsonObj, "/"));
                    else if (apiJsonObj is Newtonsoft.Json.Linq.JArray && locJsonObj is Newtonsoft.Json.Linq.JArray)
                    {
                        var apiJsonObjAry = (Newtonsoft.Json.Linq.JArray)apiJsonObj;
                        var locJsonObjAry = (Newtonsoft.Json.Linq.JArray)locJsonObj;

                        if (apiJsonObjAry.Count != locJsonObjAry.Count) throw new Exception("Api and Local array do not fit");

                        for (int i = 0; i < apiJsonObjAry.Count; i++)
                            stack.Push(new Tuple<Newtonsoft.Json.Linq.JToken, Newtonsoft.Json.Linq.JToken, string>(apiJsonObjAry[i], locJsonObjAry[i], "/"));
                    }
                    else throw new NotImplementedException();


                    while (stack.Count > 0)
                    {
                        var fromStack = stack.Pop();
                        var apiElm = fromStack.Item1;
                        var locElm = fromStack.Item2;
                        var path = fromStack.Item3;

                        if (apiElm is Newtonsoft.Json.Linq.JArray)
                        {
                            if (!(locElm is Newtonsoft.Json.Linq.JArray) || apiElm.Count() != locElm.Count()) throw new Exception("Api and Local array do not fit");

                            var apiElmAry = (Newtonsoft.Json.Linq.JArray)apiElm;
                            var locElmAry = (Newtonsoft.Json.Linq.JArray)locElm;

                            for (int i = 0; i < apiElm.Count(); i++)
                                stack.Push(new Tuple<Newtonsoft.Json.Linq.JToken, Newtonsoft.Json.Linq.JToken, string>(apiElmAry[i], locElmAry[i], path + "i" + "/"));
                        }



                        else if (apiElm is Newtonsoft.Json.Linq.JObject)
                        {
                            foreach (var apiChild in apiElm.Children())
                            {
                                if (apiChild is Newtonsoft.Json.Linq.JProperty apiChilpProp)
                                {
                                    var apiChildValue = apiChilpProp.Value;
                                    var locChildValue = locElm[apiChilpProp.Name];

                                    if (locChildValue == null)
                                    {
                                        // the local model does not contain the property
                                        string propPath = typeof(T).Name + path + apiChilpProp.Name;

                                        if (doNotImplementSinceValueIsRedundantOrNotRequired.Contains(propPath)) { }
                                        // Not to be implemented => OK

                                        else if (currentlyNotImplementdToBeChecked.Contains(propPath)) { }
                                        // Currently not implemented => OK for now

                                        else if (ignoreBelowPath.Any(x => propPath.StartsWith(x, false, System.Globalization.CultureInfo.GetCultureInfo("De-DE")))) { }
                                        // Ignored Path => OK

                                        else throwExceptionProperties.Add(propPath);
                                    }

                                    // in case the apiElement has child nodes, add them to the stack
                                    else if (apiChildValue.HasValues)
                                    {
                                        stack.Push(new Tuple<Newtonsoft.Json.Linq.JToken, Newtonsoft.Json.Linq.JToken, string>(apiChildValue, locChildValue, path + apiChilpProp.Name + "/"));
                                    }
                                }
                                else
                                {
                                    throw new NotImplementedException();
                                }
                            }
                        } // Newtonsoft.Json.Linq.JArray

                        else if (apiElm is Newtonsoft.Json.Linq.JValue)
                        {
                            if (!(locElm is Newtonsoft.Json.Linq.JValue)) throw new Exception("Api and Local values do not fit");
                        }


                        else
                        {
                            // new Json.Linq Type
                            throw new NotImplementedException();
                        }

                        if(throwExceptionProperties.Count != 0)
                        {
                            throw new NotImplementedException(
                                "The property following properties are not implemented:\r\n\"" + 
                                String.Join("\",\r\n\"", throwExceptionProperties.ToArray()) + "\",");

                        }
                    }
#pragma warning restore CA1303
#endif
                    return obj;
                }
                else
                {
                    Fault fault;
                    try
                    {
                        fault = JsonConvert.DeserializeObject<Fault>(jsonResponse);
                    } 
                    catch
                    {
                        jsonResponse = "{ \"message\": \"" + jsonResponse.Replace("\"","\\\"") + "\" }";
                        fault = JsonConvert.DeserializeObject<Fault>(jsonResponse);
                    }

#if DEBUG
                    // in case of Debug, we want to write the fault message into the error Message Log:
                    var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                    File.AppendAllText(FaultLogFile, String.Format(culture, "{0}: {1}\r\n{2}\r\n", 
                        DateTime.Now.ToString("o", culture), jsonResponse, Environment.StackTrace));
#endif
                    throw new Util.FaultException(fault);
                }
            }

            public Stream Execute(string Resource, Method method, NameValueCollection urlParam, NameValueCollection queryParam, string jsonBody, Dictionary<string, FileInfo> files)
            {
                var response = ExecuteInternal(Resource, method, urlParam, queryParam, jsonBody, files);

                MemoryStream ms = new MemoryStream();

                #pragma warning disable IDE0067
                #pragma warning disable CA2000
                var sw = new StreamWriter(ms, new System.Text.UnicodeEncoding());
                #pragma warning restore CA2000
                #pragma warning restore IDE0067

                sw.Write(response.Content);
                sw.Flush();//otherwise you are risking empty stream
                ms.Seek(0, SeekOrigin.Begin);

                return ms;
            }

            public string Limit { get; private set; }
            public string Usage { get; private set; }


            private RestResponse ExecuteInternal(string Resource, Method method, NameValueCollection urlParam, NameValueCollection queryParam, string jsonBody, Dictionary<string, FileInfo> files)
            {
                var request = new RestRequest(StravaApiV3SharpDataContainer.BaseApiEntryPoint + Resource, method);
                if (urlParam != null) foreach (var name in urlParam.AllKeys) request.AddUrlSegment(name, urlParam[name]);
                if (queryParam != null) foreach (var name in queryParam.AllKeys) request.AddParameter(name, queryParam[name]);
                if (jsonBody != null) request.AddParameter("application/json; charset=utf-8", System.Text.Encoding.UTF8.GetBytes(jsonBody), ParameterType.RequestBody);
                if (files != null) foreach (var name in files.Keys) request.AddFile(name, File.ReadAllBytes(files[name].FullName), files[name].Name);

                //var response = RestClient.Execute(request).Result; //#!JFS#!
                RestResponse response = RestClient.Execute(request);

                //Limit = response.Headers.GetValue("X-Ratelimit-Limit");
                //Usage = response.Headers.GetValue("X-Ratelimit-Usage");

                foreach(HeaderParameter hp in response.Headers)
                {
                    if (hp.Name == "X-Ratelimit-Limit")
                        Limit = hp.Value.ToString();
                    if (hp.Name == "X-Ratelimit-Usage")
                        Usage = hp.Value.ToString();
                }

                /*
                Limit = response.Headers
                    .Where(x => x.Name == "X-Ratelimit-Limit")
                    .Select(x => x.Value)
                    .FirstOrDefault().ToString();
                Usage = response.Headers
                    .Where(x => x.Name == "X-Ratelimit-Usage")
                    .Select(x => x.Value)
                    .FirstOrDefault().ToString();
                */

                return response;    
            }
        }

        /*
public abstract class AuthenticatorBase : IAuthenticator {
    protected AuthenticatorBase(string token) => Token = token;

    protected string Token { get; set; }

    protected abstract ValueTask<Parameter> GetAuthenticationParameter(string accessToken);

    public async ValueTask Authenticate(IRestClient client, RestRequest request)
        => request.AddOrUpdateParameter(await GetAuthenticationParameter(Token).ConfigureAwait(false));
}

public interface IAuthenticator {
    ValueTask Authenticate(IRestClient client, RestRequest request);
}
        */
        private class StravaAuthenticator : IAuthenticator
        {
            private readonly StravaApiV3Sharp _stravaApi;

            public StravaAuthenticator(StravaApiV3Sharp stravaApi) 
            {
                _stravaApi = stravaApi;
            }


            public async ValueTask Authenticate(IRestClient client, RestRequest request) => request.AddOrUpdateParameter(await GetAuthenticationParameter().ConfigureAwait(false));

            protected ValueTask<Parameter> GetAuthenticationParameter()
            {
                string token = !string.IsNullOrEmpty(_stravaApi.DataContainer.AccessToken) ? _stravaApi.DataContainer.AccessToken : "";
                return new ValueTask<Parameter>(new HeaderParameter(KnownHeaders.Authorization, "Bearer " + token));
            }


            /* JFS, this is from the earlier version
            public Task PreAuthenticate(IRestClient client, RestRequest request, System.Net.ICredentials credentials)
            {
                return Task.Run(() =>
                {
                    if (!string.IsNullOrEmpty(_stravaApi.DataContainer.AccessToken)) 
                        request.AddHeader("Authorization", "Bearer " + _stravaApi.DataContainer.AccessToken);
                });
            }
            */
        }
        #endregion

        protected ValueTask<Parameter> GetAuthenticationParameter(string accessToken) { return new ValueTask<Parameter>(); }


        /// <summary>The rate limits for the 15 minute period</summary>
        public LimitUsage Limit15Minutes => new LimitUsage(this.RestClient.Limit, this.RestClient.Usage, true);
        /// <summary>The rate limits for the daily period</summary>
        public LimitUsage LimitDaily => new LimitUsage(this.RestClient.Limit, this.RestClient.Usage, false);
    }
}