using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebApiMobileClient.Helpers
{
    /// <summary>
    /// Обобщённый класс группы списка.
    /// Используется как элемент полного списка группировки.
    /// </summary>
    /// <typeparam name="K">Тип ключа группировки</typeparam>
    /// <typeparam name="T">Тип данных элементов списка</typeparam>
    public class Grouping<K, T> : ObservableCollection<T>
    {
        /// <summary>
        /// Ключ группы
        /// </summary>
        public K Key { get; private set; }

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="key">Ключ группы</param>
        /// <param name="items">Список элементов группы</param>
        public Grouping(K key, IEnumerable<T> items)
        {
            // Устанавливаем ключ группы
            Key = key;
            // Заполняем лементы группы
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
