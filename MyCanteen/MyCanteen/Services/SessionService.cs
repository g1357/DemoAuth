using MyCanteen.Models;
using MyCanteen.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyCanteen.Services
{
    /// <summary>
    /// Сервис сеанса.
    /// Использует Xamarin.Essentials для хранения данных в защищённом хранилище.
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
            var content = string.Empty;
            try
            {
                // Получаем сериализованные данные подключёного пользователя из безопасного хранилища
                content = await SecureStorage.GetAsync("ConnectedUser");
            }
            catch (Exception exp)
            {

            }
            // Если контент не пустой,
            // то десериализуем данные из JSON в объект данных о пользователе
            return string.IsNullOrEmpty(content) ? null
                : JsonConvert.DeserializeObject<UserModel>(content);
        }

        /// <summary>
        /// Установить пользователя текущего сеанса.
        /// </summary>
        /// <param name="userModel"Данные пользователя></param>
        public async Task SetUserAsync(UserModel userModel)
        {
            // Сериализуем данные о пользователе в JSON
            string content = JsonConvert.SerializeObject(userModel);
            // Сохраняем данные о пользователе в безопасном хранилище
            // с ключом "ConnectedUser" (подключённый пользователь)
            await SecureStorage.SetAsync("ConnectedUser", content);
        }

        /// <summary>
        /// Получить токены текущего сеанса.
        /// </summary>
        /// <returns>Данные о токенах</returns>
        public async Task<TokenModel> GetTokenAsync()
        {
            // Инициализируем контент пустой строкой
            string content = string.Empty;
            try
            {
                // Получаем сериализованные данные о жетоне из безопасного хранилища
                content = await SecureStorage.GetAsync("Token");
            }
            catch (Exception exp)
            {

            }
            // Если контент не пустой,
            // то десериализуем данные из JSON в объект данных о жетоне
            return string.IsNullOrEmpty(content) ? null
                : JsonConvert.DeserializeObject<TokenModel>(content);
        }

        /// <summary>
        /// Установить токены текущего сеанса.
        /// </summary>
        /// <param name="tokenModel">Данные о токенах</param>
        public async Task SetTokenAsync(TokenModel tokenModel)
        {
            // Сериализуем данные о жетоне в JSON
            string content = JsonConvert.SerializeObject(tokenModel);
            // Сохраняем данные о жетоне в безопасном хранилище
            // с ключом "Token" (жетон)
            await SecureStorage.SetAsync("Token", content);
        }

        /// <summary>
        /// Удаляет данные о пользователе в защищённом хранилище.
        /// </summary>
        public async Task LogOutAsync()
        {
            // Очищаем в безопасном хранилище значение подключённого пользователя
            await SecureStorage.SetAsync("ConnectedUser", string.Empty);
            // Очищаем в безопасном хранилище значение жетона
            await SecureStorage.SetAsync("Token", string.Empty);
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
            // Получаем персональные значения для указанного ключа
            // со значением по умолчанию null
            var content = Preferences.Get(key, null);
            // Еcли контент не пустой, по выполняем десериализацию из JSON
            return string.IsNullOrEmpty(content) ? null
                : JsonConvert.DeserializeObject<T>(content);
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
            // Получаем персональные настройки для указанного ключа
            // со значением по умолчанию null
            var content = Preferences.Get(key, null);
            // Еcли контент не пустой, по выполняем десериализацию из JSON
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Установить значение предпочтения/установки по ключу.
        /// </summary>
        /// <typeparam name="T">Тип устанавливаемого значения</typeparam>
        /// <param name="key">Кдич настройки</param>
        /// <param name="value">Сохраняемон значение</param>
        public void SetValue<T>(string key, T value)
        {
            // Сериализуем в JSON указанное значение
            string content = JsonConvert.SerializeObject(value);
            // Сохраняем сериализованные данные в персональных настройка
            // с казанным ключок
            Preferences.Set(key, content);
        }
    }
}
