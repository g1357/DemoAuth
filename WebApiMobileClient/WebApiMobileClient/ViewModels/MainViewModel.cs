using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace WebApiMobileClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private MainPage _page;

        private ImageSource _photoSource;
        public ImageSource PhotoSource
        {
            get { return _photoSource; }
            set { SetProperty(ref _photoSource, value); }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public MainViewModel(MainPage page)
        {
            _page = page;
            PhotoSource = ImageSource.FromResource("WebApiMobileClient.Images.photo02.png",
                 typeof(MainViewModel).GetTypeInfo().Assembly);
            Message = "Test Message!";

        }
    }
}
