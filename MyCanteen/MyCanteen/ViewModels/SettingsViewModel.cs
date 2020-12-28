using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления настроек программы.
    /// </summary>
    public class SettingsViewModel
    {
        // Страница данной модели представления
        SettingsPage _page;
        // Сервис
        CanteenDemoService _canteenService;

        /// <summary>
        /// Команда удаления истории заказов
        /// </summary>
        public ICommand ClearOrderHistoryCommand => new Command(async () =>
        {
            var result = await _page.DisplayAlert("Удаление истории заказов",
                "Вы действительно хотите очистить историю Ваших заказов?",
                "Да", "Нет");
            if (result)
            {
                await _canteenService.ClearOrderHistoryAsync();
                MessagingCenter.Send<SettingsViewModel>(this, "Refresh Order");
            }
        });

        /// <summary>
        /// Конструктор модели представления Текущего меню
        /// </summary>
        /// <param name="page">Связанная страница (представление)</param>
        public SettingsViewModel(SettingsPage page)
        {
            _page = page;
            _canteenService = DependencyService.Get<CanteenDemoService>();

        }
    }
}
