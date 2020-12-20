using MyCanteen.Helpers;
using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    public class DayMenuViewModel : BaseViewModel
    {
        // Представление (для использование сервиса навигации)
        DayMenuPage _page;
        // Сервис столовой
        CanteenDemoService _canteenService;
        // Дневное меню
        DayMenu _dayMenu;
        public DayMenu DayMenu
        {
            get => _dayMenu;
            set => SetProperty(ref _dayMenu, value);
        }

        private int _dishQty;
        // Количество блюдв корзине
        public int DishQty
        {
            get => _dishQty;
            set => SetProperty(ref _dishQty, value);
        }

        public ObservableCollection<Grouping<string, Dish>> ItemsGrouped { get; set; }

        public ICommand OrderDishCommand => new Command<Dish>(async (param) =>
        {
            // Добавить блюдо в заказ
            //_canteenService.AddDistToOrderAsync(DayMenu, param);
            DishQty++;
            await _page.DisplayAlert("Alert", $"Блюдо {param.Name} добавлено в заказ!", "Ok");
        });
        public ICommand OpenCartCommand => new Command(async () =>
        {
            // Открыть страницу с корзиной заказа
            //var page = new ViewCartPage();
            //var vm = new ViewCartViewModel(page, _dayMenu);
            //page.BindingContext = vm;
            //await _page.Navigation.PushAsync(page);
            await _page.DisplayAlert("Alert", $"Открыть карзину!", "Ok");
        });

        public DayMenuViewModel(DayMenuPage page, DayMenu dayMenu)
        {
            _page = page;
            DayMenu = dayMenu;

            _canteenService = DependencyService.Get<CanteenDemoService>();
            DishQty = 0;
            var dList = DayMenu.Dishes;
            var sorted = from item in dList
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
        }
    }
}
