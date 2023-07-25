using System;
using Xamarin.Auth;
using Xamarin.Forms.Shapes;

namespace tryout1.Helpers
{
	public class AuthV2
	{
        OAuth2Authenticator authenticationV2;

		public AuthV2()
        {

            authenticationV2 = CreateAuthenticatorV2();
            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticationV2);
        }

        public OAuth2Authenticator CreateAuthenticatorV2()
        {
            var authenticator = new OAuth2Authenticator(
                clientId: Constants.ConsumerKey,
                clientSecret: Constants.ConsumerSecret,
                scope: Constants.scope,
                authorizeUrl: new Uri(Constants.AuthorizeUrl),
                redirectUrl: new Uri(Constants.CallbackUrl),
                accessTokenUrl: new Uri(Constants.AccessTokenUrl));

            authenticator.Completed += OnAuthenticationCompletedV2;
            authenticator.Error += OnAuthenticationErrorV2;

            return authenticator;
        }

        private static void OnAuthenticationCompletedV2(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                // Access token is available in e.Account.Properties["access_token"]
                // Use the token for API requests
            }
            else
            {
                // Not authenticated
            }
        }

        private static void OnAuthenticationErrorV2(object sender, AuthenticatorErrorEventArgs e)
        {
            // Handle authentication errors
        }
    }
}

