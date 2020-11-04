using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }

        public Order Order
        {
            get => default;
            set
            {
            }
        }

        public Dish Dish
        {
            get => default;
            set
            {
            }
        }
    }
}
