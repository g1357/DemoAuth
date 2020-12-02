using MyCanteen.Models;
using MyCanteen.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления текущего пятидневного меню.
    /// </summary>
    public class CurrentMenuViewModel : BaseViewModel
    {
        Page _page;
        ICanteenHeavyService _canteenHService;

        List<MenuOrder> _currentList;
        public ObservableCollection<MenuOrder> CurrentList { get; set; }

        public CurrentMenuViewModel(Page page)
        {
            _page = page;
            _canteenHService = DependencyService.Get<ICanteenHeavyService>();

            _currentList = _canteenHService.GetCurrentMenuOrderListAsync();
            CurrentList = new ObservableCollection<MenuOrder>(_currentList);
        }
    }
}
