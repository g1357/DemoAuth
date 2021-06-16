using MyCanteen.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCanteen.Services.Interfaces
{
    public interface ICanteenService
    {
        public List<DishType> GetDishTypesAsync();

        /// <summary>
        /// Получение полного меню.
        /// </summary>
        /// <returns>Полный список блюд</returns>
        public List<Dish> GetFullMenuAsync();

        /// <summary>
        /// Получение списка идентификаторов текущего меню
        /// </summary>
        /// <returns>Список идентификаторов дневных меню</returns>
        public IList<DayMenuDTO> GetCurrentMenuAsync();

        public List<int> GetDishIdListAsync(int dayMenuId);

        public Dish GetDishByIdAsync(int dishId);

        /// <summary>
        /// Полочение дневного меню по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор дневного меню</param>
        /// <returns>Дневное меню</returns>
        public DayMenuDTO GetDayMenuAsync(int id);

        /// <summary>
        /// Получить текущий список меню и заказов
        /// (на теущую неделю)
        /// </summary>
        /// <returns>Подневный список пар менюБ заказ.</returns>
        public Task<List<MenuOrder>> GetMenuOrderListCurrentAsync();

        /// <summary>
        /// Получить следующий список меню и заказов
        /// (на следующую неделю)
        /// </summary>
        /// <returns>Подневный список пар менюБ заказ.</returns>
        public Task<List<MenuOrder>> GetMenuOrderListNextAsync();

        #region Операции с заказами
        /// <summary>
        /// Получмить состояние заказа на указанную ждату
        /// </summary>
        /// <param name="date">дата</param>
        public OrderStatus GetOrderStatusAsync(DateTime date);

        /// <summary>
        /// Получить детальную информацию о заказе на заданную дату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Заказ</returns>
        public Order GetOrderAsync(DateTime date);

        /// <summary>
        /// Добавить блюдо к заказу на указанную дату.
        /// </summary>
        /// <param name="dayMenu"></param>
        /// <param name="dish"></param>
        public void AddDishToOrderAsync(DateTime date, Dish dish);

        /// <summary>
        /// Сохранить заказы в файле.
        /// </summary>
        public void SaveOrdersAsync();

        /// <summary>
        /// Загрузить заказы из файла.
        /// </summary>
        public Task LoadOrdersAsync();

        /// <summary>
        /// Очистить историю заказов
        /// </summary>
        /// <returns>нет</returns>
        public Task ClearOrderHistoryAsync();

        /// <summary>
        /// Получить текущие заказы пользователя
        /// </summary>
        /// <returns>Списрок текущих заказов пользователя</returns>
        public Task<List<Order>> GetOrdersAsync(DateTime startDate, int userId = 1);

        public Task<List<Order>> GetAllOrdersAsync(int userID = 1);

        #endregion Операции с заказами
    }
}
