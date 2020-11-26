using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    /// <summary>
    /// Состояние заказа
    /// </summary>
    public enum OrderStatus
    {
        NotDefined, // Не определено
        Created,    // Создан
        Sent,       // Отправлен
        Acepted,    // Принят
        Paid,       // Оплачен
        Confirmed,  // Подтверждён
        Delivered,  // Доставлен
        Closed      // Закрыт
    }
}