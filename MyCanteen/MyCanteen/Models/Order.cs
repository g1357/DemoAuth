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
        /// <summary>
        /// Список блюд в заказе
        /// </summary>
        public List<Dish> Dishes { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Состояние заказа
        /// </summary>
        public OrderStatus Status
        { 
            get => (OrderStatus) OrderStatusId;
            set => OrderStatusId = (int) value;
        }

        public string StatusName => Status.Name();
        public EatingArea EatingArea
        {
            get => default;
            set
            {
            }
        }
    }
}
