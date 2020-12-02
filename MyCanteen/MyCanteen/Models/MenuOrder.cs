using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Дневное меню и соответсвующий заказ.
    /// </summary>
    public class MenuOrder
    {
        /// <summary>
        /// Меню на один день
        /// </summary>
        public DayMenu DMenu { get; set; }
        
        /// <summary>
        /// Заказ на один день
        /// </summary>
        public Order  DOrder { get; set; }
    }
}
