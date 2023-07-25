using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace tryout1.AuthTypes
{
    public class AuthV2Raw
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public AuthV2Raw()
        {
            Task task = init();
        }

        private async Task init()
        {
            var url = "https://api.twitter.com/oauth2/token?grant_type=client_credentials";

            // Encode the credentials in Base64
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Constants.ConsumerKey}:{Constants.ConsumerSecret}"));
            HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
            // Add the Authorization header to the request
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            HttpResponseMessage response = await httpClient.PostAsync(url, content);


            if (response.IsSuccessStatusCode)
            {
                string content1 = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON string into the AccessTokenResponse object
                AccessTokenResponse accessTokenReponse = JsonConvert.DeserializeObject<AccessTokenResponse>(content1);

                // Access the access token from the AccessTokenResponse object
                string accessBearerToken = accessTokenReponse.AccessToken;
                await GetUserTimelineAsync(accessBearerToken);
            }
            else
            {
                // Handle the error response if needed.

            }
        }


        public static async Task<string> GetUserTimelineAsync(String AccessBearerToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json?count=100&screen_name=twitterapi");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessBearerToken);
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");

                HttpResponseMessage response = await httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Debug.Print(responseContent);
                    return responseContent;
                }
                else
                {
                    // Handle the error response if needed.
                    return null;
                }
            }
        }

        async Task GetUserIdFromUsernameAsync()
        {

            // Set up the Twitter API credentials
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "OAuth",
                    "oauth_token=, oauth_token_secret="
                );
            var response = await httpClient.GetAsync("https://api.twitter.com/2/users/1145384588/tweets");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                // Handle the API response here (e.g., deserialize JSON data)
                // For this example, we'll just show the response content

            }
            else
            {

            }

        }
    }
}

