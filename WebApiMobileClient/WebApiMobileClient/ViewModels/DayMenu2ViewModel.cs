using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WebApiMobileClient.Helpers;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    public class DayMenu2ViewModel : BaseViewModel
    {
        DayMenu2Page _page;
        CanteenDemoService _canteenService;

        private DayMenu _dayMenu;

        public DayMenu DayMenu
        {
            get { return _dayMenu; }
            set { SetProperty(ref _dayMenu, value); }
        }

        public ObservableCollection<Grouping<string, Dish>> ItemsGrouped { get; set; }

        public ICommand OrderDishCommand => new Command<Dish>(async (param) =>
        {
            // Добавить блюдо в заказ
            _canteenService.AddDistToOrderAsync(DayMenu, param);
            await _page.DisplayAlert("Alert", $"Блюдо {param.Name} добавлено в заказ!", "Ok");
        });

        public DayMenu2ViewModel(DayMenu2Page page, DayMenu dayMenu)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            DayMenu = dayMenu;
            var dList = DayMenu.Dishes;
            var sorted = from item in dList
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
        }
    }
}
