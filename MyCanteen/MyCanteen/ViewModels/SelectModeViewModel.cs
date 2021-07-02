using MyCanteen.Services;
using MyCanteen.Services.Interfaces;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    public class SelectModeViewModel :BaseViewModel
    {
        private readonly SelectModePage page;

        string NextPage;

        private string _selectedMode;

        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (SetProperty(ref _selectedMode, value))
                {
                    SelectMode(_selectedMode);
                    ContinueCommand.ChangeCanExecute();
                };
            }
        }

        public Command ContinueCommand { get; }

        public SelectModeViewModel(SelectModePage page)
        {
            this.page = page;

            Title = @"Выбор режима демонстрации";

            ContinueCommand = new Command(
                async () => await Shell.Current.GoToAsync(NextPage),
                () => !string.IsNullOrEmpty(_selectedMode)
             );
        }

        private void SelectMode(string mode)
        {
            var svc = DependencyService.Get<ICanteenService>();
            switch (mode)
            {
                case "Local Demo":
                    //await page.DisplayAlert(@"РЕЖИМ ДЕМО!", 
                    //    @"Вы выбрали режим ЛОКАЛЬНОЙ демонстрации!", @"Ok");
                    if (!(svc is CanteenDemoService))
                    {
                        DependencyService.Register<ICanteenService, CanteenDemoService>();
                    }
                    NextPage = @"//CurrentMenu";
                    break;
                case "Network Demo":
                    //await page.DisplayAlert(@"РЕЖИМ ДЕМО!",
                    //    @"Вы выбрали режим СЕТЕВОЙ демонстрации!", @"Ok", @"Not");
                    if (!(svc is CanteenService))
                    {
                        DependencyService.Register<ICanteenService, CanteenService>();
                    }
                    NextPage = @"//LoginPage";
                    break;
                default: // недопустимое значение
                    break;
            }
        }
    }
}
