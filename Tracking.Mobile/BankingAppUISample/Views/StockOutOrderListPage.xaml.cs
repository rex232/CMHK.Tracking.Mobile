﻿using System;
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
    public partial class StockOutOrderListPage : ContentPage
    {
        public StockOutOrderListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new StockOutOrderListPageViewModel(this.Navigation);
        }
    }
}