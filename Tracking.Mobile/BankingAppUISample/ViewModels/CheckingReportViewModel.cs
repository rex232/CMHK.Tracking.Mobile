using System;
using System.Collections.ObjectModel;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Views;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class CheckingReportViewModel : ObservableObject
    {

        private INavigation _navigation;

        public ObservableCollection<CheckingReportModel> checkReportList { get; set; }
        public  Command CreateCommand { get; private set; }

        public CheckingReportViewModel(INavigation navitation)
        {
            _navigation = navitation;

            checkReportList = new ObservableCollection<CheckingReportModel>()
            {
                new CheckingReportModel { IsComplete = true, OrderNumber = "INB00001", Title = "招商暖邨001", Description = "入庫檢驗", OrderDate = "03/07/2022" , Pic1 = "Pic1", Pic2 = "Pic4", Pic3 = "Pic5", Pic4 = "Pic6", Pic5 = "Pic1", Pic6 = "attachment_black" },
                new CheckingReportModel { IsComplete = true, OrderNumber = "INB00002", Title = "招商暖邨002", Description = "入庫檢驗", OrderDate = "03/08/2022", Pic1 = "Pic2", Pic2 = "pic7", Pic3 = "pic8", Pic4 = "attachment_black", Pic5 = "attachment_black", Pic6 = "attachment_black" },
                new CheckingReportModel { IsComplete = false,  OrderNumber = "INB00003", Title = "招商暖邨003", Description = "入庫檢驗", OrderDate = "03/09/2022",  Pic1 = "attachment_black", Pic2 = "attachment_black", Pic3 = "attachment_black", Pic4 = "attachment_black", Pic5 = "attachment_black", Pic6 = "attachment_black" },


            };


            CreateCommand = new Command
            (t =>
            {
           
                // Navigation.Push
                Device.BeginInvokeOnMainThread(() => {
                    _navigation.PushModalAsync(NavigationPageHelper.Create(new CreateCheckingReport()), false);
                });
            });


        }
    }
}
