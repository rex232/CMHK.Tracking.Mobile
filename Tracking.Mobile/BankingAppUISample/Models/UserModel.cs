using System; 

namespace TrackingApp.Models
{
 
    public class User_data
    { 
        public long user_id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email_address { get; set; }

        public string company { get; set; }

        public string user_type { get; set; }

        public string user_level { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string img_path { get; set; }

        public DateTime last_update_date { get; set; }

        public string last_update_by_user{ get; set; }
    }


}
