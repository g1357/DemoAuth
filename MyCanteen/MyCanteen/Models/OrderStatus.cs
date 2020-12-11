using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
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
    /// <summary>
    /// Определяем метод расширения перечисления 
    /// </summary>
    public static class OrderStatusExtensions
    {
        /// <summary>
        /// Название состояния меню на русском языке
        /// </summary>
        /// <param name="status">статус</param>
        /// <returns>Название состояния</returns>
        public static string Name(this OrderStatus status)
        {
            string name;
            switch (status)
            {
                case OrderStatus.NotDefined:
                    name = "Не создан";
                    break;
                case OrderStatus.Created:
                    name = "Создан";
                    break;
                case OrderStatus.Sent:
                    name = "Отправлен";
                    break;
                case OrderStatus.Acepted:
                    name = "Принят";
                    break;
                case OrderStatus.Paid:
                    name = "Оплачен";
                    break;
                case OrderStatus.Confirmed:
                    name = "Подтверждён";
                    break;
                case OrderStatus.Delivered:
                    name = "Доставлен";
                    break;
                case OrderStatus.Closed:
                    name = "выполнен";
                    break;
                default:
                    name = "ОШИБКА";
                    break;
            }
            return name;
        }
    }

}
