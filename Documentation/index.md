# Introduction 
This is a .NET implementation of the Strava v3 API. It implements all Models and Endpoints documented on [Strava API and SDK Reference](https://developers.strava.com/docs/reference/). Since this documentation does not reflect the API behaviour in total some adaptions needed to be made.

# Documentation
Find the detailed documentation of all Endpoints and Models in the [API Documentation tab](api)

# Getting Started
1. Get started with your API on the [Strava getting started page](https://developers.strava.com/docs/getting-started/)
1. Create a Visual Studio Project and add the NuGet Package StravaApiV3Sharp.
1. Use the clientId and clientSecret from the Strava api page to establish a connection between your app and the strava service

```CSharp
[STAThread]
static void Main()
{
    // define the strava client specific info
    int clientId = 12345;
    string clientSecret = "abcdefghijklmnopqrstuvwxyz";
    // define the text file that holds the user authentication info
    string stravaAuth = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "stravaApi.txt");
    string serializedApi = System.IO.File.Exists(stravaAuth) ? System.IO.File.ReadAllText(stravaAuth) : null;
    string callbackUrl = "http://localhost/doesNotExist/";

    // create an instance of the api and reload the local stored auth info
    var api = new de.schumacher_bw.Strava.StravaApiV3Sharp(clientId, clientSecret, serializedApi);
    // add a delegate to the event of the refreshToken or authToken been updated
    api.SerializedObjectChanged += (s, e) => System.IO.File.WriteAllText(stravaAuth, api.Serialize());

    // create a winform that contains a browser 
    var form = new System.Windows.Forms.Form() { Width = 1000, Height = 1000 };
    var webView = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
    ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
    webView.Dock = System.Windows.Forms.DockStyle.Fill;
    form.Controls.Add(webView);
    ((System.ComponentModel.ISupportInitialize)webView).EndInit();


    // in case the app is not yet connected to the api => start the authentication prozedure
    if (api.Authentication.Scope == de.schumacher_bw.Strava.Model.Scopes.None_Unknown)
    {
        // ensure to be called again once the authentication is done. 
        // We will be forewared to a not existing url and catch this event
        webView.NavigationStarting += (s, e) =>
        {
            if (e.Uri?.AbsoluteUri.StartsWith(callbackUrl) ?? false) // in case we are forewarded to the callback URL
            {
                api.Authentication.DoTokenExchange(e.Uri); // do the token exchange with the stava api
                ShowInfoInBrowser(api, webView);
            }
        };

        // navigate to the strava auth page to get read access 
        webView.Navigate(api.Authentication.GetAuthUrl(new Uri(callbackUrl), de.schumacher_bw.Strava.Model.Scopes.Read));
    }
    else // the api is allready connected and the information have been loaded from the stravaAuth-file
    {
        ShowInfoInBrowser(api, webView);
    }

    form.ShowDialog();
    form.Dispose();
}

private static void ShowInfoInBrowser(de.schumacher_bw.Strava.StravaApiV3Sharp api, Microsoft.Toolkit.Forms.UI.Controls.WebView webView)
{
    var athlete = api.Athletes.GetLoggedInAthlete();
    webView.NavigateToString(String.Format("<h1>Hello {0}</h1>", athlete.Firstname));
}
```

# Terms of Use
* License: [MIT](https://opensource.org/licenses/mit-license.php)
* Ensure your a pp is complain to the [Strava API Agreement](https://www.strava.com/legal/api)