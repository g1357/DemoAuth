using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    /// <summary>
    /// Модель представления текщего 5-днеыгного меню
    /// </summary>
    public class CurrentMenuViewModel
    {
        CurrentMenuPage _page;
        CanteenDemoService _canteenService;
        private List<DayMenuDTO> _currentMenuDTO { get; set; }
        private List<DayMenu> _currentMenu { get; set; }
        public ObservableCollection<DayMenu> CurrentMenu { get; set; }

        public CurrentMenuViewModel(CurrentMenuPage page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

            _currentMenuDTO = (List<DayMenuDTO>)_canteenService.GetCurrentMenuAsync();

            _currentMenu = new List<DayMenu>();
            foreach( var item in _currentMenuDTO)
            {
                _currentMenu.Add(new DayMenu(item));
            }
            foreach (var item in _currentMenu)
            {
                var dayMenuId = item.Id;
                var dishIdList = _canteenService.GetDishIdListAsync(dayMenuId);
                item.Dishes = new List<Dish>();
                foreach (var dishId in dishIdList)
                {
                    var dishDTO = _canteenService.GetDishByIdAsync(dishId);
                }
            }
            CurrentMenu = new ObservableCollection<DayMenu>(_currentMenu);
        }
    }
}
