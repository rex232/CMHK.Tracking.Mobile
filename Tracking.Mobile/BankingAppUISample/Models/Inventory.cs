using System;
namespace TrackingApp.Models
{
    public class InventoryModel
    {
        public string Picture { get; set; }
        public string Name { get; set; } 
        public bool IsOnline { get; set; }
        public string Detail { get; set; }
        public string Size { get; set; }
        public string Volumne { get; set; }
        public int OnHandQty { get; set; } 

    }
}
