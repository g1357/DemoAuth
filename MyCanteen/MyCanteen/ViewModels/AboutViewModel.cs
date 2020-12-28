using MyCanteen.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        AboutPage _page;

        public ICommand OpenWebCommand { get; }

        public AboutViewModel(AboutPage page)
        {
            _page = page;

            Title = "About";
            OpenWebCommand = new Command(async () => 
                await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

    }
}