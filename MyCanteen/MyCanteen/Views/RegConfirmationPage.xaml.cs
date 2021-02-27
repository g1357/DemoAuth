using MyCanteen.Services;
using MyCanteen.ViewModels;
using System;
using System.Collections.Generic;
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
        public RegConfirmationPage()
        {
            InitializeComponent();

            var usersService = DependencyService.Get<IUsersService>();
            var vm = new RegConfirmationViewModel(usersService, this);
            BindingContext = vm;
        }

        public RegConfirmationPage(long id)
        {
            InitializeComponent();

            var usersService = DependencyService.Get<IUsersService>();
            var vm = new RegConfirmationViewModel(usersService, this);
            BindingContext = vm;

        }

        override protected bool OnBackButtonPressed()
        {
            //var answer = DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда! Выйти из приложения", "Yes", "No")
            //    .GetAwaiter().GetResult();
            //return !answer;
            DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда!", "Ok");
            return true;
            // bool answer;
            // var task = Task<bool>.Run(() =>
            //{
            //    bool answer = false;
            //Device.BeginInvokeOnMainThread(async () =>
           //    {
           //        var ans = await DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда! Выйти из приложения", "Yes", "No");
           //        answer = ans;
           //    });
           //    return answer;
           //});
           // answer = task.Result;
           // return !answer;
            //var answer = new Task<bool>.Run(async () =>
            //{
            //    return await DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда! Выйти из приложения", "Yes", "No");
            //}).Result;
            //return !answer;
            //var task = DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда! Выйти из приложения", "Yes", "No").RunSynchronously();
            //task.Wait();
            //return !task.Result;
        }

    }
}