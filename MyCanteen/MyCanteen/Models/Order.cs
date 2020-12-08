using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public class Order : OrderDTO
    {
        public List<Dish> Dishes { get; set; }

        public EatingArea EatingArea
        {
            get => default;
            set
            {
            }
        }
    }
}
