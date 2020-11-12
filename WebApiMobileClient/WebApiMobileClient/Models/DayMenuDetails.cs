using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Детвльная информация дневного меню.
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
