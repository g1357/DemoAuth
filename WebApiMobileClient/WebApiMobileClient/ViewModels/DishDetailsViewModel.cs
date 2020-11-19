using System;
using System.Collections.Generic;
using System.Text;
using WebApiMobileClient.Models;

namespace WebApiMobileClient.ViewModels
{
    /// <summary>
    /// Подробная информация о блюде
    /// </summary>
    public class DishDetailsViewModel
    {
        public Dish DishInfo { get; set; }

        public DishDetailsViewModel()
        {

        }
        public DishDetailsViewModel(Dish dish)
        {
            DishInfo = dish;
        }
    }
}
