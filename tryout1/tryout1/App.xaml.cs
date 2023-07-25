using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tryout1
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            MainPageViewModel vm = new MainPageViewModel();
            var page = new MainPage(vm);
            MainPage = new NavigationPage(page); ;
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

