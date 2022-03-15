using System;
using System.Collections.ObjectModel;
using TrackingApp.Models;

namespace TrackingApp.ViewModels
{
    public class LandingViewModel
    {
        public ObservableCollection<Cards> cards { get; set; }
        public ObservableCollection<OrderModel> orderList { get; set; }

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

            orderList = new ObservableCollection<OrderModel>
            {

                new OrderModel
                {
                    Picture="outbox",
                    OrderType="出庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="OUT00001",
                    OrderDate="03/11/2022"
                },
                new OrderModel
                {
                    Picture="outbox",
                    OrderType="出庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="OUT00002",
                    OrderDate="03/12/2022"
                },
                new OrderModel
                {
                    Picture="outbox",
                    OrderType="出庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="OUT00003",
                    OrderDate="03/12/2022"
                },
                new OrderModel
                {
                    Picture="outbox",
                    OrderType="出庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="OUT00004",
                    OrderDate="03/12/2022"
                },
                new OrderModel
                {
                    Picture="organize",
                    OrderType="入庫",
                    OrderSupplierName="招商船企",
                    OrderNumber="INB00001",
                    OrderDate="03/13/2022"
                }
            };
        }
    }
}
