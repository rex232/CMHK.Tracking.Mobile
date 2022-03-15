using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TrackingApp.Views
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
