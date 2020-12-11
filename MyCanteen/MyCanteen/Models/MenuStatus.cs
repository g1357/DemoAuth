using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Перечисление: состояние меню
    /// </summary>
    public enum MenuStatus
    {
        NotDefined, // Не определено
        Draft,      // Черновик
        Active,     // Активно
        Archive     // В архиве
    }

    /// <summary>
    /// Определяем метод расширения перечисления 
    /// </summary>
    public static class MenuStatusExtensions
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
