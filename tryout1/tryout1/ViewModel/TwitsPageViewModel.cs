using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Input;
using tryout1.Models;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace tryout1
{
    public class TwitsPageViewModel
    {

        public List<Tweet> Tweets { get; set; }

        public TwitsPageViewModel()
        {
            Tweets = new List<Tweet>
            {
            new Tweet { Username = "Eren Erten", Text = "This is a sample tweet!" },
            new Tweet { Username = "Eren Erten", Text = "Hello  DSwiss!!" },
            new Tweet { Username = "Eren Erten", Text = "Let's  Twit!" },

        };
        }

    }
}

