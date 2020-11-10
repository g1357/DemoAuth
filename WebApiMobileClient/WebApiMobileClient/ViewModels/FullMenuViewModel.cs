using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    class FullMenuViewModel : BaseViewModel
    {
        FullMenuPage _page;
        CanteenDemoService _canteenService;

        public ObservableCollection<Dish> Items { get; set; }
        public FullMenuViewModel(FullMenuPage page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            Items = new ObservableCollection<Dish>(_canteenService.GetFullMenuAsync());
        }   
    }
}
