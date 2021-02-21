using MyCanteen.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCanteen.Services
{
    /// <summary>
    /// Интерфейс сервиса пользователей
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="loginModel">Данные для входа в систему</param>
        /// <returns>Информация о пользователе за исключением пароля</returns>
        Task<UserModel> Login(LoginModel loginModel);
        Task<(UserModel, string)> Login2(LoginModel loginModel);

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="userModel">Информация о пользователе</param>
        /// <returns>Идентификатор пользователя</returns>
        Task<long> Register(UserModel userModel);

        /// <summary>
        /// Обновление токена достепа пользователя с помощью токена обновления
        /// </summary>
        /// <param name="refreshToken">Токен обновления токена доступа</param>
        /// <returns>Информация о пользователе</returns>
        Task<UserModel> RefreshToken(string refreshToken);

        /// <summary>
        /// Получение списка всех пользователей за исключением удалённых
        /// </summary>
        /// <returns>Список информации о пользователях</returns>
        Task<IEnumerable<UserModel>> GetAllUsers();
    }
}
