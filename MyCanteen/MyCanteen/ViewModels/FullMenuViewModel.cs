using MyCanteen.Helpers;
using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Services.Interfaces;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления полного меню
    /// </summary>
    public class FullMenuViewModel : BaseViewModel
    {
        // Представление (для использование сервиса навигации)
        FullMenuPage _page;
        // Сервис столовой
        ICanteenService _canteenService;

        public ObservableCollection<Grouping<string, Dish>> ItemsGrouped { get; set; }

        List<Dish> dList;
        public FullMenuViewModel(FullMenuPage page)
        {
            _page = page;
            IsBusy = true;

            _canteenService = DependencyService.Get<ICanteenService>();
            GetFullMenu(); //.Wait();
        }

        private async Task GetFullMenu()
        {
            var tList = await _canteenService.GetFullMenuAsync();
            Debug.WriteLine($"Qty:{dList.Count()}");
            dList = new List<Dish>();
            foreach (var item in tList)
            {
                dList.Add(item);
            }
            var sorted = from item in dList
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
            IsBusy = false;
        }
    }
}
