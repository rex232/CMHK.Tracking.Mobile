using System;
using System.Collections.Generic;
using System.Text;


namespace TrackingApp.APIService
{
    class MainApiService : BaseApiService
    {
        static MainApiService _instance;
        public UserApiService User;
        public InventoryApiService Inventory;
        public TransactionApiService Transaction;

        public MainApiService()
        {
            User = new UserApiService();
            Inventory = new InventoryApiService();
            Transaction = new TransactionApiService();
        }

        public static MainApiService Instance
        {
            get
            {
                return _instance ?? (_instance = new MainApiService());
            }
        }

    }
}
