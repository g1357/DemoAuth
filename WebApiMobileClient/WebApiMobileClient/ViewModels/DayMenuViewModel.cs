using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WebApiMobileClient.Helpers;
using WebApiMobileClient.Models;
using WebApiMobileClient.Views;

namespace WebApiMobileClient.ViewModels
{
    public class DayMenuViewModel :BaseViewModel
    {
        DayMenuPage _page;

        private DayMenu _dayMenu;

        public DayMenu DayMenu
        {
            get { return _dayMenu; }
            set { SetProperty(ref _dayMenu, value); }
        }

        public ObservableCollection<Grouping<string, Dish>> ItemsGrouped { get; set; }
        public DayMenuViewModel(DayMenuPage page, DayMenu dayMenu)
        {
            _page = page;
            DayMenu = dayMenu;
            var dList = DayMenu.Dishes;
            var sorted = from item in dList
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
        }
    }
}
