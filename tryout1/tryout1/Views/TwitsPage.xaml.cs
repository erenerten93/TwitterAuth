using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryout1
{	
	public partial class TwitsPage : ContentPage
	{

   
        public TwitsPage ()
		{
			InitializeComponent ();
			BindingContext = new TwitsPageViewModel();
        }

        private async void OnBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

