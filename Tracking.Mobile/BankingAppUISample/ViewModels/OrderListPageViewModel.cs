using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Views;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class OrderListPageViewModel
    {

        private INavigation _navigation;

        public ObservableCollection<MenuModel> menuList { get; set; }

        public Command BackCommand { get; private set; }

        public OrderListPageViewModel(INavigation navitation)
        {
            _navigation = navitation;



            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "organize", MenuName = "IB00001", MenuData= "03/01/2022" },
                new MenuModel { Picture = "organize", MenuName = "IB00002", MenuData= "03/03/2022"  },
                new MenuModel { Picture = "organize", MenuName = "IB00003", MenuData= "03/04/2022"  },
                new MenuModel { Picture = "organize", MenuName = "IB00004", MenuData= "03/06/2022"  }
            };



            BackCommand = new Command
            (t =>
            {
           
                // Navigation.Push
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PopModalAsync(false);
                });
            });


        }
    }
}
