using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Resx;
using TrackingApp.Views;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class SelectionPageViewModel : ObservableObject
    {

        private INavigation _navigation;
        public ObservableCollection<MenuModel> menuList { get; set; }

        public Command UserInfoCommand { get; private set; }


        public SelectionPageViewModel(INavigation navigation, ObservableCollection<MenuModel> menuLst)
        {
            _navigation = navigation;

            menuList = menuLst;

        }

 
 


    }
}
