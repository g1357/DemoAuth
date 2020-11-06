using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class DayMenu
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Dish> DishList { get; set; }
    }
}