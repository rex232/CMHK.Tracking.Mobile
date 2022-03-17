using System;
using System.Collections.Generic;

namespace TrackingApp.Models
{
    public class TransactionPage_data
    {
  
        public long id { get; set; }

        public string order_no { get; set; }

        public string product_no { get; set; }

        public string working_date { get; set; }

        public string supplier_id { get; set; }

        public string order_type { get; set; }

        public string remark { get; set; }

        public int qty_box { get; set; }

        public int qty { get; set; }

        public string transaction_status { get; set; }
        public string create_date { get; set; }

        public string image_path { get; set; }
     

        public string description { get; set; }


    }
    public class TransactionPageModel_request : Base_request
    {
        public long id { get; set; }
    }

    public class TransactionPageModel_result : Base_result
    {
        public List<TransactionPage_data> data { get; set; }
    }

}
