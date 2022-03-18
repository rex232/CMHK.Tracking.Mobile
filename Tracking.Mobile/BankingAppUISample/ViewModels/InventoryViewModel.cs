using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrackingApp.APIService;
using TrackingApp.Helper;
using TrackingApp.Models;
using Xamarin.Essentials;

namespace TrackingApp.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {

        public ObservableCollection<InventoryModel> inventoryList { get; set; }
 

        private int _onhandqty;
        public int onHandQty
        {
            get => _onhandqty;
            set
            {
                _onhandqty = value;
            }
        }

        private string _searchKey;
        public string searchKey
        {
            get => _searchKey;
            set
            {
                _searchKey = value;
                LoadData();
            }
        }

        

        public InventoryViewModel()
        {

  

            //Get inventory data
            LoadData();
              
        }

        //Get inventory data
        public void LoadData()
        {

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                inventoryList = new ObservableCollection<InventoryModel>();
                onHandQty = 0;

                Product_data data = new Product_data();
                ProductModel_result _rtn = await MainApiService.Instance.Inventory.Listing(data);
                List<Product_data> _lst = new List<Product_data>();


                if (_rtn.success)
                {
                    if (!string.IsNullOrEmpty(_searchKey))
                    {
                        Console.WriteLine(_searchKey);
                        _lst = _rtn.data.Where(x => x.description.ToLower().Contains(_searchKey.ToLower()) || x.product_no.ToLower().Contains(_searchKey.ToLower())).ToList();
                    }
                    else
                    {
                        _lst = _rtn.data;
                    }

                    foreach (Product_data item in _lst)
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
                        _onhandqty += _tmp.OnHandQty;
                    }
                }

                NotifyPropertyChanged(nameof(onHandQty));
                NotifyPropertyChanged(nameof(inventoryList));
            });


        }

    }
}
