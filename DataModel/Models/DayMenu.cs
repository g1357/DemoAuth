using System;

namespace DataModel.Models
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
        /// Статус меню
        /// </summary>
        public MenuStatus Status
        {
            get => default;
            set { }
        }

        /// <summary>
        /// Комментарий к меню
        /// </summary>
        public string Comment { get; set; }

        public MenuStatus MenuStatus
        {
            get => default;
            set
            {
            }
        }
    }
}