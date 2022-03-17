using System;
using System.Collections.ObjectModel;
using TrackingApp.APIService;
using TrackingApp.Helper;
using TrackingApp.Models;
using Xamarin.Essentials;

namespace TrackingApp.ViewModels
{
    public class InventoryViewModel
    {

        public ObservableCollection<InventoryModel> inventoryList { get; set; }

        public InventoryViewModel()
        {

            inventoryList = new ObservableCollection<InventoryModel>();            
            //{
            //    new InventoryModel { Picture = "Pic7", Name = "抗疫物資1", IsOnline = true , Detail="抗疫物資1", OnHandQty = 1800, Size="80x80x80", Volumne="0.3CBM"  },
            //    new InventoryModel { Picture = "Pic8", Name = "抗疫物資2", IsOnline = true, Detail="抗疫物資2抗疫物資1抗疫物資1抗疫物資1抗疫物資1", OnHandQty = 600, Size="100x200x100", Volumne="0.3CBM" },
            //    new InventoryModel { Picture = "Pic7", Name = "抗疫物資3", IsOnline = true, Detail="抗疫物資3", OnHandQty = 700, Size="100x200x100", Volumne="0.3CBM"  },

            //    new InventoryModel { Picture = "Pic8", Name = "抗疫物資4", IsOnline = true, Detail="抗疫物資4", OnHandQty = 1800, Size="15x15x2", Volumne="0.3CBM"  },

            //    new InventoryModel { Picture = "Pic7", Name = "抗疫物資5",  IsOnline = true, Detail="抗疫物資5", OnHandQty = 200, Size="100x200x100", Volumne="0.3CBM"  },
            //    new InventoryModel { Picture = "Pic7", Name = "抗疫物資6", IsOnline = true, Detail="抗疫物資6",OnHandQty = 1300, Size="100x200x100", Volumne="0.3CBM"  },

            //};

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Product_data data = new Product_data();
                ProductModel_result _rtn = await MainApiService.Instance.Inventory.Listing(data);

                if (_rtn.success)
                {
                    foreach (Product_data item in _rtn.data)
                    {
                        InventoryModel _tmp = new InventoryModel();
                        _tmp.Picture = $"{ GlobalSetting.CURRENT_BASE}{ item.image_path}";
                        _tmp.Detail = item.description;
                        _tmp.Name = item.product_no;
                        _tmp.IsOnline = true;
                        _tmp.OnHandQty = item.onhand_qty;
                        _tmp.Size = $"{ item.length}x{ item.width}x{ item.height}";
                        _tmp.Volumne = item.weight.ToString();

                        inventoryList.Add(_tmp);
                    }
                }
    
            });





        }
    }
}
