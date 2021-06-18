using MyCanteen.Helpers;
using MyCanteen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var (userModel, message) = await Login2(loginModel);
            return userModel;
        }
            
        public async Task<(UserModel, string)> Login2(LoginModel loginModel)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                //specify to use TLS 1.2 as default connection
                System.Net.ServicePointManager.SecurityProtocol = 
                    System.Net.SecurityProtocolType.Tls12 
                    | System.Net.SecurityProtocolType.Tls11 
                    | System.Net.SecurityProtocolType.Tls;

                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + "/api/users/");
                    //var content = JsonSerializer.Serialize(loginModel);
                    var content = JsonConvert.SerializeObject(loginModel);
                    HttpContent contentPost = new StringContent(
                        content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("login", contentPost);

                    //var request = new HttpRequestMessage(HttpMethod.Post,
                    //    Constants.GetBaseWebApiAddress() + "/api/users/login");
                    //// Добавляем в запрос тело, как ответ формы
                    ////request.Content = new FormUrlEncodedContent(keyValues);
                    //request.Content = new StringContent(content);
                    //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    //HttpResponseMessage response = null;
                    //response = await httpClient.SendAsync(request);



                    if (!response.IsSuccessStatusCode)
                    {
                        //throw new HttpRequestException();
                        var result = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(result))
                        {
                            return (null, response.ReasonPhrase);
                        }
                        else
                        {
                            return (null, result);
                        }
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //return JsonSerializer.Deserialize<UserModel>(result);
                        return (JsonConvert.DeserializeObject<UserModel>(result), "");
                    }
                }
                catch (Exception ex)
                {
                    return (null, "Web service access error.");
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
                    var content = System.Text.Json.JsonSerializer.Serialize(userModel);
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
                        return System.Text.Json.JsonSerializer.Deserialize<long>(result);
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
                    var content = System.Text.Json.JsonSerializer.Serialize(refreshToken);
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
                        return System.Text.Json.JsonSerializer.Deserialize<UserModel>(result);
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
            IEnumerable<UserModel> users;
            
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + "/api/users/");
                    //var content = "";
                    //HttpContent contentPost = new StringContent(
                    //    content, Encoding.UTF8, "application/json");
                    //httpClient.DefaultRequestHeaders.Accept.Add(
                    //    new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add(
                        "Authorization",
                        $"Bearer {Settings.CurrentUser.Token}");
                    var response = await httpClient.GetAsync("getusers");
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var users2 = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<UserModel>>(result);
                        users = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    users = null;
                }
            }
            return users;
        }

    }
}
