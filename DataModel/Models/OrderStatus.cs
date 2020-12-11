﻿using System;
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
    /// <summary>
    /// Определяем метод расширения перечисления 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Название состояния меню на русском языке
        /// </summary>
        /// <param name="status">статус</param>
        /// <returns>Название состояния</returns>
        public static string Name(this MenuStatus status)
        {
            string name;
            switch (status)
            {
                case MenuStatus.NotDefined:
                    name = "Не определено";
                    break;
                case MenuStatus.Draft:
                    name = "Черновик";
                    break;
                case MenuStatus.Active:
                    name = "Активно";
                    break;
                case MenuStatus.Archive:
                    name = "В архиве";
                    break;
                default:
                    name = "ОШИБКА";
                    break;
            }
            return name;
        }
    }

}