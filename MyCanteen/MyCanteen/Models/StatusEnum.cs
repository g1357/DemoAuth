using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Перечисление состояния учётной записи пользователя
    /// </summary>
    public enum StatusEnum
    {
        /// <summary>
        /// На рассмотрении
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Активна
        /// </summary>
        Active = 1,

        /// <summary>
        /// Удалена
        /// </summary>
        Deleted = 2
    }
}
