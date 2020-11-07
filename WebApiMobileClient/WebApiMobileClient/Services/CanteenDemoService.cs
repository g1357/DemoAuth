using System;
using System.Collections.Generic;
using System.Linq;
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
        // Список типов (видов) блюд
        List<DishType> DishTypeList;
        // Список всех блюд
        List<Dish> DishList;
        // Список дневных меню на 5-дневку
        List<DayMenu> DayMenuList;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CanteenDemoService()
        {
            // Создаём список типов блюд
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
            // Создаём список всех блюд
            var dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Закуска").Id;
            DishList.Add(new Dish
            {
                Name = "ФРИТТА МИСТА", Price = 590.00M,
                Description = "Кальмары и креветки в кляре под соусом айоли",
                Weight = "290", TypeId = dishTypeId
            });
            DishList.Add(new Dish
            {
                Name = "БАКЛАЖАН ПАРМИДЖАНО", Price = 640.00M,
                Description = "Баклажаны, томатный соус, базилик, пармезан, масло оливковое",
                Weight = "370", TypeId = dishTypeId
            });
            DishList.Add(new Dish
            {
                Name = "ТУНЕЦ С ГУАКОМОЛЕ", Price = 880.00M,
                Description = "Гуакомоле, филе тунца, лук-резанец, кинза, перец чили, пармезан, соус шрирача, вустерский соус, соус табаско, оливковое масло",
                Weight = "260", TypeId = dishTypeId
            });
            DishList.Add(new Dish
            {
                Name = "ТАР ТАР ИЗ ГОВЯЖЕЙ ВЫРЕЗКИ", Price = 950.00M,
                Description = "Вырезка из говядины, красный лук, каперсы, соус табаско, дижонская горчица, вустерский соус, соль, яйцо перепелиное, багет, оливковое масло",
                Weight = "145/25", TypeId = dishTypeId
            });
            DishList.Add(new Dish
            {
                Name = "СЫР БУРАТТА",
                Price = 780.00M,
                Description = "Сыр Буратта, руккола, бальзамик.",
                Weight = "125",
                TypeId = dishTypeId
            });

            // Определяемся с датами текущего мень
            // (на текущую или следующую неделю)
            var dayOfWeek = (int) DateTime.Today.DayOfWeek;
            var offset = dayOfWeek < 5 ? -dayOfWeek + 1 : -dayOfWeek + 8;
            var today = DateTime.Today;
            // Создаём список днеыных меню.
            DayMenuList = new List<DayMenu>();
            var date = today.AddDays(offset);
            DayMenuList.Add(new DayMenu
            {
                Id = 1, Date = date, Disabled = date <= today,
                Comment = "Дневное меню на понедельник."
            });
            date = today.AddDays(offset + 1);
            DayMenuList.Add(new DayMenu
            {
                Id = 2, Date = date, Disabled = date <= today,
                Comment = "Дневное меню на вторник."
            });
            date = today.AddDays(offset + 2);
            DayMenuList.Add(new DayMenu
            {
                Id = 3, Date = date, Disabled = date <= today,
                Comment = "Дневное меню на среду."
            });
            date = today.AddDays(offset + 3);
            DayMenuList.Add(new DayMenu
            {
                Id = 4, Date = date, Disabled = date <= today,
                Comment = "Дневное меню на четверг."
            });
            date = today.AddDays(offset + 4);
            DayMenuList.Add(new DayMenu
            {
                Id = 5, Date = date, Disabled = date <= today,
                Comment = "Дневное меню на пятницу."
            });
            // Заполняем список днеыных меню
        }

        /// <summary>
        /// Получение списка типов блюд
        /// </summary>
        /// <returns>Список типов блюд</returns>
        public List<DishType> GetDishTypesAsync()
        {
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
                return DayMenuList[id - 1];
            }
            else
            {
                return null;
            }
        }
    }
}
