using System;
using System.Collections.Generic;

namespace TrackingApp.Models
{
    //API Request Models
    public class Base_request
    {

        public string appname { get; set; }
        public string usercode { get; set; }
        public string accesskey { get; set; }

    }

    //API return Models
    public class Base_result
    {
        public bool success { get; set; } = true;
        public int messagecode { get; set; }
        public string message { get; set; } = "";
        public List<Base_keyvalue> values { get; set; }

    }

    public class Base_keyvalue
    {
        public string key { get; set; }
        public string value { get; set; }

    }


}
