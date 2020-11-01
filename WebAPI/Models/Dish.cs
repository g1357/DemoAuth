using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// Опимсание блюда
    /// </summary>
    public class Dish
    {
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название блюда
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена блюда
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Идентификатор типа блюда
        /// (закуска, первое, основное, десерт, напиток и т.п.)
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Описание блюда
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор основной картинки
        /// </summary>
        public int MainPictureIdd { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public decimal Weight { get; set; }

        [NotMapped]
        /// <summary>
        /// Идентификаторы дополнительных картинки
        /// </summary>
        public int[] PictureIds
        {
            get => Array.ConvertAll(PictuteIdsList.Split(";"), int.Parse);
            set => PictuteIdsList = string.Join(";", value.Select( p =>
                p.ToString()).ToArray());
        }
        private string PictuteIdsList { get; set; }

        /// <summary>
        /// Признак доступности для заказа
        /// </summary>
        public bool Availability { get; set; }

        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        public decimal Rating { get; set; }

    }
}
