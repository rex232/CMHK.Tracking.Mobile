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
        public ObservableCollection<OrderModel> orderList { get; set; }

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

            orderList = new ObservableCollection<OrderModel>
            {

                new OrderModel
                {
                    Picture="organize",
                    OrderType="入庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="IB00001",
                    OrderDate="03/11/2022",
                    OrderStatus="己完成"
                },
                new OrderModel
                {
                    Picture="organize",
                    OrderType="入庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="IB00002",
                    OrderDate="03/12/2022",
                      OrderStatus="己完成"

                },
                new OrderModel
                {
                    Picture="organize",
                    OrderType="入庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="IB00003",
                    OrderDate="03/12/2022",
                      OrderStatus="己完成"
                },
                new OrderModel
                {
                    Picture="organize",
                    OrderType="入庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="IB00004",
                    OrderDate="03/12/2022",
                     OrderStatus="己完成"
                },
                new OrderModel
                {
                    Picture="organize",
                    OrderType="入庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="IB00005",
                    OrderDate="03/13/2022",
                    OrderStatus="揀貨中"
                }
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
