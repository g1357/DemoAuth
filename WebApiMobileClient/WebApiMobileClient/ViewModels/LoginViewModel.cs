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

        public LoginDTO LoginData { get; set; } = new LoginDTO();
        public ICommand LoginCommand => new Command(async () =>
        {
            var accesstoken = await _webApiService.LoginAsync(LoginData);
            App.Current.Properties["UserName"] = LoginData.UserName;
            App.Current.Properties["Password"] = LoginData.Password;
            App.Current.Properties["AccessToken"] = accesstoken;
        });

        public LoginViewModel()
        {
            if (App.Current.Properties.TryGetValue("UserName", out object value))
            {
                LoginData.UserName = (string)value;
            }
            else
            {
                LoginData.UserName = "ahmad@gmail.com"; // string.Empty;
            }
            if (App.Current.Properties.TryGetValue("Password", out value))
            {
                LoginData.Password = (string)value;
            }
            else
            {
                LoginData.Password = "Ahmad@123"; // string.Empty;
            }

        }
    }
}
