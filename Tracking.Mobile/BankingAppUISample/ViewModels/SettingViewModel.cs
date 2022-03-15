using System;
using System.Collections.ObjectModel;
using TrackingApp.Models;

namespace TrackingApp.ViewModels
{
    public class SettingViewModel
    {

        public ObservableCollection<MenuModel> menuList { get; set; }

        public SettingViewModel()
        {

            menuList = new ObservableCollection<MenuModel>()
            {
                new MenuModel { Picture = "window", MenuName = "語言" },
                new MenuModel { Picture = "globe2", MenuName = "版本更新" },
                new MenuModel { Picture = "user", MenuName = "退出登錄" }
            };

        }
    }
}
