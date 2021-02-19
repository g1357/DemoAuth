using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUsersService usersService;

        private readonly LoginPage page;

        private string login;

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        private string password;

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);

        }

        private bool isLoginInvalid;

        public bool IsLoginInvalid
        {
            get => isLoginInvalid;
            set => SetProperty(ref isLoginInvalid, value);
        }

        private bool isPasswordInvalid;

        public bool IsPasswordInvalid
        {
            get => isPasswordInvalid;
            set => SetProperty(ref isPasswordInvalid, value);
        }

        private bool isErrorVisible;

        public bool IsErrorVisible
        {
            get => isErrorVisible;
            set => SetProperty(ref isErrorVisible, value);
        }


        public Command SignInCommand { get; }
        public Command ValidateLoginCommand { get; }
        public Command ValidatePasswordCommand { get; }

        public LoginViewModel(IUsersService usersService, LoginPage page)
        {
            this.usersService = usersService;
            this.page = page;

            SignInCommand = new Command(SignIn, CanExecuteSignIn);
            ValidateLoginCommand = new Command(ValidateLogin,
                a => Login != null);
            ValidatePasswordCommand = new Command(ValidatePassword,
                a => Login != null);
        }

        private async void SignIn(object obj)
        {
            var user = await usersService.Login(new LoginModel { 
                Email = Login,
                Password = Password
            });
            if (user != null)
            {
                // Go to Welcome page
            }
            else
            {
                IsErrorVisible = true;
            }
        }

        private bool CanExecuteSignIn(object arg)
        {
            if (Login == null || Password == null)
            {
                return false;
            }
            if (!IsLoginInvalid && !IsPasswordInvalid)
            {
                return true;
            }
            return false;
        }
        private void ValidateLogin(object obj)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Login);

            IsLoginInvalid = !match.Success;
            SignInCommand.ChangeCanExecute(); //.RaiseCanExecuteChanged();
        }

        private void ValidatePassword(object obj)
        {
            IsPasswordInvalid = string.IsNullOrEmpty(Password);
            SignInCommand.ChangeCanExecute(); //.RaiseCanExecuteChanged();
        }
    }
}
