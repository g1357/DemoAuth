using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WebApiMobileClient.Helpers;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    public class FullMenuGroupedViewModel : BaseViewModel
    {
        FullMenuGroupedPage _page;
        CanteenDemoService _canteenService;

        public ObservableCollection<Dish> Items { get; set; }
        public ObservableCollection<Grouping<string, Dish>> ItemsGrouped { get; set; }
        public FullMenuGroupedViewModel(FullMenuGroupedPage page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            Items = new ObservableCollection<Dish>(_canteenService.GetFullMenuAsync());
            var dishTypes = _canteenService.GetDishTypesAsync();
            foreach (var item in Items)
            {
                item.Type = dishTypes[item.TypeId];
            }
            var sorted = from item in Items
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
        }

    }
}
