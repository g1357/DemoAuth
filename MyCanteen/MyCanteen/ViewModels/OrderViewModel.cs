using MyCanteen.Models;
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
    public class OrderViewModel : BaseViewModel
    {
        OrderPage _page;
        Order _order;
        public Order ThisOrder
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }

        public ObservableCollection<Dish> Items { get; set; }

        /// <summary>
        /// Команда загрузки данных
        /// </summary>
        public ICommand LoadItemsCommand => new Command(async () =>
        {
            await ExecuteLoadItemsCommand();
        });

        public OrderViewModel(OrderPage page, Order order)
        {
            _page = page;
            _order = order;
            Items = new ObservableCollection<Dish>(ThisOrder.Dishes);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                //Items.Clear();
                //var items = await _canteenService.GetAllOrdersAsync();
                //var items2 = from record in items
                //             where record.Status != OrderStatus.NotDefined
                //             orderby record.Date descending
                //             select (record);
                Items = new ObservableCollection<Dish>(ThisOrder.Dishes);
                //foreach (var item in items2)
                //{
                //    if (item.Status != OrderStatus.NotDefined)
                //    {
                //        Items.Add(item);
                //    }
                //}
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

    }
}
