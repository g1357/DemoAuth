using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public  class Order : OrderDTO
    {
        public OrderStatus OrderStatus
        {
            get => default;
            set
            {
            }
        }

        public User User
        {
            get => default;
            set
            {
            }
        }

        public EatingZone EatingZone
        {
            get => default;
            set
            {
            }
        }
    }
}
