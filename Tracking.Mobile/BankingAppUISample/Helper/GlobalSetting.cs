using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingApp.Helper
{
    public static class GlobalSetting
    {

        public static string CURRENT_APPNAME = "vehicle";
        public static string CURRENT_VERSION = "1.0";

        public static string CURRENT_UAT = "REVIEW";
        public static string CURRENT_API = "http://118.140.16.68:8080/vehicalapi/api";


        public static string CURRENT_DATE_FORMAT = "yyyy-MM-dd";
        public static string CURRENT_TIME_FORMAT = "HH:mm";


        public static string token = "";

        //Converter for API Response 
        public static class API_result
        {
            public static bool Yes { get { return true; } }
            public static bool No { get { return false; } }
        }

    }
}
