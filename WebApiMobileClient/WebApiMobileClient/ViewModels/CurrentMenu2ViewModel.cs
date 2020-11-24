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
    /// Модель представления текщего 5-днеыгного меню
    /// (Вариант 2)
    /// </summary>
    public class CurrentMenu2ViewModel : BaseViewModel
    {
        CurrentMenu2Page _page;
        CanteenDemoService _canteenService;

        private List<MenuOrder> _currentList;
        public ObservableCollection<MenuOrder> CurrentList { get; set; }

        private MenuOrder _selectedItem;

        public MenuOrder SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    _page.Navigation.PushAsync(new DayMenuPage(_selectedItem.DMenu));
                }
            }
        }
        public ICommand TapMenuCommand => new Command<MenuOrder>(async (param) =>
        {
            await _page.DisplayAlert("Alert", $"You Tap {param.DMenu.Comment}!", "Ok");
            //await _page.Navigation.PushAsync(new CurrentMenuPage());
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

        public CurrentMenu2ViewModel(CurrentMenu2Page page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            _currentList = _canteenService.GetMenuOrderListAsync();
            CurrentList = new ObservableCollection<MenuOrder>(_currentList);
        }

    }
}
