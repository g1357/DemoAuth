﻿using MyCanteen.Helpers;
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
using System.Windows.Input;
using Xamarin.Forms;

/// <summary>
/// Пространство имён моделей представлений.
/// </summary>
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

        public Dish ItemSelected { get; set; }
        //List<Dish> dList;

        public ICommand RefreshCommand => new Command(async () =>
            await GetFullMenu()
        );

        public FullMenuViewModel(FullMenuPage page)
        {
            _page = page;
            IsBusy = true;

            _ = GetFullMenu(); //.Wait();
        }

        private async Task GetFullMenu()
        {
            _canteenService = DependencyService.Get<ICanteenService>();
            IsBusy = true;
            var tList = await _canteenService.GetFullMenuAsync();
            //Debug.WriteLine($"Qty:{dList.Count()}");
            //dList = new List<Dish>();
            //foreach (var item in tList)
            //{
            //    dList.Add(item);
            //}
            var sorted = from item in tList //dList
                         orderby item.TypeId
                         group item by item.Type.Plurals into itemGroup
                         select new Grouping<string, Dish>(itemGroup.Key, itemGroup);
            ItemsGrouped = new ObservableCollection<Grouping<string, Dish>>(sorted);
            IsBusy = false;
        }
    }
}
