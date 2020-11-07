using System;

namespace WebApiMobileClient
{
    /// <summary>
    /// Дневное меню
    /// </summary>
    public class DayMenu
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
        /// Признак доступности
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// Комментарий к меню
        /// </summary>
        public string Comment { get; set; }
    }
}