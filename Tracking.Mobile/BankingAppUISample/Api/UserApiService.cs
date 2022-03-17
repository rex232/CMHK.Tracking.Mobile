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
    class UserApiService : BaseApiService
    {
        //User Login
        async public Task<Auth_result> Login(Auth_data data)
        {
            string _api = "mobile/login";

            return await Call<Auth_request, Auth_data, Auth_result>(_api, data);
        }

    }
}
