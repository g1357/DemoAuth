using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    /// <summary>
    /// Фотография блюда
    /// </summary>
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int DishId { get; set; }
        public string FileData { get; set; }
    }
}
