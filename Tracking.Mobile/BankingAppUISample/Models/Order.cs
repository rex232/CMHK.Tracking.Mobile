using System;
namespace TrackingApp.Models
{
    public class OrderModel
    {
        public string Picture               { get; set; }
        public string OrderType             { get; set; }
        public string OrderSupplierName     { get; set; }
        public string OrderNumber           { get; set; }    
        public string OrderDate             { get; set; } 
    }

    public class CheckingReportModel
    {
        public string OrderNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string OrderDate { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public string Pic6 { get; set; }
        public bool IsComplete { get; set; }
    }

}
