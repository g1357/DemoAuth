using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiMobileClient.Helpers;
using WebApiMobileClient.Models;

namespace WebApiMobileClient.Services
{
    /// <summary>
    /// Сервис доступа к Web API сервису
    /// </summary>
    internal class WebApiService
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="RegisterData">Данные о пользователе для регистрации</param>
        /// <returns>Флаг успешности создания пользователя</returns>
        public async Task<bool> RegisterUserAsync(RegisterDTO RegisterData)
        {
            // Создаём клиента Http
            var client = new HttpClient();
            // Сериализуем данные регистрации
            var json = JsonSerializer.Serialize(RegisterData);
            // Создаём содержимое запроса (тело)
            HttpContent httpContent = new StringContent(json);
            // Устанавливаем тип содержимого в заголовке запроса
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Выполняем запрос и одидаем ответа
            var response = await client.PostAsync(
                Constants.BaseWebApiAddress + "/api/account/register", httpContent);
            // Возвращаем признак того успешен ли был наш запрос
            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(LoginDTO loginData)
        {
            // Создаём набор пар "ключ-значение" для моделирования ответа формы
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", loginData.UserName),
                new KeyValuePair<string, string>("password", loginData.Password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            // Формируем запрос к вёб сервису
            var request = new HttpRequestMessage(HttpMethod.Post,
                Constants.BaseWebApiAddress + "/api/account/login");
            // Добавляем в запрос тело, как ответ формы
            request.Content = new FormUrlEncodedContent(keyValues);
            // Создаём клиента Http
            var client = new HttpClient();
            HttpResponseMessage response = null;
            try
            {
                // Выполняем запрос и одидаем ответа
                response = await client.SendAsync(request);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
            // Проверяем код возврата ответа
            if (!response.IsSuccessStatusCode)
            {
                // Возвращаем пустую строку при неудачном ответе сервиса
                return string.Empty;
            }
            // Извлекаем содержимое ответа сервиса
            var content = await response.Content.ReadAsStringAsync();
            // Десериализуем JSON ответ в объект
            //JsonDocument jwtDynamic = JsonSerializer.Deserialize<dynamic>(content);
            Dictionary<string, string> pairs = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
            // Получаем время истечения срока действия
            var hasExpir = pairs.TryGetValue(".expires", out string expir);
            // Получаем токен доступа
            var hasToken = pairs.TryGetValue("access_token", out string token);
            return token;
        }
    }
}
