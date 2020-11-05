using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Вид блюда (закуска, первое, основное и т.д.)
    /// </summary>
    public class DishType
    {
        /// <summary>
        /// Идентификатор вида блюда
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название блюда
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название блюда во множественном числе
        /// </summary>
        public string Plurals { get; set; }

        /// <summary>
        /// Описание типа блюда
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Имя (файла) иконки типа блюда
        /// </summary>
        public string IconName { get; set; }
    }
}