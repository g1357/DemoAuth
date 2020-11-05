using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Фотография блюда
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Идентификатор фотографии
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Имя файла фотографии
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Идентификатор блюда для которого сделана фотография
        /// </summary>
        public int DishId { get; set; }

        /// <summary>
        /// Данные фотографии
        /// </summary>
        //public string FileData { get; set; }
    }
}