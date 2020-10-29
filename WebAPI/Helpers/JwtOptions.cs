using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    /// <summary>
    /// Пармаиетры JWT жетона (токена)
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Издатель жетона
        /// </summary>
        public const string ISSUER = "MyAuthServer";
        /// <summary>
        /// Потребитель жетона
        /// </summary>
        public const string AUDIENCE = "MyAuthClient";
        /// <summary>
        /// Ключ для шифрования
        /// </summary>
        public const string KEY = "super secret key @ 2020";
        /// <summary>
        /// Время жизни жетона - 1 минута
        /// </summary>
        public const int LIFETIME = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
