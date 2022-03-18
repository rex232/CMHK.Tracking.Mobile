using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models;

namespace TrackingApp.APIService
{
    class TransactionApiService : BaseApiService
    {
        //Get Transaction - All
        async public Task<TransactionPageModel_result> Listing(TransactionPage_data data)
        {
            string _api = "mobile/transaction";

            return await Call<TransactionPageModel_request, TransactionPage_data, TransactionPageModel_result>(_api, data);
        }

        //Get Transaction - Latest 10
        async public Task<TransactionPageModel_result> Latest(TransactionPage_data data)
        {
            string _api = "mobile/transaction/latest";

            return await Call<TransactionPageModel_request, TransactionPage_data, TransactionPageModel_result>(_api, data);
        }

        //Get Transaction - Stock In
        async public Task<TransactionPageModel_result> StockInListing(TransactionPage_data data)
        {
            string _api = "mobile/transaction/stockin";

            return await Call<TransactionPageModel_request, TransactionPage_data, TransactionPageModel_result>(_api, data);
        }

        //Get Transaction - Stock Out
        async public Task<TransactionPageModel_result> StockOutListing(TransactionPage_data data)
        {
            string _api = "mobile/transaction/stockout";

            return await Call<TransactionPageModel_request, TransactionPage_data, TransactionPageModel_result>(_api, data);
        }


    }
}
