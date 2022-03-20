using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrackingApp.Models;
using TrackingApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml; 

namespace TrackingApp.Views
{

    public partial class SelectionPage : AwaitableContentPage<MenuModel>
    {
        public SelectionPage(ObservableCollection<MenuModel> menuList)
        {
            InitializeComponent(); 

            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = new SelectionPageViewModel(base.Navigation, menuList);
        }

        public async void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var _menu = e.Item as MenuModel;

            base.PageResult = _menu; // object you created previously
            await base.Navigation.PopModalAsync(false);

        }

    }
}