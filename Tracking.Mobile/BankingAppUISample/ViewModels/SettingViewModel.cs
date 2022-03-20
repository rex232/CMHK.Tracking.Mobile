using AiForms.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using TrackingApp.Controls;
using TrackingApp.Extension;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Resx;
using TrackingApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class SettingViewModel : ObservableObject
    {

        private INavigation _navigation;
        public ObservableCollection<MenuModel> menuList { get; set; }

        public Command UserInfoCommand { get; private set; }
        public Command DataSyncCommand { get; private set; }
        public Command SettingCommand { get; private set; }
        public Command MenuCommand { get; private set; } 

        public SettingViewModel(INavigation navigation)
        {
            _navigation = navigation;

            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "window", MenuID = 1, MenuName =  AppResources.SettingChangeLanguage },
                new MenuModel { Picture = "globe2",  MenuID = 2, MenuName = AppResources.SettingAppUpdate },
                new MenuModel { Picture = "user",  MenuID = 3, MenuName = AppResources.SettingLogout }
            };

            UserInfoCommand = new Command
            (t =>
            { 
                // Navigation.Push
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new UserInfoPage()), false);
                });
            });

            MenuCommand = new Command<MenuModel>(async (key) => {

                try
                {
                    switch (key.MenuID)
                    {
                        case 1:
                            ChangeLanguage();
                            break;
                        case 2:
                            Autoupdate();
                            break;
                        case 3:
                            Logout();
                            break;
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                } 

            });

 



        }

        public async void ChangeLanguage()
        {

            ObservableCollection<MenuModel> languageMenu;

            languageMenu = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "window", MenuID = 1, MenuName = AppResources.LanguageChinese },
                new MenuModel { Picture = "window", MenuID = 2,  MenuName = AppResources.LanguageChineseGB }
            };

            MenuModel _menu = await _navigation.GetResultFromModalPage<MenuModel>(new SelectionPage(languageMenu) );
       //     


            try
            {
                switch (_menu.MenuID)
                {
                    case 1:
                        SetLanguage("");
                        break;
                    case 2:
                        SetLanguage("zh-Hans");
                        break; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void SetLanguage(string lang)
        {
             
            //Set Language
            CultureInfo language = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;

            Preferences.Set("setting_language", lang);

            Toast.Instance.Show<QAToastView>(new { Title = AppResources.messageChangeLanguage, Duration = 2500 });
        }

        private void OnStoreSelected(object sender, ItemTappedEventArgs e)
        {
            ((ContentPage)sender).Navigation.PopModalAsync();
            var selectedStore = e.Item as MenuModel;
            //Address.Store = selectedStore;
 
        }


        public async void Autoupdate()
        {
            // GlobalVariable.Access_token = "";
            // await _navigation.PushModalAsync(new LoginPage(), false);
           // Toast.Instance.Show<QAToastView>(new { Title = AppResources.messageChangeLanguage, Duration = 2500 });
        }

        public async void Logout()
        {
            GlobalVariable.Access_token = ""; 
            await _navigation.PushModalAsync(new LoginPage(), false);
 
        }


    }
}
