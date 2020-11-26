using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    class MainMenuViewModel : BaseViewModel
    {
        private ContentPage _page;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ICommand CurrentMenuCommand => new Command(async () =>
        {
            await _page.Navigation.PushAsync(new CurrentMenuPage());
            Message = "Было выбрано текущее меню.";
        });
        public ICommand CurrentMenu2Command => new Command(async () =>
        {
            await _page.Navigation.PushAsync(new CurrentMenu2Page());
            Message = "Было выбрано текущее меню 2 (с Заказами).";
        });
        public ICommand FullMenuCommand => new Command(async () =>
        {
            await _page.Navigation.PushAsync(new FullMenuPage());
            Message = "Было выбрано полное меню.";
        });
        public ICommand FullMenuGroupedCommand => new Command(async () =>
        {
            await _page.Navigation.PushAsync(new FullMenuGroupedPage());
            Message = "Было выбрано полное меню с группировкой.";
        });
        public ICommand SettingsCommand => new Command(async () =>
        {
            var vm = new SettingsViewModel();
            var page = new SettingsPage();
            page.BindingContext = vm;
            await _page.Navigation.PushAsync(page);
            Message = "Было выбрано: Настройки приложения.";
        });

        public MainMenuViewModel(ContentPage page)
        {
            _page = page;
        }
    }
}
