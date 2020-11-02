using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    /// <summary>
    /// Настройки Web API сервиса
    /// </summary>
    public static class WebApiSettings
    {
        public const string HOST = "smtp.yandex.ru";
        public const int PORT = 465;
        public const bool ENABLESSL = true;
        public const string USERNAME = "g1357";
        public const string PASSWORD = "********";
    }
}
