using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    /// <summary>
    /// Модель представления несколькиз 5-дневных меню
    /// с использованием CarouselView.
    /// (Вариант 3)
    /// </summary>
    public class CurrentMenu3ViewModel
    {
        Page _page;
        CanteenDemoService _canteenService;

        private List<List<MenuOrder>> _currentList;
        public ObservableCollection<ObservableCollection<MenuOrder>> CurrentList { get; set; }
        public ICommand TapMenuCommand => new Command<MenuOrder>(async (param) =>
        {
            //wait _page.DisplayAlert("Alert", $"You Tap {param.DMenu.Comment}!", "Ok");
            await _page.Navigation.PushAsync(new DayMenu2Page(param.DMenu));
        });
        public ICommand TapOrderCommand => new Command<MenuOrder>(async (param) =>
        {
            string msg = "";
            if (param.DOrder == null)
            {
                msg = "Заказа нет.";
            }
            else
            {
                msg = "Заказ есть!";
            }
            await _page.DisplayAlert("Alert", $"You Tap {msg}!", "Ok");
            //await _page.Navigation.PushAsync(new CurrentMenuPage());
        });

        public CurrentMenu3ViewModel(Page page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            var list1 = _canteenService.GetMenuOrderListAsync();
            var list2 = _canteenService.GetMenuOrderListAsync();
            CurrentList = new ObservableCollection<ObservableCollection<MenuOrder>>();
            CurrentList.Add(new ObservableCollection<MenuOrder>(list1));
            CurrentList.Add(new ObservableCollection<MenuOrder>(list2));
        }
    }
}
