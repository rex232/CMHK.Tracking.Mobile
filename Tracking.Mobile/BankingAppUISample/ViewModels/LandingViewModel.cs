using System;
using System.Collections.ObjectModel;
using TrackingApp.APIService;
using TrackingApp.Helper;
using TrackingApp.Models;
using Xamarin.Essentials;
using System.Linq;

namespace TrackingApp.ViewModels
{
    public class LandingViewModel
    {
        public ObservableCollection<Cards> cards { get; set; }
        public ObservableCollection<OrderDetailModel> orderList { get; set; }

        public LandingViewModel()
        {
            cards = new ObservableCollection<Cards>
            {
                new Cards
                {
                    CardImage="pic1",
                    CardBussinessCategory ="BUSINESS CARD",
                    CardNumber="4565",
                    CardType="Mastercard",
                    CardExpirationDate="05/20"
                },
                new Cards
                {
                    CardImage="pic2",
                    CardBussinessCategory ="PERSONAL CARD",
                    CardNumber="5664",
                    CardType="VISA",
                    CardExpirationDate="04/21"
                },
                new Cards
                {
                    CardImage="pic3",
                    CardBussinessCategory ="BUSINESS CARD",
                    CardNumber="4445",
                    CardType="Mastercard",
                    CardExpirationDate="05/22"
                }
            };

            orderList = new ObservableCollection<OrderDetailModel>();



            //Get order data
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                TransactionPage_data data = new TransactionPage_data();
                TransactionPageModel_result _rtn = await MainApiService.Instance.Transaction.Latest(data);

                if (_rtn.success)
                {
                    if (_rtn.data == null)
                        return;

                    foreach (TransactionPage_data item in _rtn.data)
                    {
                        OrderDetailModel _tmp = new OrderDetailModel();
                       // _tmp.Picture = $"{ GlobalSetting.CURRENT_BASE}{ item.image_path}";
                        _tmp.OrderType = item.order_type;
                        _tmp.OrderSupplierName = "招商暖邨";
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



        }
    }
}
