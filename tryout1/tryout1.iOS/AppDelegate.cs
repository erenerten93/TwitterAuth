using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Auth;

using Foundation;
using UIKit;
using Xamarin.Forms;

namespace tryout1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {

            // Convert the NSUrl to a string

            var formsApp = Xamarin.Forms.Application.Current;

            var mainPage = formsApp.MainPage;

            if (mainPage is MainPage contentPage)
            {
                // Access the MainPageViewModel from the MainPage's BindingContext
                var mainPageViewModel = contentPage.BindingContext as MainPageViewModel;

                // Call the HandleOpenUrlData method if the MainPageViewModel is available
                mainPageViewModel?.authV1.takeTokenAndVerifierAsyncV1(url);

                var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

                // Dismiss the topmost presented view controller
                if (rootViewController.PresentedViewController != null)
                {
                    rootViewController.PresentedViewController.DismissViewController(true, null);
                }
            }

            return true;

        }
         

        public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler) =>
            Xamarin.Essentials.Platform.ContinueUserActivity(application, userActivity, completionHandler)
            || base.ContinueUserActivity(application, userActivity, completionHandler);
        



    }
}

