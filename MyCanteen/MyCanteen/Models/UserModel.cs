using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Модель данных пользователя
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Номер мобильного телефона пользователя
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Состояние учётной записи пользователя
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Токен доступа пользователя
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Дата окончания действия токена доступа
        /// </summary>
        public DateTime TokenExpires { get; set; }

        /// <summary>
        /// Токен обновления токена доступа
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime? DeletionDate { get; set; }
    }
}
