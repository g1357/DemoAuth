using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления формы Мои заказы
    /// </summary>
    public class MyOrdersViewModel : BaseViewModel
    {
        // Страница данной модели представления
        MyOrdersPage _page;
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
            await _page.Navigation.PushAsync(new OrderPage());
        });

        /// <summary>
        /// Команда загрузки данных
        /// </summary>
        public ICommand LoadItemsCommand => new Command(async () =>
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _canteenService.GetOrdersAsync();
                //Items = new ObservableCollection<Order>(Items);
                foreach (var item in items)
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
        });

        /// <summary>
        /// Конструктор модели представления Моих заказов
        /// </summary>
        /// <param name="page">Связанная страница (представление)</param>
        public MyOrdersViewModel(MyOrdersPage page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            Items = new ObservableCollection<Order>();

            LoadItemsCommand.Execute(null);
        }
    }
}
