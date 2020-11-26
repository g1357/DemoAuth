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
            get => (OrderStatus) OrderStatusId;
            set
            {
                OrderStatusId = (int)value;
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
            // EatingZoneList.Find(x => x.Id == EatingZoneId);
            set
            {
            }
        }
    }
}
