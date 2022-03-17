using System;
using System.Text;
using Newtonsoft.Json;
using Polly;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using TrackingApp.Helper;

namespace TrackingApp.APIService
{

    public class BaseApiService
    {
        public const int API_RETRY_COUNT = 3;      //Retry Count
        public const int API_BREAKER_COUNT = 2;    //Circuit Breaker Count
        private string urlbase = GlobalSetting.CURRENT_API;


        public string createapiurl(string func, string parm = "")
        {

            //Public IP  
            string _serverpath = urlbase;


            if (string.IsNullOrEmpty(parm))
            {
                return string.Format("{0}/{1}", _serverpath, func);
            }
            else
            {
                return string.Format("{0}/{1}?{2}", _serverpath, func, parm);
            }

        }

        public bool IsConnectedNetwork()
        {
            //Use Xamarin.Essentials
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.None)
            {
                return false;
            }

            return true;
        }


        //Get General Data
        async public Task<O> Call<R, D, O>(string apipath, D data)
        {

            O msg = default(O);
            msg = Activator.CreateInstance<O>();


            if (!IsConnectedNetwork())
            {

                PropertyInfo success = msg.GetType().GetProperty("success");
                success.SetValue(msg, GlobalSetting.API_result.No);

                PropertyInfo messagecode = msg.GetType().GetProperty("messagecode");
                messagecode.SetValue(msg, 1001);

                PropertyInfo message = msg.GetType().GetProperty("message");
                message.SetValue(msg, "Cant connect Network");

                return msg;

            }


            string url = createapiurl(apipath);


            R _req = default(R);
            _req = Activator.CreateInstance<R>();

            PropertyInfo appname1 = _req.GetType().GetProperty("appname");
            appname1.SetValue(_req, GlobalSetting.CURRENT_APPNAME);

            PropertyInfo usercode = _req.GetType().GetProperty("usercode");
            usercode.SetValue(_req, "XXX");

            PropertyInfo accesskey = _req.GetType().GetProperty("accesskey");
            accesskey.SetValue(_req, "XXX");

            PropertyInfo da = _req.GetType().GetProperty("data");
            da.SetValue(_req, data);

            string jsonrequest = JsonConvert.SerializeObject(_req);

            var content = new StringContent(jsonrequest, Encoding.UTF8, "text/json");

            var retryPolicy = Policy
                // Don't retry if circuit breaker has broken the circuit
                .Handle<Exception>()
                .WaitAndRetryAsync(API_RETRY_COUNT, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(API_BREAKER_COUNT, TimeSpan.FromSeconds(2),      // onBreak
                                     (exception, delay) => {
                                         PropertyInfo messagecode = msg.GetType().GetProperty("messagecode");
                                         messagecode.SetValue(msg, exception.Message);
                                     },
                                     () => Debug.WriteLine($"Call ok - closing the circuit again."),
                                     () => Debug.WriteLine($"Circuit is half-open. The next call is a trial."));

            try
            {
                var result = await Policy.WrapAsync(retryPolicy, circuitBreakerPolicy)
                                        .ExecuteAsync(async () => await RestClient.GetClientInstance().PostAsync(url, content));

                //    var result = await Policy.Handle<Exception>()
                //          .WaitAndRetryAsync(API_RETRY_COUNT, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                //          .ExecuteAsync(async () => await RestClient.GetClientInstance().PostAsync(url, content));

                //var result = await RestClient.GetClientInstance().PostAsync(url, content);

                if (result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;
                    if (json == "null")
                    {
                        PropertyInfo success = msg.GetType().GetProperty("success");
                        success.SetValue(msg, GlobalSetting.API_result.No);
                        PropertyInfo message = msg.GetType().GetProperty("message");
                        message.SetValue(msg, "NULL");
                        return msg;
                    }

                    msg = JsonConvert.DeserializeObject<O>(json);

                    return msg;
                }
                else
                {
                    //Console.WriteLine(result.StatusCode);
                    var json = result.Content.ReadAsStringAsync().Result;
                    // Console.WriteLine(json);

                    //Assign value - Error 
                    PropertyInfo success = msg.GetType().GetProperty("success");
                    success.SetValue(msg, GlobalSetting.API_result.No);

                    if (json == "null")
                    {
                        PropertyInfo message = msg.GetType().GetProperty("message");
                        message.SetValue(msg, "NULL");
                        return msg;
                    }

                    if (string.IsNullOrEmpty(json.ToString()))
                    {
                        PropertyInfo message = msg.GetType().GetProperty("message");
                        message.SetValue(msg, result.StatusCode);
                        return msg;
                    }


                    msg = JsonConvert.DeserializeObject<O>(json);

                    return msg;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);


                PropertyInfo success = msg.GetType().GetProperty("success");
                success.SetValue(msg, GlobalSetting.API_result.No);

                PropertyInfo messagecode = msg.GetType().GetProperty("messagecode");
                messagecode.SetValue(msg, 1002);

                PropertyInfo message = msg.GetType().GetProperty("message");
                message.SetValue(msg, "API Error");
                return msg;
            }





        }


    }

    //HttpClient Insstance
    public class RestClient
    {
        private static HttpClient _client;

        public static HttpClient GetClientInstance()
        {
            if (_client == null)
            {
                var handler = new HttpClientHandler();

                //Enable Decompresssion if need
                //if (handler.SupportsAutomaticDecompression)
                //{
                //    handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;
                //  //handler.AutomaticDecompression = DecompressionMethods.GZip |
                //  //  DecompressionMethods.Deflate;
                //}

                _client = new HttpClient(handler)
                {
                    //BaseAddress = new Uri(GlobalSetting.CURRENT_API)
                };
            }

            return _client;
        }
    }

}
