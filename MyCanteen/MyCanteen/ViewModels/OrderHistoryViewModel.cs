using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления истории заказов
    /// </summary>
    public class OrderHistoryViewModel : BaseViewModel
    {
        // Страница данной модели представления
        OrderHistoryPage _page;

        // Сервис
        CanteenDemoService _canteenService;

        private Item _selectedItem;

        public ObservableCollection<Order> Items { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        public ICommand TapOrderCommand => new Command<Order>(async (param) =>
        {
            await _page.Navigation.PushAsync(new OrderPage(param));
        });

        /// <summary>
        /// Команда загрузки данных
        /// </summary>
        public ICommand LoadItemsCommand => new Command(async () =>
        {
            await ExecuteLoadItemsCommand();
        });

        bool _refreshOrders;

        /// <summary>
        /// Конструктор модели представления Всех моих заказов
        /// </summary>
        /// <param name="page">Связанная страница (предсмтавление)</param>
        public OrderHistoryViewModel(OrderHistoryPage page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            _refreshOrders = false;
            MessagingCenter.Subscribe<DayMenuViewModel, DateTime>(
                this, "Refresh Order",
                async (sender, arg) =>
                {
                    _refreshOrders = true;
                    await _page.DisplayAlert("Message received", "arg=" + arg, "OK");
                }
            );
            MessagingCenter.Subscribe<SettingsViewModel>(
                this, "Refresh Order",
                async (sender) =>
                {
                    _refreshOrders = true;
                    await _page.DisplayAlert("Message received", "From Settings Page", "OK");
                }
            );

            Items = new ObservableCollection<Order>();

            LoadItemsCommand.Execute(null);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _canteenService.GetAllOrdersAsync();
                var items2 = from record in items
                             where record.Status != OrderStatus.NotDefined
                             orderby record.Date descending
                             select (record);
                //Items = new ObservableCollection<Order>(Items);
                foreach (var item in items2)
                {
                    if (item.Status != OrderStatus.NotDefined)
                    {
                        Items.Add(item);
                    }
                }
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
}
