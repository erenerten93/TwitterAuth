using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows;

namespace tryout1
{
    public partial class MainPage : ContentPage
    {
      
          
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;




        }

     
        private void OnTwitsButtonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new TwitsPage());
        }
    }
}

