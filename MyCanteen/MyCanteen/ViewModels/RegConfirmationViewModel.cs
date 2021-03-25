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
    /// Модель представления подтверждения регистрации.
    /// Подтверждение электронной почты.
    /// </summary>
    public class RegConfirmationViewModel : BaseViewModel
    {
        private readonly IUsersService usersService;

        private readonly RegConfirmationPage page;

        public ICommand NextCommand { get; }

        public RegConfirmationViewModel(IUsersService usersService, RegConfirmationPage page)
        {
            this.usersService = usersService;
            this.page = page;

            NextCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//LoginPage");
            });
        }

        public bool Method1()
        {
            var t = page.DisplayAlert("MESSAGE", "Hello!", "OK", "Cancel");
            return t.Result;
        }
    }
}
