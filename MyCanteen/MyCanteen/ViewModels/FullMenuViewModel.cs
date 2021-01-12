using MyCanteen.Helpers;
using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        CanteenDemoService _canteenService;

        public ObservableCollection<Grouping<string, Dish>> ItemsGrouped { get; set; }

        public FullMenuViewModel(FullMenuPage page)
        {
            _page = page;

            _canteenService = DependencyService.Get<CanteenDemoService>();
            var dList = _canteenService.GetFullMenuAsync();
            var sorted = from item in dList
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
        }
    }
}
