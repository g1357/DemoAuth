using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCanteen.Services;
using MyCanteen.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel vm;
        public LoginPage()
        {
            InitializeComponent();

            var usersService = DependencyService.Get<IUsersService>();
            vm = new LoginViewModel(usersService, this);
            BindingContext = vm;
        }
    }
}