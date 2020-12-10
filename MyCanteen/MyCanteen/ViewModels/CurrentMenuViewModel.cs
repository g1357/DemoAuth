using MyCanteen.Models;
using MyCanteen.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления текущего пятидневного меню
    /// с использованием карусели по пятидневкам.
    /// </summary>
    public class CurrentMenuViewModel : BaseViewModel
    {
        // Страница данной модели представления
        Page _page;
        // Сервис
        CanteenDemoService _canteenService;

        /// <summary>
        /// Коллекция пятидневок с меню-заказами на неделю.
        /// </summary>
        public ObservableCollection<MenuOrderList> CurrentList { get; set; }

        /// <summary>
        /// Команда реагирование на нажание на меню
        /// </summary>
        public ICommand TapMenuCommand => new Command<MenuOrder>(async (param) =>
        {
            await _page.DisplayAlert("Alert", $"You Tap {param.DMenu.Comment}!", "Ok");
            //await _page.Navigation.PushAsync(new DayMenu2Page(param.DMenu));
        });

        /// <summary>
        /// Команда реагирования на нажатие на заказ
        /// </summary>
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

        /// <summary>
        /// Конструктор модели представления Текущего меню
        /// </summary>
        /// <param name="page">Связанная страница (представление)</param>
        public CurrentMenuViewModel(Page page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            var list1 = _canteenService.GetMenuOrderListAsync();
            var list2 = _canteenService.GetMenuOrderListAsync();
            CurrentList = new ObservableCollection<MenuOrderList>();
            CurrentList.Add(new MenuOrderList { WeekList = new ObservableCollection<MenuOrder>(list1) });
            CurrentList.Add(new MenuOrderList { WeekList = new ObservableCollection<MenuOrder>(list2) });
            CurrentList.Add(new MenuOrderList { WeekList = null });

        }
    }

    /// <summary>
    /// Список меню-заказон на пятидневки.
    /// Используется для отображения меню и заказов
    /// внутри карусели, которая отображает недели.
    /// </summary>
    public class MenuOrderList
    {
        /// <summary>
        /// Список недель с меню-заказамит
        /// </summary>
        public ObservableCollection<MenuOrder> WeekList { get; set; }
        
        /// <summary>
        /// Флаг: видно меню на неделю
        /// </summary>
        public bool MenuVisible => WeekList != null;

        /// <summary>
        /// Флаг: видно сообщение о том, что меню ещё не доступно
        /// </summary>
        public bool MsgVisible => WeekList == null;
    }

}
