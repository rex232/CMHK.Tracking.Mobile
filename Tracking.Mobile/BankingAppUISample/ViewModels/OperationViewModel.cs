using AiForms.Dialogs;
using System;
using System.Collections.ObjectModel;
using TrackingApp.Controls;
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
                if (GlobalVariable.Access_level >= 2)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _navigation.PushModalAsync(NavigationPageHelper.Create(new OrderListPage()), false);
                    });
                } else
                {
                    Toast.Instance.Show<QAToastView>(new { Title = "抱歉，您沒有訪問權限", Duration = 2500 });
                    return;
                }
            });

            StockOutCommand = new Command
            (t =>
            {
                if (GlobalVariable.Access_level >= 2) { 
                    Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new OrderListPage()), false);
                    });
                } else
                {
                    Toast.Instance.Show<QAToastView>(new { Title = "抱歉，您沒有訪問權限", Duration = 2500 });
                    return;
                }
        });

            OrderListCommand = new Command
            (t =>
            {
                if (GlobalVariable.Access_level >= 2) { 
                    Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new OrderListPage()), false);
                    });
                }
                else
                {
                    Toast.Instance.Show<QAToastView>(new { Title = "抱歉，您沒有訪問權限", Duration = 2500 });
                    return;
                }
            });

        }
    }
}
