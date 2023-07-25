using System;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Forms;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using tryout1.Helpers;
using tryout1.AuthTypes;

namespace tryout1
{
    public class MainPageViewModel
    {

        public bool isAuthorized = false;

        public AuthV1 authV1;
        public AuthV2 authV2;
        public AuthV2Raw authV2Raw;

        public OAuth2Authenticator authenticationV2;
        public OAuth1Request request;

        public ICommand AuthorizationV1Command => new Command(AuthorizationV1);
        public ICommand AuthorizationV2Command => new Command(AuthorizationViaLibraryV2);
        public ICommand AuthorizationRawCommand => new Command(async () => await AuthorizationRaw());

        private string oauthToken = "";  //Request token
        private string oauthVerifier = ""; 

        public static string BearerToken { get; set; }


        private void AuthorizationV1()
        {
            authV1 = new AuthV1();
            isAuthorized = true;
        }





        public void AuthorizationViaLibraryV2()
        {
            authV2 = new AuthV2();
            isAuthorized = true;
        }

        private async Task AuthorizationRaw()
        {
            authV2Raw = new AuthV2Raw();
            isAuthorized = true;
        }


    }
}



