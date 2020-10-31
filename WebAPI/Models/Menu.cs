using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// Меню на день
    /// </summary>
    public class Menu
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Disabled { get; set; }
        public string Comment { get; set; }
    }
}
