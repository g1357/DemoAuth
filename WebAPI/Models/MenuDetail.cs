using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// Строка дневного меню
    /// </summary>
    public class MenuDetail
    {
        public int MenuId { get; set; }
        public int DishId { get; set; }

        public Dish Dish
        {
            get => default;
            set
            {
            }
        }

        public Menu Menu
        {
            get => default;
            set
            {
            }
        }
    }
}
