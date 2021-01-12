using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Helpers
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Дата начала недели в зависимости о параметра,
        /// задающего понедельник и восткресенье
        /// </summary>
        /// <param name="dt">Дата</param>
        /// <param name="startOfWeek">Деньнедели, с которого начинается неделя</param>
        /// <returns>Дана начала недели</returns>
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek)
        {
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Дата начала недели в зависимости от тукещей культуры
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Дата начала недели</returns>
        public static DateTime StartOfWeek(this DateTime date)
        {
            // Current Culture Info
            System.Globalization.CultureInfo ci =
                System.Threading.Thread.CurrentThread.CurrentCulture;
            // First day of week in current culture (sunday or monday)
            DayOfWeek firstDayOfWeek = ci.DateTimeFormat.FirstDayOfWeek;
            // Day of week of input date
            DayOfWeek dateDayOfWeek = date.DayOfWeek;
            // Date of start of week in cerrent week
            DateTime startDayOfWeek = DateTime.Now.AddDays(
                -((7 + (dateDayOfWeek - firstDayOfWeek)) % 7)
                ).Date;
            return startDayOfWeek;
        }
    }
}
