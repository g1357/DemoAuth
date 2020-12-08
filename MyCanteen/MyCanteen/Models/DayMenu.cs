using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Дневное меню
    /// </summary>
    public class DayMenu : DayMenuDTO
    {
        /// <summary>
        /// Список блюд дневного меню
        /// </summary>
        public List<Dish> Dishes { get; set; }

        public DayMenu(DayMenuDTO dayMenuDTO)
        {
            Id = dayMenuDTO.Id;
            Date = dayMenuDTO.Date;
            Comment = dayMenuDTO.Comment;
            MenuStatus = dayMenuDTO.MenuStatus;
            Disabled = dayMenuDTO.Disabled;
        }
    }
}
