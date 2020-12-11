using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Заказ клиента, данные обмена с сервисом
    /// </summary>
    public class OrderDTO
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Идентификатор клиента (пользователя)
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Общая сумма заказа
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Идентификатор места приёма пищи
        /// </summary>
        public int EatingAreaId { get; set; }
        /// <summary>
        /// Идентификатор состояния заказа
        /// </summary>
        public int OrderStatusId { get; set; }
    }
}
