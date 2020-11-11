using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    /// <summary>
    /// Состояние блюда
    /// </summary>
    public enum DishStatus
    {
        Draft,          // Черновик
        Active,         // Активное блюда
        Archive,        // Блюдо в архиве
        NotAvailable    // Не доступно для заказа
    }

    /// <summary>
    /// Определяем метод расширения перечисления 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Название состояния на русском языке
        /// </summary>
        /// <param name="status">статус</param>
        /// <returns>Название состояния</returns>
        public static string Name(this DishStatus status)
        {
            string name;
            switch (status)
            {
                case DishStatus.Draft:
                    name = "Черновик";
                    break;
                case DishStatus.Active:
                    name = "Активно";
                    break;
                case DishStatus.Archive:
                    name = "В архиве";
                    break;
                case DishStatus.NotAvailable:
                    name = "ЧеНе доступно";
                    break;
                default:
                    name = "ОШИБКА";
                    break;
            }
            return name;
        }
    }

}