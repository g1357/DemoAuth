using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    /// <summary>
    /// Интерфейс работы с JWT жетонами (токенами)
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Создать JWT жетон
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Токен</returns>
        string CreateToken(ApplicationUser user);
    }
}
