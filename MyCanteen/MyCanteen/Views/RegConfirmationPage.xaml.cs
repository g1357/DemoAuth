using MyCanteen.Services;
using MyCanteen.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegConfirmationPage : ContentPage
    {
        RegConfirmationViewModel vm;

        public RegConfirmationPage()
        {
            InitializeComponent();

            var usersService = DependencyService.Get<IUsersService>();
            vm = new RegConfirmationViewModel(usersService, this);
            BindingContext = vm;
        }

        public RegConfirmationPage(long id)
        {
            InitializeComponent();

            var usersService = DependencyService.Get<IUsersService>();
            var vm = new RegConfirmationViewModel(usersService, this);
            BindingContext = vm;

        }

        /// <summary>
        /// Обработка нажатия аппаратной клавиши"назад"
        /// </summary>
        /// <returns></returns>
        override protected bool OnBackButtonPressed()
        {
            DisplayAlert("Сообщение", "Возвращаться некуда. Для свёртывания приложения нажмите о", "Закрыть");
            return true; // Не сворачивать
        }

    }
}