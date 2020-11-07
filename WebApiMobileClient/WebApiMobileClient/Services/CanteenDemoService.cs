using System;
using System.Collections.Generic;
using System.Text;
using WebApiMobileClient.Models;
using KeyType = System.Int16;

namespace WebApiMobileClient.Services
{
    /// <summary>
    /// Демонстрационный сервис работы со столовой
    /// </summary>
    public class CanteenDemoService : ICanteenService
    {
        // Список дневных меню на 5-дневку
        List<DayMenu> DayMenuList;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CanteenDemoService()
        {

            // Создаём список днеыных меню.
            List<DayMenu> DayMenuList = new List<DayMenu>
            {
                new DayMenu
                {
                },
                new DayMenu
                {
                },
                new DayMenu
                {
                },
                new DayMenu
                {
                },
                new DayMenu
                {
                }
            };

        }

        /// <summary>
        /// Получение списка типов блюд
        /// </summary>
        /// <returns>Список типов блюд</returns>
        public List<DishType> GetDishTypesAsync()
        {
            var DishTypeList = new List<DishType>
            {
                new DishType
                {
                    Id = 1, Name = "Закуска", Plurals = "Закуски",
                    Description = "Блюда с которых начинают обед.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 2, Name = "Слат", Plurals = "Салаты",
                    Description = "Вид закуски с которой начинают обед.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 3, Name = "Основное блюдо", Plurals = "Основные блюда",
                    Description = "Второе (основное) блюдо за обедом.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 4, Name = "Гарнир", Plurals = "Гарниры",
                    Description = "Гарнир к основному (второму) блюду.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 5, Name = "Десерт", Plurals = "Десерты",
                    Description = "Сладкое блюдо, которое едят в конце обеда.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 6, Name = "Напиток", Plurals = "Напитки",
                    Description = "Напитки в конце обеда. Компот и т.п",
                    IconName = string.Empty
                }
            };
            return DishTypeList;
        }

        /// <summary>
        /// Получение списка идентификаторов текущего меню
        /// </summary>
        /// <returns>Список идентификаторов дневных меню</returns>
        public List<KeyType> GetCurrentMenuIdsAsync()
        {
            var CurrentMenuList = new List<KeyType>
            {
                1, 2, 3, 4, 5
            };

            return CurrentMenuList;
        }

        /// <summary>
        /// ПОлочение дневного меню по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор дневного меню</param>
        /// <returns>Дневное меню</returns>
        public DayMenu GetDayMenuAsync(KeyType id)
        {
            if (id > 0 && id <= DayMenuList.Count)
            {
                return DayMenuList[id];
            }
            else
            {
                return null;
            }
        }
    }
}
