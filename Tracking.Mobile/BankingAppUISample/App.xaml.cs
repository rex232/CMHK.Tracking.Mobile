using System;
using System.Globalization;
using System.Threading;
using TrackingApp.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Set Language
            string _currentLanguage = "";
            bool _hasKey = Preferences.ContainsKey("setting_language"); 
            if (_hasKey)
                _currentLanguage = Preferences.Get("setting_language", "");
            CultureInfo language = new CultureInfo(_currentLanguage);
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;


            MainPage = new Views.MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
