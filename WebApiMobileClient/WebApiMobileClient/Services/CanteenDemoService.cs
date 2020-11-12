﻿using System;
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
                    Id = 2, Name = "Салат", Plurals = "Салаты",
                    Description = "Вид закуски с которой начинают обед.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 3, Name = "Первое блюдо", Plurals = "Первые блюда",
                    Description = "Первое блюдо(суп) за обедом.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 4, Name = "Основное блюдо", Plurals = "Основные блюда",
                    Description = "Второе (основное) блюдо за обедом.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 5, Name = "Гарнир", Plurals = "Гарниры",
                    Description = "Гарнир к основному (второму) блюду.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 6, Name = "Десерт", Plurals = "Десерты",
                    Description = "Сладкое блюдо, которое едят в конце обеда.",
                    IconName = string.Empty
                },
                new DishType
                {
                    Id = 7, Name = "Напиток", Plurals = "Напитки",
                    Description = "Напитки в конце обеда. Компот и т.п",
                    IconName = string.Empty
                }
            };
            // Создаём список всех блюд
            DishList = new List<Dish>();
            // Закуски
            var dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Закуска").Id;
            DishList.Add(new Dish
            {
                Id = 1, Name = "ФРИТТА МИСТА", Price = 590.00M,
                Description = "Кальмары и креветки в кляре под соусом айоли",
                Weight = "290", TypeId = dishTypeId,
                PhotoFileName = "photo01.png"
            });
            DishList.Add(new Dish
            {
                Id = 2,
                Name = "БАКЛАЖАН ПАРМИДЖАНО", Price = 640.00M,
                Description = "Баклажаны, томатный соус, базилик, пармезан, масло оливковое",
                Weight = "370", TypeId = dishTypeId,
                PhotoFileName = "photo02.png"
            });
            DishList.Add(new Dish
            {
                Id = 3,
                Name = "ТУНЕЦ С ГУАКОМОЛЕ", Price = 880.00M,
                Description = "Гуакомоле, филе тунца, лук-резанец, кинза, перец чили, пармезан, соус шрирача, вустерский соус, соус табаско, оливковое масло",
                Weight = "260", TypeId = dishTypeId,
                PhotoFileName = "photo03.png"
            });
            DishList.Add(new Dish
            {
                Id = 4,
                Name = "ТАР ТАР ИЗ ГОВЯЖЕЙ ВЫРЕЗКИ", Price = 950.00M,
                Description = "Вырезка из говядины, красный лук, каперсы, соус табаско, дижонская горчица, вустерский соус, соль, яйцо перепелиное, багет, оливковое масло",
                Weight = "145/25", TypeId = dishTypeId,
                PhotoFileName = "photo04.png"
            });
            DishList.Add(new Dish
            {
                Id = 5,
                Name = "СЫР БУРАТТА", Price = 780.00M,
                Description = "Сыр Буратта, руккола, бальзамик.",
                Weight = "125", TypeId = dishTypeId,
                PhotoFileName = "photo05.png"
            });
            // Салаты
            dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Салат").Id;
            DishList.Add(new Dish
            {
                Id = 6,
                Name = "САЛАТ НИСУАЗ",
                Price = 880.00M,
                Description = "Тунец, кенийская фасоль, картофель мини, помидоры черри, яйцо куриное, шпинат, заправка горчично медовая, масло чесночное, соль, перец.",
                Weight = "295",
                TypeId = dishTypeId,
                PhotoFileName = "photo06.png"
            });
            DishList.Add(new Dish
            {
                Id = 7,
                Name = "ЦЕЗАРЬ С КУРИЦЕЙ",
                Price = 620.00M,
                Description = "С куриной грудкой, маринованной с медом, имбирем и специями, помидорами, домашними гренками и пармезаном.",
                Weight = "230",
                TypeId = dishTypeId,
                PhotoFileName = "photo07.png"
            });
            DishList.Add(new Dish
            {
                Id = 8,
                Name = "ЦЕЗАРЬ С КРЕВЕТКАМИ",
                Price = 780.00M,
                Description = "С креветками, обжаренными в чесночном масле и белом вине, помидорами, домашними гренками и пармезаном.",
                Weight = "205",
                TypeId = dishTypeId,
                PhotoFileName = "photo08.png"
            });
            DishList.Add(new Dish
            {
                Id = 9,
                Name = "САЛАТ С УТИНОЙ ГРУДКОЙ",
                Price = 600.00M,
                Description = "Вяленая утиная грудка, шпинат, руккола, латук, помидоры сушеные, пармезан, бальзамик, апельсиново-гочичный и лимонный соус.",
                Weight = "110",
                TypeId = dishTypeId,
                PhotoFileName = "photo09.png"
            });
            DishList.Add(new Dish
            {
                Id = 10,
                Name = "САЛАТ С АРТИШОКАМИ",
                Price = 680.00M,
                Description = "Латук, руккола, артишоки, помидоры черри, пармезан, лимонная заправка",
                Weight = "170",
                TypeId = dishTypeId,
                PhotoFileName = "photo10.png"
            });
            DishList.Add(new Dish
            {
                Id = 11,
                Name = "САЛАТ С АВОКАДО И ПОМИДОРАМИ",
                Price = 700.00M,
                Description = "Помидоры, лимон, редис, хлеб, авокадо, эдамаме, свежий, лук красный, базилик, яйцо перепелиное, соус \"Гуакамоле\".",
                Weight = "280",
                TypeId = dishTypeId,
                PhotoFileName = "photo11.png"
            });
            DishList.Add(new Dish
            {
                Id = 12,
                Name = "САЛАТ ИЗ РУККОЛЫ С КРЕВЕТКАМИ",
                Price = 860.00M,
                Description = "Креветки, pуккола, кедровые орешки, помидоры черри, сыр грана падано, лимонная заправка, бальзамик, масло чесночное.",
                Weight = "200",
                TypeId = dishTypeId,
                PhotoFileName = "photo12.png"
            });
            DishList.Add(new Dish
            {
                Id = 13,
                Name = "САЛАТ БОККОНЧИНО",
                Price = 620.00M,
                Description = "Помидоры, овечий сыр, сладкий перец, огурец, сицилийские оливки, салат айсберг, лук",
                Weight = "360",
                TypeId = dishTypeId,
                PhotoFileName = "photo13.png"
            });
            // Первые блюда
            dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Первое блюдо").Id;
            DishList.Add(new Dish
            {
                Id = 14,
                Name = "СУП ТЫКВЕННЫЙ",
                Price = 480.00M,
                Description = "Тыквенный суп с креветками, кресс салатом и трюфельным маслом.",
                Weight = "320",
                TypeId = dishTypeId,
                PhotoFileName = "photo14.png"
            });
            DishList.Add(new Dish
            {
                Id = 15,
                Name = "СУП КАЧУККО",
                Price = 850.00M,
                Description = "Томатный суп с морепродуктами, филе сибаса, с овощами.",
                Weight = "355/50",
                TypeId = dishTypeId,
                PhotoFileName = "photo15.png"
            });
            DishList.Add(new Dish
            {
                Id = 16,
                Name = "СУП ИЗ БЕЛЫХ ГРИБОВ",
                Price = 550.00M,
                Description = "Белые грибы, картофель, домашняя лапша",
                Weight = "450/50",
                TypeId = dishTypeId,
                PhotoFileName = "photo16.png"
            });
            DishList.Add(new Dish
            {
                Id = 17,
                Name = "МИНЕСТРОНЕ",
                Price = 350.00M,
                Description = "Овощной суп. Подается с помидорами черри и соусом \"Песто\".",
                Weight = "300",
                TypeId = dishTypeId,
                PhotoFileName = "photo17.png"
            });
            DishList.Add(new Dish
            {
                Id = 18,
                Name = "ЛАПША С ФРИКАДЕЛЬКАМИ",
                Price = 400.00M,
                Description = "Куриный бульон, домашняя лапша, фрикадельки, яйцо, морковь.",
                Weight = "400",
                TypeId = dishTypeId,
                PhotoFileName = "photo18.png"
            });
            // Основные блюда
            dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Основное блюдо").Id;
            DishList.Add(new Dish
            {
                Id = 19,
                Name = "ПАЛТУС С МОРЕПРОДУКТАМИ",
                Price = 705.00M,
                Description = "Филе палтуса, мидии коце, мидии вонголи, помидоры черри, картофель, чеснок, каперсы, петрушка, базилик, кресс салат.",
                Weight = "400",
                TypeId = dishTypeId,
                PhotoFileName = "photo19.png"
            });
            DishList.Add(new Dish
            {
                Id = 20,
                Name = "СТЕЙК ИЗ ТУНЦА",
                Price = 1100.00M,
                Description = "Филе тунца, помидоры, радичио, романо, петрушка, масло оливковое, перец черный, соль.",
                Weight = "200/150",
                TypeId = dishTypeId,
                PhotoFileName = "photo20.png"
            });
            DishList.Add(new Dish
            {
                Id = 21,
                Name = "СИБАС С ОЛИВКАМИ И КАРТОФЕЛЕМ",
                Price = 900.00M,
                Description = "Филе сибаса, запеченное в печи, таджасские оливки, картофель",
                Weight = "330",
                TypeId = dishTypeId,
                PhotoFileName = "photo21.png"
            });
            DishList.Add(new Dish
            {
                Id = 22,
                Name = "ЛОСОСЬ С ЦВЕТНОЙ КАПУСТОЙ",
                Price = 1350.00M,
                Description = "Филе лосося, картофель, цветная капуста, масло сливочное, масло чесночное, горчица зернистая, соль, перец",
                Weight = "180/160/30",
                TypeId = dishTypeId,
                PhotoFileName = "photo22.png"
            });
            DishList.Add(new Dish
            {
                Id = 23,
                Name = "СТЕЙК СТРИПЛОЙН",
                Price = 1850.00M,
                Description = "Стейк стриплойн, чеснок печенный, лимон, соль, перец.",
                Weight = "250/60",
                TypeId = dishTypeId,
                PhotoFileName = "photo23.png"
            });
            DishList.Add(new Dish
            {
                Id = 24,
                Name = "ВЫРЕЗКА В ПЕРЕЧНОМ СОУСЕ С КАРТОФЕЛЬНЫМ ПЮРЕ И ШПИНАТОМ",
                Price = 1550.00M,
                Description = "Вырезка миланезе в перечном соусе, картофельное пюре, шпинат, тимьян, чеснок, сливочное масло, оливковое масло, чесночное масло.",
                Weight = "290",
                TypeId = dishTypeId,
                PhotoFileName = "photo24.png"
            });
            DishList.Add(new Dish
            {
                Id = 25,
                Name = "ТЕЛЯЧЬЯ ПЕЧЕНЬ С ЛУКОМ",
                Price = 550.00M,
                Description = "Телячья печень, лук репчатый, кресс салат, помидоры, бульон овощной, масло оливковое, бальзамик выпаренный",
                Weight = "300",
                TypeId = dishTypeId,
                PhotoFileName = "photo25.png"
            });
            DishList.Add(new Dish
            {
                Id = 26,
                Name = "ЦЫПЛЁНОК",
                Price = 890.00M,
                Description = "Цыплёнок, приготовленный в печи с картофелем и розмарином",
                Weight = "1 шт./150/80",
                TypeId = dishTypeId,
                PhotoFileName = "photo26.png"
            });
            DishList.Add(new Dish
            {
                Id = 27,
                Name = "ВЫРЕЗКА ИЗ ГОВЯДИНЫ",
                Price = 1700.00M,
                Description = "Говяжья вырезка, приготовленная на открытом огне. Подается с запеченным в печи картофелем, сладким перцем и помидором,",
                Weight = "150/110",
                TypeId = dishTypeId,
                PhotoFileName = "photo27.png"
            });
            // Гарниры
            dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Гарнир").Id;
            DishList.Add(new Dish
            {
                Id = 28,
                Name = "КАРТОФЕЛЬ С ВЕШЕНКАМИ И КРЕМОМ ИЗ СКАМОРЦЫ",
                Price = 480.00M,
                Description = "Картофель, вешенки, крем из скаморцы, чеснок, петрушка, кресс салат, лук репчатый, зеленое масло, соль.",
                Weight = "285", TypeId = dishTypeId,
                PhotoFileName = "photo28.png"
            });
            DishList.Add(new Dish
            {
                Id = 29,
                Name = "ШПИНАТ", Price = 300.00M,
                Description = "Шпинат, обжаренный на сливочном масле, вино, чесночное масло, соль.",
                Weight = "300", TypeId = dishTypeId,
                PhotoFileName = "photo29.png"
            });
            DishList.Add(new Dish
            {
                Id = 30,
                Name = "КАРТОФЕЛЬНОЕ ПЮРЕ", Price = 200.00M,
                Description = "Картофель, соль, сливки, перец.",
                Weight = "150", TypeId = dishTypeId,
                PhotoFileName = "photo30.png"
            });
            DishList.Add(new Dish
            {
                Id = 31,
                Name = "КАРТОФЕЛЬ ФРИ", Price = 220.00M,
                Description = "Картофель, обжаренный во фритюре, соль.",
                Weight = "150", TypeId = dishTypeId,
                PhotoFileName = "photo31.png"
            });
            DishList.Add(new Dish
            {
                Id = 32,
                Name = "ЗАПЕЧЕННЫЕ ОВОЩИ С ГРИБАМИ", Price = 300.00M,
                Description = "Цукини, сладкий перец, шампиньоны, чеснок, розмарин, оливковое масло, соль",
                Weight = "150", TypeId = dishTypeId,
                PhotoFileName = "photo32.png"
            });
            // Десерты
            dishTypeId = DishTypeList.FirstOrDefault(r => r.Name == "Десерт").Id;
            DishList.Add(new Dish
            {
                Id = 33,
                Name = "ТОРТ ТРИ ШОКОЛАДА", Price = 550.00M,
                Description = "Шоколадный бисквит, мусс три шоколада, шоколадная глазурь; с добавлением коньяка.",
                Weight = "225", TypeId = dishTypeId,
                PhotoFileName = "photo33.png"
            });
            DishList.Add(new Dish
            {
                Id = 34,
                Name = "ТОРТ С ИНЖИРОМ", Price = 650.00M,
                Description = "Миндальный корж, сырный крем, инжир, малина, мята, малиновый соус",
                Weight = "255", TypeId = dishTypeId,
                PhotoFileName = "photo34.png"
            });
            DishList.Add(new Dish
            {
                Id = 35,
                Name = "ПИРОГ С КЛУБНИКОЙ", Price = 400.00M,
                Description = "Тесто песочное с цедрой, клубника, крем заварной.",
                Weight = "180", TypeId = dishTypeId,
                PhotoFileName = "photo35.png"
            });
            DishList.Add(new Dish
            {
                Id = 36,
                Name = "ЧИЗКЕЙК С ЯГОДАМИ", Price = 480.00M,
                Description = "Песочное тесто, творожный сыр, сметана, сливки, ягоды.",
                Weight = "229", TypeId = dishTypeId,
                PhotoFileName = "photo36.png"
            });
            DishList.Add(new Dish
            {
                Id = 37,
                Name = "ТОРТ НАПОЛЕОН ЯБЛОЧНЫЙ", Price = 380.00M,
                Description = "Торт по домашнему рецепту из слоеного теста, яблок и сгущеного молока. Подается с малиновым соусом.",
                Weight = "280", TypeId = dishTypeId,
                PhotoFileName = "photo37.png"
            });
            DishList.Add(new Dish
            {
                Id = 38,
                Name = "ТОРТ НАПОЛЕОН", Price = 400.00M,
                Description = "Слоеные коржи, заварной крем, ваниль.",
                Weight = "235", TypeId = dishTypeId,
                PhotoFileName = "photo38.png"
            });
            DishList.Add(new Dish
            {
                Id = 39,
                Name = "ТОРТ МЕДОВИК ДВА КРЕМА", Price = 330.00M,
                Description = "Бисквитные коржи, мед гречичный, сметана, сгущеное молоко.",
                Weight = "190", TypeId = dishTypeId,
                PhotoFileName = "photo39.png"
            });
            DishList.Add(new Dish
            {
                Id = 40,
                Name = "ТИРАМИСУ", Price = 370.00M,
                Description = "Печенье савоярди,кофе американо. Мусс : сыр маскарпоне,яйцо,сахар,сливки,желатин,темный ром. Декор швейцарская меренга (белок,сахар.пудра ) Какао,кофе в зернах.",
                Weight = "160", TypeId = dishTypeId,
                PhotoFileName = "photo40.png"
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
        /// Получение полного меню.
        /// </summary>
        /// <returns>Полный список блюд</returns>
        public List<Dish> GetFullMenuAsync()
        {
            return DishList;
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