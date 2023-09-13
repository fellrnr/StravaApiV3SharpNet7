using System;
using System.Collections.Generic;
using System.Text;
using de.schumacher_bw.Strava.Model;
using de.schumacher_bw.Strava;
using System.Collections.Specialized;

namespace de.schumacher_bw.Strava.Endpoint
{
    /// <summary>The authentication endpoint</summary>
    public class Authentication
    {
        private StravaApiV3SharpDataContainer DataContainer { get; }
        private StravaOAuthHander OAuthHander { get; }


        internal Authentication(StravaApiV3SharpDataContainer dataContainer)
        {
            DataContainer = dataContainer;
            OAuthHander = new StravaOAuthHander(dataContainer);
            dataContainer.OAuthHanderUpdateAccessToken = OAuthHander.UpdateAccessToken; //JFS must be called before access token is accessed
        }

        /// <summary>Signals if there is a refresh token available in the api</summary>
        public bool IsConnected => !String.IsNullOrEmpty(DataContainer.RefreshToken) && DataContainer.ClientId != 0;

        /// <summary>The Scope the user accepted during the authentication of the application</summary>
        public Scopes Scope => DataContainer.Scope;


        /// <summary>Handles the Token exchange after the user has accepted the authentication</summary>
        /// <param name="param">The parameters returned from the strava server</param>
        /// <returns>The refresh token that was exchanged</returns>
        public Scopes DoTokenExchange(NameValueCollection param) => OAuthHander.DoTokenExchange(param, out _);

        /// <summary>Handles the Token exchange after the user has accepted the authentication</summary>
        /// <param name="param">The parameters returned from the strava server</param>
        /// <param name="athlete">Returns the SummaryAthlete that is returned during the token exchange</param>
        /// <returns>The refresh token that was exchanged</returns>
        public Scopes DoTokenExchange(NameValueCollection param, out SummaryAthlete athlete) => OAuthHander.DoTokenExchange(param, out athlete);

        /// <summary>Handles the Token exchange after the user has accepted the authentication</summary>
        /// <param name="callbackUri">The callback URL returned from the strava server</param>
        /// <returns>The refresh token that was exchanged</returns>
        public Scopes DoTokenExchange(Uri callbackUri) => DoTokenExchange(callbackUri, out _);

        /// <summary>Handles the Token exchange after the user has accepted the authentication</summary>
        /// <param name="callbackUri">The callback URL returned from the strava server</param>
        /// <param name="athlete">Returns the SummaryAthlete that is returned during the token exchange</param>
        /// <returns>The refresh token that was exchanged</returns>
        public Scopes DoTokenExchange(Uri callbackUri, out SummaryAthlete athlete)
        {
            NameValueCollection param;
            try { param = System.Web.HttpUtility.ParseQueryString(callbackUri?.Query); }
            catch(ArgumentNullException) { param = null; }
            return DoTokenExchange(param, out athlete);
        }

        /// <summary>Creates a URL where the user can accept the access to the requested scopes</summary>
        /// <param name="redirectUrl">URL to which the user will be redirected after authentication. Must be within the callback domain specified by the application. localhost and 127.0.0.1 are white-listed.</param>
        /// <param name="scope">Requested scopes as flags. Applications should request only the scopes required for the application to function normally.</param>
        /// <param name="approvalPrompt">Use force to always show the authorization prompt even if the user has already authorized the current application, default is auto.</param>
        /// <param name="state">Returned in the redirect URI. Useful if the authentication is done from various points in an app.</param>
        /// <param name="webOrMobile">Whether the web or mobile page shall be opened</param>
        /// <returns>The URL with the parameters integrated ready to use</returns>
        public Uri GetAuthUrl(Uri redirectUrl, Scopes scope, ApprovalPrompt approvalPrompt = ApprovalPrompt.Auto, string state = null, WebMobile webOrMobile = WebMobile.Web)
        {
            if (redirectUrl == null) throw new ArgumentNullException(nameof(redirectUrl));
            string scopeString = Util.EnumUtil.GetEnumAttrValue(scope);

            System.Collections.Specialized.NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["client_id"] = DataContainer.ClientId.ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US"));
            queryString["redirect_uri"] = redirectUrl.AbsoluteUri;
            queryString["response_type"] = "code";
            if (scopeString.Length > 0) queryString["scope"] = scopeString;
            queryString["approval_prompt"] = approvalPrompt == ApprovalPrompt.Force ? "force" : "auto";
            if (state != null) queryString["state"] = state;
            return new Uri((webOrMobile == WebMobile.Web ? StravaApiV3SharpDataContainer.BaseUrlAuthWeb :  StravaApiV3SharpDataContainer.BaseUrlAuthMobile) 
                + "?" + queryString.ToString());
        }

        /// <summary>Clears the internal Tokens</summary>
        public void Disconnect() => OAuthHander.Disconnect();

        private class StravaOAuthHander
        {
            private StravaApiV3SharpDataContainer DataContainer { get; }
            public StravaOAuthHander(StravaApiV3SharpDataContainer dataContainer) => DataContainer = dataContainer;

            public void UpdateAccessToken() 
            {
                var jsonResponse = PostToAuthToken(GrantType.refresh_token);

                DataContainer.AccessToken = jsonResponse.AccessToken;
                DataContainer.AccessTokenExpiresUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double)jsonResponse.ExpiresAt);
                DataContainer.OnSerializedObjectChanged();
            }
            public Scopes DoTokenExchange(NameValueCollection param, out SummaryAthlete athlete)
            {
                string refreshToken = null;
                string accessToken = null;
                Scopes scope = Scopes.None_Unknown;
                DateTime accessTokenExpiresUtc = DateTime.MinValue;
                athlete = null;

                // make sure parameters is not null but at least a empty NameValueCollection
                if (param == null) param = new NameValueCollection();

                /* Strava will respond to the authorization request by redirecting the user agent to the redirect_uri provided.
                 * If access is denied, error = access_denied will be included in the query string. 
                 * If access is accepted, code and scope parameters will be included in the query string.
                 *   The code parameter contains the authorization code required to complete the authentication process. 
                 *   The application must now call the POST https://www.strava.com/oauth/token with its client ID and 
                 *   client secret to exchange the authorization code for a refresh token and short-lived access token.
                 */

                // check if access was accepted
                var error = param["error"];

                if (error == "access_denied") { } // initialize values cover "access_denied" => no refresh token, no Scope, no access token
                else
                {
                    scope = Util.EnumUtil.GetEnumValue<Scopes>(param["scope"] ?? "");

                    // do the token exchange
                    var jsonResponse = PostToAuthToken(GrantType.authorization_code, param["code"] ?? "");

                    refreshToken = jsonResponse.RefreshToken;
                    accessToken = jsonResponse.AccessToken;
                    accessTokenExpiresUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double)jsonResponse.ExpiresAt);
                    athlete = jsonResponse.Athlete;
                }

                // only in case the refresh token has been transfered correctly, save the updated values
                if (!String.IsNullOrEmpty(refreshToken)) {
                    DataContainer.AccessToken = accessToken;
                    DataContainer.AccessTokenExpiresUtc =  accessTokenExpiresUtc;
                    DataContainer.RefreshToken = refreshToken;
                    DataContainer.Scope = scope;
                    DataContainer.OnSerializedObjectChanged();
                }
                else Disconnect();

                return DataContainer.Scope;
            }
            public void Disconnect()
            {
                DataContainer.AccessToken = null;
                DataContainer.AccessTokenExpiresUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DataContainer.RefreshToken = null;
                DataContainer.Scope = Scopes.None_Unknown;
                DataContainer.OnSerializedObjectChanged();
            }


            #region private methods
            private enum GrantType { authorization_code, refresh_token };
            private OAuthTokenResponse PostToAuthToken(GrantType grantType, string code = "")
            {
                var client = new System.Net.Http.HttpClient { BaseAddress = new Uri(StravaApiV3SharpDataContainer.BaseUrlToken) };
                var content = new System.Net.Http.FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("client_id", DataContainer.ClientId.ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US"))),
                        new KeyValuePair<string, string>("client_secret", DataContainer.ClientSecret),
                        new KeyValuePair<string, string>("grant_type", grantType.ToString()),
                        new KeyValuePair<string, string>(
                            grantType == GrantType.authorization_code ? "code" : "refresh_token",
                            grantType == GrantType.authorization_code ? code : DataContainer.RefreshToken),
                    });
                var result = client.PostAsync("", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                content.Dispose();
                client.Dispose();

                if (result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.Created)
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<OAuthTokenResponse>(resultContent);
                else
                    throw new Util.FaultException(Newtonsoft.Json.JsonConvert.DeserializeObject<Fault>(resultContent));
            }

            #pragma warning disable CA1812
            private class OAuthTokenResponse
            {
                [Newtonsoft.Json.JsonProperty("refresh_token")]
                public string RefreshToken { get; set; }

                [Newtonsoft.Json.JsonProperty("access_token")]
                public string AccessToken { get; set; }

                [Newtonsoft.Json.JsonProperty("expires_at")]
                public int ExpiresAt { get; set; }

                [Newtonsoft.Json.JsonProperty("athlete")]
                public SummaryAthlete Athlete { get; set; }
            }
            #endregion
        }

    }
}