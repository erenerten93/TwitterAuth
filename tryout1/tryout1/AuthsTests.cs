using System;
using System.Threading.Tasks;
using NUnit.Framework;
using tryout1.Helpers;
using Xamarin.Auth;

[TestFixture]
public class AuthsTests
{
    [Test]
    public async Task takeTokenAndVerifierAsyncV1_Should_Return_OauthInfos()
    {
        // Arrange
        // Create a Uri with mock query parameters for testing
        var uri = new Uri("https://example.com?oauth_token=mock_token&oauth_verifier=mock_verifier");

        // Create an instance of the class containing the method to test
        var authV1Tests = new AuthV1(); // Assuming MyTestClass is the class containing takeTokenAndVerifierAsyncV1

        // Act
        var result = await authV1Tests.takeTokenAndVerifierAsyncV1(uri);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual("mock_verifier", result[0]);
        Assert.AreEqual("mock_token", result[1]);
    }

    public void InitAuthentication_Should_Return_OAuth1Authenticator()
    {
        // Arrange
        var myClass = new AuthV1(); // Assuming MyTestClass is the class containing the InitAuthentication method
        var mockOAuth1Authenticator = myClass.InitAuthentication();
 
        Assert.IsInstanceOf<OAuth1Authenticator>(mockOAuth1Authenticator);
      
    }
}