using MyCanteen.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCanteen.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервис сеанса
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Получить пользователя текущего сеанса.
        /// </summary>
        /// <returns>Данные о текущем пользователе или null</returns>
        public Task<UserModel> GetUserAsync();

        /// <summary>
        /// Установить пользователя текущего сеанса.
        /// </summary>
        /// <param name="userModel"Данные пользователя></param>
        public Task SetUserAsync(UserModel userModel);

        /// <summary>
        /// Получить токены текущего сеанса.
        /// </summary>
        /// <returns>Данные о токенах</returns>
        public Task<TokenModel> GetTokenAsync();

        /// <summary>
        /// Установить токены текущего сеанса.
        /// </summary>
        /// <param name="tokenModel">Данные о токенах</param>
        public  Task SetTokenAsync(TokenModel tokenModel);

        /// <summary>
        /// Удаляет данные о пользователе в защищённом хранилище.
        /// </summary>
        public Task LogOutAsync();

        /// <summary>
        /// Получить значение предпочтения/установки по ключу.
        /// Возвщаемое значения является классом.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="key">Ключ настройки</param>
        /// <returns>Соответсвующее ключу значение, заданного типа</returns>
        public T GetValue<T>(string key) where T : class;

        /// <summary>
        /// Получить значение предпочтения/установки по ключу.
        /// Возвщаемое значения является структурой.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="key">Ключ настройки</param>
        /// <returns>Соответсвующее ключу значение, заданного типа</returns>
        public T GetStructValue<T>(string key) where T : struct;

        /// <summary>
        /// Установить значение предпочтения/установки по ключу.
        /// </summary>
        /// <typeparam name="T">Тип устанавливаемого значения</typeparam>
        /// <param name="key">Кдич настройки</param>
        /// <param name="value">Сохраняемон значение</param>
        public void SetValue<T>(string key, T value);
    }
}
