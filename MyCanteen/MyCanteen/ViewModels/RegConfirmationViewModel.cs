using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

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

        public RegConfirmationViewModel(IUsersService usersService, RegConfirmationPage page)
        {
            this.usersService = usersService;
            this.page = page;

        }
    }
}
