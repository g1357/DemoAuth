using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        AppShell page;
        public Command LoginCommand { get; set; }
        public AppShellViewModel(AppShell page )
        {
            this.page = page;

            LoginCommand = new Command(Login);
        }

        private async void Login(object obj)
        {
            //var usersService = DependencyService.Get<IUsersService>();
            //var page = new LoginPage();
            //var vm = new LoginViewModel(usersService, page);
            //page.BindingContext = vm;
            ////await page.Navigation.PushAsync(page);
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
