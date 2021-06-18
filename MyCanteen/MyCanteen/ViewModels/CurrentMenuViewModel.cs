using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Services.Interfaces;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
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
        ICanteenService _canteenService;

        /// <summary>
        /// Коллекция пятидневок с меню-заказами на неделю.
        /// </summary>
        public ObservableCollection<MenuOrderList> CurrentList { get; set; }

        /// <summary>
        /// Команда реагирование на нажание на меню
        /// </summary>
        public ICommand TapMenuCommand => new Command<MenuOrder>(async (param) =>
        {
            //await _page.DisplayAlert("Alert", $"You Tap {param.DMenu.Comment}!", "Ok");
            await _page.Navigation.PushAsync(new DayMenuPage(param.DMenu));
        });

        /// <summary>
        /// Команда реагирования на нажатие на заказ
        /// </summary>
        public ICommand TapOrderCommand => new Command<MenuOrder>(async (param) =>
        {
            if (param.DOrder.Status == OrderStatus.NotDefined)
            {
                await _page.DisplayAlert("Заказза НЕТ!", 
                    "Для создания заказа нажмите на меню соответсвующего дня слева!",
                    "Ok");
            }
            else
            {
                await _page.Navigation.PushAsync(new OrderPage(param.DOrder));
            }
        });
        public ICommand LoadItemsCommand => new Command(async () => 
            await ExecuteLoadItemsCommand()
        );

        bool _refreshOrders;

        /// <summary>
        /// Конструктор модели представления Текущего меню
        /// </summary>
        /// <param name="page">Связанная страница (представление)</param>
        public CurrentMenuViewModel(Page page)
        {
            _page = page;
            _canteenService = DependencyService.Get<ICanteenService>();

            _refreshOrders = false;
            MessagingCenter.Subscribe<DayMenuViewModel, DateTime>(
                this, "Refresh Order",
                async (sender, arg) =>
                {
                    _refreshOrders = true;
                    //await _page.DisplayAlert("Message received", "arg=" + arg, "OK");
                }
            );
            MessagingCenter.Subscribe<SettingsViewModel>(
                this, "Refresh Order",
                async (sender) =>
                {
                    _refreshOrders = true;
                    //await _page.DisplayAlert("Message received", "From Settings Page", "OK");
                }
            );

            CurrentList = new ObservableCollection<MenuOrderList>();
            ExecuteLoadItemsCommand().Wait();
        }
        
        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var list1 = await _canteenService.GetMenuOrderListCurrentAsync();
                var list2 = await _canteenService.GetMenuOrderListNextAsync();
                CurrentList.Clear();
                CurrentList.Add(new MenuOrderList { WeekList = new ObservableCollection<MenuOrder>(list1) });
                CurrentList.Add(new MenuOrderList { WeekList = new ObservableCollection<MenuOrder>(list2) });
                CurrentList.Add(new MenuOrderList { WeekList = null });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void RefreshItems()
        {
            if (_refreshOrders)
            {
                await ExecuteLoadItemsCommand();
                _refreshOrders = false;
            }
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
