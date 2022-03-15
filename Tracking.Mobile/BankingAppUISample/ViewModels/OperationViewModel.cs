using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Views;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class OperationViewModel
    {

        private INavigation _navigation;

 
        public Command StockInCommand { get; private set; }
        public Command StockOutCommand { get; private set; }
        public Command OrderListCommand { get; private set; }

        public OperationViewModel(INavigation navitation)
        {
            _navigation = navitation; 

            StockInCommand = new Command
            (t =>
            {  
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new OrderListPage()), false);
                });
            });

            StockOutCommand = new Command
            (t =>
            {  
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new OrderListPage()), false);
                });
            });

            OrderListCommand = new Command
            (t =>
            {  
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new OrderListPage()), false);
                });
            });

        }
    }
}
