using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient
{
    /// <summary>
    /// Текущее меню на несколько дней
    /// </summary>
    public class CurrentMenu
    {
        public Dictionary<DateTime, DayMenu> Current { get; set; }
    }
}