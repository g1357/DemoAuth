using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Описание блюда, получаемое от сервиса
    /// </summary>
    public class DishDTO
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
        public int MainPictureId { get; set; }

        /// <summary>
        /// Вес (может быть в формате: "125/50/30")
        /// </summary>
        public string Weight { get; set; }

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