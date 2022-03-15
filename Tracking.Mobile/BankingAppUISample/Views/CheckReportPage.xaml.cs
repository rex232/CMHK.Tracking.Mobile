using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckReportPage : ContentPage
    {
        public CheckReportPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
             
            BindingContext = new CheckingReportViewModel(this.Navigation);
        }
    }
}