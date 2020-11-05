using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Текущее меню на несколько дней,
    /// для обмена с сервисом
    /// </summary>
    public class CurrentMenuDTO
    {
        public Dictionary<DateTime, int> Current { get; set; }
        public CurrentMenuItemDTO[] CurrentItems { get; set; }
    }
}