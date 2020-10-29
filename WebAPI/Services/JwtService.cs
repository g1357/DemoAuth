using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Services
{
    /// <summary>
    /// Сераис работы с JWT токенами (жетонами)
    /// </summary>
    public class JwtService : IJwtService
    {
        /// <summary>
        /// Создать JWT токен
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Токен</returns>
        public string CreateToken(ApplicationUser user)
        {
            // Создаём список утверждений
            var claims = new List<Claim>
            {
                // Создаём новое утверждение 
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };
            // Создаём ключ шифрования
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("super secret key @ 2020"));
            // Создание подписание учётных данных
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha512Signature);
            // Создаём описатель токена безопасности
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "MyAuthServer",
                Audience = "MyAuthClient",
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            // Создаём обработчик токена
            var tokenHandler = new JwtSecurityTokenHandler();
            // Создаём токен
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Сериализуем и возвращаем созданный токен
            return tokenHandler.WriteToken(token);
        }
    }
}
