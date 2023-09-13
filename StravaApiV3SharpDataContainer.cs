using Newtonsoft.Json;
using System;

namespace de.schumacher_bw.Strava
{
    internal class StravaApiV3SharpDataContainer
    {
        private StravaApiV3SharpDataContainer() { }
        internal StravaApiV3SharpDataContainer(int clientId, string clientSecret, Action onSerializedObjectChanged)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            OnSerializedObjectChanged = onSerializedObjectChanged;

            AccessTokenExpiresUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        public void LoadSerializedData(string serializedObject)
        {
            if (!String.IsNullOrEmpty(serializedObject))
            {
                var tmp = JsonConvert.DeserializeObject<StravaApiV3SharpDataContainer>(serializedObject);

                AccessToken = tmp._accessToken; // read the internal to avoid updating the token
                AccessTokenExpiresUtc = tmp.AccessTokenExpiresUtc;
                RefreshToken = tmp.RefreshToken;
                Scope = tmp.Scope;
            }
        }
        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings 
            { DateTimeZoneHandling = DateTimeZoneHandling.Unspecified });

        public const string BaseUrlApi = "https://www.strava.com";
        public const string BaseApiEntryPoint = "/api/v3";
        public const string BaseUrlToken = "https://www.strava.com/oauth/token";
        public const string BaseUrlAuthWeb = "https://www.strava.com/oauth/authorize";
        public const string BaseUrlAuthMobile = "https://www.strava.com/oauth/mobile/authorize";

        [JsonProperty(PropertyName = "AccessToken")]
        private string _accessToken = null;
        [JsonIgnore]
        public string AccessToken
        {
            get
            {
                if (AccessTokenExpiresUtc.ToLocalTime().AddMinutes(-5) < DateTime.Now) _oAuthHanderUpdateAccessToken(); //JFS Exception here from _oAuthHanderUpdateAccessToken is null
                return _accessToken;
            }
            set => _accessToken = value;
        }
        [JsonProperty]
        public DateTime AccessTokenExpiresUtc { get; set; }
        [JsonProperty]
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public int ClientId { get; }
        [JsonIgnore]
        public string ClientSecret { get; }
        [JsonProperty]
        public Model.Scopes Scope { get; set; }

        #region events
        [JsonIgnore]
        private Action _oAuthHanderUpdateAccessToken;
        [JsonIgnore]
        public Action OAuthHanderUpdateAccessToken { set => _oAuthHanderUpdateAccessToken = value; }

        [JsonIgnore]
        public Action OnSerializedObjectChanged { get; }
        #endregion
    }
}
