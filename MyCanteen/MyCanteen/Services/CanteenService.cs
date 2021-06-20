using MyCanteen.Helpers;
using MyCanteen.Models;
using MyCanteen.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyCanteen.Services
{
    /// <summary>
    /// Интерфейс для сетевого сервиса столовой
    /// </summary>
    public class CanteenService : ICanteenService
    {
        // Имя файла для сохранений заказов
        const string FileName = @"orders.json";

        // Список типов (видов) блюд
        List<DishType> DishTypeList;
        // Список всех блюд
        List<Dish> DishList;
        // Список дневных меню на текущую 5-дневку
        List<DayMenuDTO> DayMenuList;
        // Список дневных меню на следующую 5-дневку
        List<DayMenuDTO> DayMenuListNext;
        // Список детальной информации дневного меню
        List<DayMenuDetails> DayMenuDetailsList;
        // Список заказов
        List<Order> OrderList;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CanteenService()
        {
            // Создаём список типов блюд
            DishTypeList = new List<DishType>();

            OrderList = new List<Order>();
        }

        /// <summary>
        /// Получить список типов блюд.
        /// </summary>
        /// <returns>Список типов блюд.</returns>
        public async Task<IEnumerable<DishType>> GetDishTypesAsync()
        {
            IEnumerable<DishType> dishTypes = null;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + @"/api/catalog/");
                    //var content = "";
                    //HttpContent contentGet = new StringContent(
                    //    content, Encoding.UTF8, "application/json");
                    //httpClient.DefaultRequestHeaders.Accept.Add(
                    //    new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add(
                        "Authorization",
                        $"Bearer {Settings.CurrentUser.Token}");
                    var response = await httpClient.GetAsync("GetAllDishTypes");
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var dishTypes2 = System.Text.Json.JsonSerializer.Deserialize<List<DishType>>(result);
                        dishTypes = JsonConvert.DeserializeObject<IEnumerable<DishType>>(result);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return dishTypes;
        }

        /// <summary>
        /// Получить полное меню.
        /// </summary>
        /// <returns>Полный список блюд</returns>
        public async Task<IEnumerable<Dish>> GetFullMenuAsync()
        {
            List<DishType> DishTypesList;
            List<Dish> dishList = null;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri(
                        Constants.GetBaseWebApiAddress() + @"/api/catalog/");
                    //var content = "";
                    //HttpContent contentGet = new StringContent(
                    //    content, Encoding.UTF8, "application/json");
                    //httpClient.DefaultRequestHeaders.Accept.Add(
                    //    new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add(
                        "Authorization",
                        $"Bearer {Settings.CurrentUser.Token}");
                    var response = await httpClient.GetAsync("GetFullMenu");
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dishList = JsonConvert.DeserializeObject<List<Dish>>(result);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
            }

            var DL = new List<Dish>();
            try
            {
                DishTypesList = (List<DishType>)await GetDishTypesAsync();

                foreach (var dish in dishList)
                {
                    //dish.Type = DishTypeList[dish.TypeId];
                    dish.Type = DishTypesList.Find(t => t.Id == dish.TypeId);
                    DL.Add(dish);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return DL; // dishList;
        }

        /// <summary>
        /// Получение списка идентификаторов текущего меню
        /// </summary>
        /// <returns>Список идентификаторов дневных меню</returns>
        public IList<DayMenuDTO> GetCurrentMenuAsync()
        {
            return DayMenuList;
        }

        public List<int> GetDishIdListAsync(int dayMenuId)
        {
            var dishIdList = from item in DayMenuDetailsList
                             where item.DayMenuId == dayMenuId
                             select (item.DishId);
            return new List<int>(dishIdList);
        }

        public Dish GetDishByIdAsync(int dishId)
        {
            var dish = from item in DishList
                       where item.Id == dishId
                       select item;
            return dish.FirstOrDefault();
        }

        /// <summary>
        /// Полочение дневного меню по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор дневного меню</param>
        /// <returns>Дневное меню</returns>
        public DayMenuDTO GetDayMenuAsync(int id)
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

        /// <summary>
        /// Получить текущий список меню и заказов
        /// (на теущую неделю)
        /// </summary>
        /// <returns>Подневный список пар менюБ заказ.</returns>
        public async Task<List<MenuOrder>> GetMenuOrderListCurrentAsync()
        {
            var result = new List<MenuOrder>();
            DayMenu dayMenu;
            Order dayOrder;
            DateTime date;
            int maxId;
            foreach (var item in DayMenuList)
            {
                dayMenu = new DayMenu(item);
                date = dayMenu.Date.Date;
                var dishIdList = from record in DayMenuDetailsList
                                 where record.DayMenuId == dayMenu.Id
                                 select (record.DishId);
                dayMenu.Dishes = new List<Dish>();
                foreach (var dishId in dishIdList)
                {
                    var dishDTO = from d in DishList
                                  where d.Id == dishId
                                  select d;
                    Dish dish = dishDTO.FirstOrDefault();
                    dish.Type = DishTypeList[dish.TypeId];
                    dayMenu.Dishes.Add(dish);
                }

                dayOrder = OrderList.Find(o => o.Date.Date == date.Date);
                if (dayOrder == null)
                {
                    if (OrderList == null || OrderList.Count == 0)
                    {
                        maxId = 0;
                    }
                    else
                    {
                        maxId = OrderList.Max(order => order.Id);
                    }
                    dayOrder = new Order
                    {
                        // OrderDTO
                        Id = maxId! + 1,
                        Date = date,
                        UserId = "demo user",
                        Total = 0L,
                        EatingAreaId = 0,
                        OrderStatusId = 0,
                        // Order
                        UserName = "Demo User",
                        EatingArea = null,
                        Status = OrderStatus.NotDefined,
                        Dishes = null
                    };
                    OrderList.Add(dayOrder);
                }
                result.Add(new MenuOrder
                {
                    DMenu = dayMenu,
                    DOrder = dayOrder
                });
            }
            return result;
        }

        /// <summary>
        /// Получить следующий список меню и заказов
        /// (на следующую неделю)
        /// </summary>
        /// <returns>Подневный список пар менюБ заказ.</returns>
        public async Task<List<MenuOrder>> GetMenuOrderListNextAsync()
        {
            var result = new List<MenuOrder>();
            DayMenu dayMenu;
            Order dayOrder;
            DateTime date;
            foreach (var item in DayMenuList)
            {
                dayMenu = new DayMenu(item);
                date = dayMenu.Date.Date;
                var dishIdList = from record in DayMenuDetailsList
                                 where record.DayMenuId == dayMenu.Id
                                 select (record.DishId);
                dayMenu.Dishes = new List<Dish>();
                foreach (var dishId in dishIdList)
                {
                    var dishDTO = from d in DishList
                                  where d.Id == dishId
                                  select d;
                    Dish dish = dishDTO.FirstOrDefault();
                    dish.Type = DishTypeList[dish.TypeId];
                    dayMenu.Dishes.Add(dish);
                }

                dayOrder = OrderList.Find(o => o.Date.Date == date.Date);

                result.Add(new MenuOrder
                {
                    DMenu = dayMenu,
                    DOrder = dayOrder
                });
            }
            return result;
        }


        #region Операции с заказами
        /// <summary>
        /// Получмить состояние заказа на указанную ждату
        /// </summary>
        /// <param name="date">дата</param>
        public OrderStatus GetOrderStatusAsync(DateTime date)
        {
            return OrderStatus.NotDefined;
        }

        /// <summary>
        /// Получить детальную информацию о заказе на заданную дату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Заказ</returns>
        public Order GetOrderAsync(DateTime date)
        {
            var order = OrderList.Find(o => o.Date.Date == date.Date);
            return order;
        }

        /// <summary>
        /// Добавить блюдо к заказу на указанную дату.
        /// </summary>
        /// <param name="dayMenu"></param>
        /// <param name="dish"></param>
        public void AddDishToOrderAsync(DateTime date, Dish dish)
        {
            Order order = OrderList.Find(o => o.Date == date);
            if (order == null)
            {
                int maxId;
                if (OrderList.Count == 0)
                {
                    maxId = 0;
                }
                else
                {
                    maxId = OrderList.Max(order => order.Id);
                }
                order = new Order
                {
                    Id = maxId + 1,
                    Date = date,
                    UserId = "demo_user",
                    Total = dish.Price,
                    EatingAreaId = 0,
                    Dishes = new List<Dish>()
                };
                order.Dishes.Add(dish);
                order.Status = OrderStatus.Created;
                OrderList.Add(order);
            }
            else
            {
                if (order.Dishes == null)
                {
                    order.Dishes = new List<Dish>();
                }
                order.Dishes.Add(dish);
                order.Status = OrderStatus.Created;
                order.Total += dish.Price;
            }
        }

        /// <summary>
        /// Сохранить заказы в файле.
        /// </summary>
        public void SaveOrdersAsync()
        {
            string filePath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                FileName);
            var json = System.Text.Json.JsonSerializer.Serialize<List<Order>>(OrderList);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Загрузить заказы из файла.
        /// </summary>
        public async Task LoadOrdersAsync()
        {
            string filePath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                FileName);
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var orderList = System.Text.Json.JsonSerializer.Deserialize<IList<Order>>(json);
                if (orderList != null)
                {
                    OrderList = new List<Order>(orderList);
                }
            }
            return;
        }

        /// <summary>
        /// Очистить историю заказов
        /// </summary>
        /// <returns>нет</returns>
        public async Task ClearOrderHistoryAsync()
        {
            OrderList.Clear();
        }

        /// <summary>
        /// Получить текущие заказы пользователя
        /// </summary>
        /// <returns>Списрок текущих заказов пользователя</returns>
        public async Task<List<Order>> GetOrdersAsync(DateTime startDate, int userId = 1)
        {
            var orders = OrderList
                .Where(it => it.Date.Date >= startDate.Date)
                .ToList();
            return orders;
        }

        public async Task<List<Order>> GetAllOrdersAsync(int userID = 1)
        {
            return OrderList;
        }
        #endregion Операции с заказами
    }
}
