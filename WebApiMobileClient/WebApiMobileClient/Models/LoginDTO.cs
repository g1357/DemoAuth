using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Объект передачи данных для входа пользователя
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Эл. почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
