using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models2
{
    public class DayMenu
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Dish> DishList { get; set; }

        public MenuStatus MenuStatus
        {
            get => default;
            set
            {
            }
        }
    }
}
