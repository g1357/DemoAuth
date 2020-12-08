using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Место приёма пищи
    /// </summary>
    public class EatingArea
    {
        /// <summary>
        /// Идентификатор места приёма пищи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название места приёма пищи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание места приёма пищи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Адрес места приёма пищи
        /// </summary>
        public string Address { get; set; }
    }
}
