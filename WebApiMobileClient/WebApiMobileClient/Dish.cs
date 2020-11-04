using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient
{
    public class Dish :DishDTO
    {
        public Photo Photo { get; set; }

        public DishType DishType { get; set; }
    }
}