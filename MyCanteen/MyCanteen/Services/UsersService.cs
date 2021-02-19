using MyCanteen.Helpers;
using MyCanteen.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyCanteen.Services
{
    /// <summary>
    /// Сервис пользователей
    /// </summary>
    public class UsersService : IUsersService
    {
        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="loginModel">Данные для входа в систему</param>
        /// <returns>Информация о пользователе за исключением пароля</returns>
        public async Task<UserModel> Login(LoginModel loginModel)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + "/api/users/");
                    var content = JsonSerializer.Serialize(loginModel);
                    HttpContent contentPost = new StringContent(
                        content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("login", contentPost);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<UserModel>(result);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="userModel">Информация о пользователе</param>
        /// <returns>Идентификатор пользователя</returns>
        public async Task<long> Register(UserModel userModel)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + "/api/users/");
                    var content = JsonSerializer.Serialize(userModel);
                    HttpContent contentPost = new StringContent(
                        content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("register", contentPost);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<long>(result);
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Обновление токена достепа пользователя с помощью токена обновления
        /// </summary>
        /// <param name="refreshToken">Токен обновления токена доступа</param>
        /// <returns>Информация о пользователе</returns>
        public async Task<UserModel> RefreshToken(string refreshToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + "/api/users/");
                    var content = JsonSerializer.Serialize(refreshToken);
                    HttpContent contentPost = new StringContent(
                        content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("refreshtoken", contentPost);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<UserModel>(result);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получение списка всех пользователей за исключением удалённых
        /// </summary>
        /// <returns>Список информации о пользователях</returns>
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + "/api/users/");
                    var content = "";
                    HttpContent contentPost = new StringContent(
                        content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("getusers", contentPost);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<IEnumerable<UserModel>>(result);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

    }
}
