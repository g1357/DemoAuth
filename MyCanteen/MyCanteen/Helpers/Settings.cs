using MyCanteen.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Helpers
{
    /// <summary>
    /// настройки приложения
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Информация о текущем пользователе
        /// </summary>
        public static UserModel CurrentUser;

        /// <summary>
        /// Удерживать соединение с сервисом
        /// </summary>
        public static bool HoldConnect;

        /// <summary>
        /// Режим работы приложения
        /// </summary>
        public static ModeEnum CurrentMode;

    }
}
