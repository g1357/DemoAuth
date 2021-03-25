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

        private bool? answer = null;

        override protected bool OnBackButtonPressed()
        {
            var res = vm.Method1();

            return res;

            //var answer = DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда! Выйти из приложения", "Yes", "No")
            //    .GetAwaiter().GetResult();
            //return !answer;
            //var t = await DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда!", "Ok");
            //t.Result;
            //Debug.WriteLine($"Result before call = {_myRes}.");
            //MyResult2();
            //Debug.WriteLine($"Result after call = {_myRes}.");
            //return _myRes;
            // bool answer;
            // var task = Task<bool>.Run(() =>
            //{
            //    bool answer = false;
            //Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        var ans = await DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда! Выйти из приложения", "Yes", "No");
            //        answer = ans;
            //    });
            //while(answer == null)
            //{

            //}
            //return (bool)answer;
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

        private bool _myRes = true;
        private async Task<bool> MyResult()
        {
            var result = await DisplayAlert("ВНИММАНИЕ!", "Возвращаться некуда!", "Ok", "Cancel");
            _myRes = result;
            return result;
        }

        private async void MyResult2()
        {
            var result = await MyResult();
            _myRes = result;
        }
    }
}