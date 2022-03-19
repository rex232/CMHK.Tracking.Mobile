using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Resx;
using TrackingApp.Views;
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

        public SettingViewModel()
        {

            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "window", MenuName =  AppResources.SettingChangeLanguage },
                new MenuModel { Picture = "globe2", MenuName = AppResources.SettingAppUpdate },
                new MenuModel { Picture = "user", MenuName = AppResources.SettingLogout }
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

                MenuModel _rec = (MenuModel)key;
                // Navigation.Push
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new UserInfoPage()), false);
                });
            });

 



        }
    }
}
