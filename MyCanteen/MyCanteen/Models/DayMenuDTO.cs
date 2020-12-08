using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Дневное меню 
    /// для обмена с сервисом
    /// </summary>
    public class DayMenuDTO
    {
        /// <summary>
        /// Идентификатор дневного меню
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата меню
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Комментарий к меню
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Статус меню
        /// </summary>
        public MenuStatus MenuStatus { get; set; }

        /// <summary>
        /// Меню не доступно для заказа
        /// </summary>
        public bool Disabled { get; set; }
    }
}
