using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Модель данных о жетоне.
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Жетон доступа.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Жетон обновления жетона досмтупа.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Дата и время окончания срока действия жетона доступа.
        /// </summary>
        public DateTime TokenExpireTime { get; set; }
    }
}
