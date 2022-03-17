using System;
namespace TrackingApp.Models
{ 
    public class Auth_data
    {
         
        public string username { get; set; }


        public string password { get; set; } 
    }

    public class Auth_request : Base_request
    {

        public Auth_data data { get; set; }

    }
    public class Auth_result : Base_result
    {
        public User_data data { get; set; }

        
    }


}
