using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Resx;
using TrackingApp.Views;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class CreateCheckingReportViewModel : ObservableObject
    {

        private INavigation _navigation;

        public ObservableCollection<CheckingReportModel> checkReportList { get; set; } 
        public ObservableCollection<MenuModel> menuList { get; set; }

        public Command BackCommand { get; private set; }

        public CreateCheckingReportViewModel(INavigation navigation)
        {
            _navigation = navigation;

            checkReportList = new ObservableCollection<CheckingReportModel>()
            {
                new CheckingReportModel { IsComplete = true, OrderNumber = "INB00001", Title = "招商暖邨001", Description = "入庫檢驗", OrderDate = "03/07/2022" , Pic1 = "Pic1", Pic2 = "Pic1", Pic3 = "Pic1", Pic4 = "Pic1", Pic5 = "Pic1", Pic6 = "attachment_black" },
                new CheckingReportModel { IsComplete = true, OrderNumber = "INB00002", Title = "招商暖邨002", Description = "入庫檢驗", OrderDate = "03/08/2022", Pic1 = "Pic2", Pic2 = "attachment_black", Pic3 = "attachment_black", Pic4 = "attachment_black", Pic5 = "attachment_black", Pic6 = "attachment_black" },
                new CheckingReportModel { IsComplete = false,  OrderNumber = "INB00003", Title = "招商暖邨003", Description = "入庫檢驗", OrderDate = "03/09/2022",  Pic1 = "attachment_black", Pic2 = "attachment_black", Pic3 = "attachment_black", Pic4 = "attachment_black", Pic5 = "attachment_black", Pic6 = "attachment_black" },


            };


            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "window", MenuName = AppResources.CheckReportDate, MenuData= DateTime.Now.ToShortDateString() },
                new MenuModel { Picture = "window", MenuName = AppResources.CheckReportSupplier },
                new MenuModel { Picture = "window", MenuName = AppResources.CheckReportTruckNo },
                new MenuModel { Picture = "window", MenuName = AppResources.CheckReportDriver }
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
