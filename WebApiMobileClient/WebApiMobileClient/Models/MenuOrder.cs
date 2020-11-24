using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Дневное меню и соответствующий заказ
    /// </summary>
    public class MenuOrder
    {
        public DayMenu DMenu { get; set; }
        public Order DOrder { get; set; }
    }
}
