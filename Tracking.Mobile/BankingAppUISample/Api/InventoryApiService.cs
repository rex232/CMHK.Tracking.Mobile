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
    class InventoryApiService : BaseApiService
    {
        //Get Inventory
        async public Task<ProductModel_result> Listing(Product_data data)
        {
            string _api = "mobile/inventory";

            return await Call<ProductModel_request, Product_data, ProductModel_result>(_api, data);
        }

    }
}
