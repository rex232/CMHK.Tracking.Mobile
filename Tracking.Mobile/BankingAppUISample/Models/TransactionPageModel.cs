using System;
using System.Collections.Generic;

namespace TrackingApp.Models
{
 
    public class Transaction_data
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


    }
    public class TransactionModel_request : Base_request
    {
        public long id { get; set; }
    }

    public class TransactionModel_result : Base_result
    {
        public List<Transaction_data> data { get; set; }
    }

}
