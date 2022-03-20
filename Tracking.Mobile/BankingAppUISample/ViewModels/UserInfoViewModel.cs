using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Resx; 
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class UserInfoViewModel : ObservableObject
    {

        private INavigation _navigation;

        public ObservableCollection<MenuModel> menuList { get; set; }
        public  Command BackCommand { get; private set; }

        private string _userName = GlobalVariable.Access_user;
        public string userName
        {
            get => _userName;
            set
            {
                _userName = value; 
            }
        }

        public UserInfoViewModel(INavigation navitation)
        {
            _navigation = navitation;

            //Define Memu
            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "user", MenuID = 1, MenuName =  AppResources.UserEmail, MenuData="email" }
            };

            BackCommand = new Command
            (t =>
            {
                if (GlobalVariable.isBusy)
                    return;

         
                // Navigation.Push
                Device.BeginInvokeOnMainThread(() => {
                    GlobalVariable.isBusy = true;
                    _navigation.PopModalAsync(false);
                    GlobalVariable.isBusy = false;
                });
            });


        }
    }
}
