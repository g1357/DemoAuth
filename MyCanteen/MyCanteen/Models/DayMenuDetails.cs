using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Детвльная информация меню на день.
    /// Набор блюд дневного меню.
    /// </summary>
    public class DayMenuDetails
    {
        /// <summary>
        /// Идентификатор дневного меню
        /// </summary>
        public int DayMenuId { get; set; }

        /// <summary>
        /// Идентификатор блюда
        /// </summary>
        public int DishId { get; set; }

    }
}
