﻿using System;
using System.Collections.ObjectModel;
using TrackingApp.APIService;
using TrackingApp.Helper;
using TrackingApp.Models;
using TrackingApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class StockInOrderListPageViewModel
    {

        private INavigation _navigation;

        public ObservableCollection<MenuModel> menuList { get; set; }
        public ObservableCollection<OrderDetailModel> orderList { get; set; }

        public Command BackCommand { get; private set; }

        public StockInOrderListPageViewModel(INavigation navitation)
        {
            _navigation = navitation;



            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "organize", MenuName = "IB00001", MenuData= "03/01/2022" },
                new MenuModel { Picture = "organize", MenuName = "IB00002", MenuData= "03/03/2022"  },
                new MenuModel { Picture = "organize", MenuName = "IB00003", MenuData= "03/04/2022"  },
                new MenuModel { Picture = "organize", MenuName = "IB00004", MenuData= "03/06/2022"  }
            };

            orderList = new ObservableCollection<OrderDetailModel>();

            //Get order data
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                TransactionPage_data data = new TransactionPage_data();
                TransactionPageModel_result _rtn = await MainApiService.Instance.Transaction.StockInListing(data);

                if (_rtn.success)
                {
                    if (_rtn.data == null)
                        return;

                    foreach (TransactionPage_data item in _rtn.data)
                    {
                        OrderDetailModel _tmp = new OrderDetailModel();
                        // _tmp.Picture = $"{ GlobalSetting.CURRENT_BASE}{ item.image_path}";
                        _tmp.OrderType = item.order_type;
                        _tmp.OrderSupplierName = item.supplier_id;
                        //  _tmp.OrderInfo = item.description;
                        _tmp.OrderNumber = item.order_no;
                        _tmp.OrderDate = item.working_date;
                        _tmp.OrderStatus = item.transaction_status;
                        _tmp.BoxQty = item.qty_box;
                        _tmp.Qty = item.qty;
                        _tmp.Picture = (_tmp.OrderType == "入庫") ? "organize" : "outbox";
                        orderList.Add(_tmp);
                    }
                }

            });

 

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
