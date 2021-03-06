﻿using MyCanteen.Helpers;
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

        private string login = @"aaa@aaa.aaa";

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        private string password = @"aaa";

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

        private string errorMessage = "Login or password is incorrect!";

        public string ErrorMessage
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
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
            IsBusy = true;
            //var user = await usersService.Login(new LoginModel { 
            //    Email = Login,
            //    Password = Password
            //});
            var (user, message) = await usersService.Login2(new LoginModel
            {
                Email = Login,
                Password = Password
            });
            IsBusy = false;
            if (user != null)
            {
                // Go to Welcome page
                await page.DisplayAlert("Enter", $"Welcome to MyCanteen Service!", "Ok");
                // Сохраняем данные пользователя в приложении (кроме пароля)
                Settings.CurrentUser = user;
                // Переходим к начальной странице
                //await Shell.Current.GoToAsync("//CurrentMenu");
                await Shell.Current.GoToAsync("//AllUsers");
            }
            else
            {
               ErrorMessage = message;
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
