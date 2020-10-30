using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Объект передачи данных для регистрации нового пользователя
    /// </summary>
    public class RegisterDTO
    {
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
