using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApiMobileClient.Models;
using WebApiMobileClient.Services;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly WebApiService _webApiService = new WebApiService();

        private string _email;
        public string Email
        { 
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        private string _token;
        public string Token
        {
            get => _token;
            set => SetProperty(ref _token,value);
        }
        public ICommand LoginCommand => new Command(async () =>
        {
            Token = string.Empty;
            LoginDTO LoginData = new LoginDTO
            {
                Email = Email,
                Password = Password
            };
            var accesstoken = await _webApiService.LoginAsync(LoginData);
            App.Current.Properties["UserName"] = LoginData.Email;
            App.Current.Properties["Password"] = LoginData.Password;
            App.Current.Properties["AccessToken"] = accesstoken;
            Token = accesstoken;
            if (string.IsNullOrEmpty(Token))
            {
                Message = "Токен НЕ получен!";
            }
            else
            {
                Message = "Токен получен!";
            }
        });

        public LoginViewModel()
        {
            if (App.Current.Properties.TryGetValue("UserName", out object value))
            {
                Email = (string)value;
            }
            else
            {
                Email = "ahmad@gmail.com"; // string.Empty;
            }
            if (App.Current.Properties.TryGetValue("Password", out value))
            {
                Password = (string)value;
            }
            else
            {
                Password = "Ahmad@123"; // string.Empty;
            }

        }
    }
}
