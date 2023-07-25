using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Auth;
using System.Net.Http.Headers;


namespace tryout1.Helpers
{
	public class AuthV1
	{
        public OAuth1Authenticator authentication;
        private static readonly HttpClient httpClient = new HttpClient();

        public AuthV1()
		{
            authentication = InitAuthentication();
            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authentication);
        }

        public OAuth1Authenticator InitAuthentication()
        {
            authentication = new OAuth1Authenticator(
               consumerKey: Constants.ConsumerKey,
               consumerSecret: Constants.ConsumerSecret,
               requestTokenUrl: new Uri(Constants.RequesttokenUrl),
               authorizeUrl: new Uri(Constants.AuthorizeUrl),
               accessTokenUrl: new Uri(Constants.AccessTokenUrl),
               callbackUrl: new Uri(Constants.CallbackUrl));



            authentication.Completed += OnAuthenticationCompletedV1;
            authentication.AllowCancel = false;

            return authentication;
          
        }

        public async Task<String[]> takeTokenAndVerifierAsyncV1(Uri uri)
        {
            var queryParameters = System.Web.HttpUtility.ParseQueryString(uri.Query);
            Debug.Print(uri.ToString());
            var oauthToken = queryParameters["oauth_token"];
            var oauthVerifier = queryParameters["oauth_verifier"];
            var oauthInfos = new string[] { oauthVerifier, oauthToken };
            return oauthInfos;
           // string accessToken = await GetAccessTokenAsyncV1(oauthVerifier, oauthToken);
        }


        public static async Task<string> GetAccessTokenAsyncV1(string oauthVerifier, string oauthToken)
        {
            var accessTokenUrl = "https://api.twitter.com/oauth/access_token";

            var uriBuilder = new UriBuilder(accessTokenUrl);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["oauth_verifier"] = oauthVerifier;
            query["oauth_token"] = oauthToken;
            uriBuilder.Query = query.ToString();
            var url = uriBuilder.Uri;

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Host = "api.twitter.com";


            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {   
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    // Handle the error response if needed.
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the request.
                return null;
            }
        }


        private async void OnAuthenticationCompletedV1(object sender, AuthenticatorCompletedEventArgs e)
        {
            Debug.Print("It Worked!");
            if (e.IsAuthenticated)
            {
                // Access the Twitter bearer token
                var BearerToken = e.Account.Properties["access_token"];
                Debug.Print(BearerToken);
            }
            else
            {
                // Authentication failed
            }
        }
    }
}

