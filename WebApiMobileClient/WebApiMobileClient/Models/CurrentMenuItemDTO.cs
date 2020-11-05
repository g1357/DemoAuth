using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Элемент текущего меню
    /// </summary>
    public class CurrentMenuItemDTO
    {
        public DateTime Date { get; set; }
        public int MenuId { get; set; }
    }
}
