using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Текущее меню на несколько дней
    /// </summary>
    public class CurrentMenu
    {
        public Dictionary<DateTime, DayMenu> Current { get; set; }
    }
}