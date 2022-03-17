using System;
using System.Collections.Generic;

namespace TrackingApp.Models
{
    public class InventoryModel
    {
        public string Picture { get; set; }
        public string RefNo { get; set; }
        public string Name { get; set; } 
        public bool IsOnline { get; set; }
        public string Detail { get; set; }
        public string Size { get; set; }
        public string Volumne { get; set; }
        public int OnHandQty { get; set; } 

    }

    public class Product_data
    { 
        public long product_id { get; set; }

        public string product_no { get; set; }

        public string description { get; set; }

        public string image_path { get; set; }

        public string image_thumbnail_path { get; set; }

        public double box_length { get; set; }

        public double box_width { get; set; }

        public double box_height { get; set; }

        public double box_volume { get; set; }

        public double box_weight { get; set; }

        public string barcode { get; set; }


        public string serial_no { get; set; }

        public string product_type { get; set; }

        public int unit_qty { get; set; }

        public string unit { get; set; }

        public int uom_qty { get; set; }

        public string uom_unit { get; set; }

        public string remark { get; set; }


        public double length { get; set; }

        public double width { get; set; }

        public double height { get; set; }

        public double weight { get; set; }
        public double volume { get; set; }
        public int onhand_qty_box { get; set; }
        public int onhand_qty { get; set; }
        public string create_date { get; set; }

        public string last_transaction_date { get; set; }


    }
   
    public class ProductModel_request : Base_request
    {
        public long product_id { get; set; }
        public Product_data data { get; set; }
    }

    public class ProductModel_result : Base_result
    {
        public List<Product_data> data { get; set; }
    }

}
