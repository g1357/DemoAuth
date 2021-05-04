using MyCanteen.Models;
using MyCanteen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCanteen.Services
{
    /// <summary>
    /// Сервис сеанса
    /// </summary>
    public class SessionService
        : ISessionService   // Интерфейс сервиса сеанса
    {
        /// <summary>
        /// Получить пользователя текущего сеанса.
        /// </summary>
        /// <returns>Данные о текущем пользователе или null</returns>
        public async Task<UserModel> GetUserAsync()
        {
            return null;
        }

        /// <summary>
        /// Установить пользователя текущего сеанса.
        /// </summary>
        /// <param name="userModel"Данные пользователя></param>
        public async Task SetUserAsync(UserModel userModel)
        {

        }

        /// <summary>
        /// Получить токены текущего сеанса.
        /// </summary>
        /// <returns>Данные о токенах</returns>
        public async Task<TokenModel> GetTokenAsync()
        {
            return null;
        }

        /// <summary>
        /// Установить токены текущего сеанса.
        /// </summary>
        /// <param name="tokenModel">Данные о токенах</param>
        public async Task SetTokenAsync(TokenModel tokenModel)
        {

        }

        /// <summary>
        /// Удаляет данные о пользователе в защищённом хранилище.
        /// </summary>
        public async Task LogOutAsync()
        {

        }

        /// <summary>
        /// Получить значение предпочтения/установки по ключу.
        /// Возвщаемое значения является классом.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="key">Ключ настройки</param>
        /// <returns>Соответсвующее ключу значение, заданного типа</returns>
        public T GetValue<T>(string key) where T: class
        {
            return default(T);
        }

        /// <summary>
        /// Получить значение предпочтения/установки по ключу.
        /// Возвщаемое значения является структурой.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="key">Ключ настройки</param>
        /// <returns>Соответсвующее ключу значение, заданного типа</returns>
        public T GetStructValue<T>(string key) where T : struct
        {
            return default(T);
        }

        /// <summary>
        /// Установить значение предпочтения/установки по ключу.
        /// </summary>
        /// <typeparam name="T">Тип устанавливаемого значения</typeparam>
        /// <param name="key">Кдич настройки</param>
        /// <param name="value">Сохраняемон значение</param>
        public void SetValue<T>(string key, T value)
        {

        }
    }
}
