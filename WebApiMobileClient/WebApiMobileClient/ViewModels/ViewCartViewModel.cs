using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    public class ViewCartViewModel : BaseViewModel
    {
        Page _page;
        CanteenDemoService _canteenService;

        DateTime _date;

        private Order _cartOder;
        public Order CartOrder
        {
            get => _cartOder;
            set => SetProperty(ref _cartOder, value);
        }

        public ObservableCollection<Dish> DishList { get; set; }

        public ViewCartViewModel(Page page, DayMenu dayMenu)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            _date = dayMenu.Date.Date;
            CartOrder = _canteenService.GetOrderAsync(_date);
            DishList = new ObservableCollection<Dish>(CartOrder.Dishes);
        }
    }
}
