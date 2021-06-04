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

        private string _selectedMode;

        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (SetProperty(ref _selectedMode, value))
                {
                    SelectMode(_selectedMode);
                };
            }
        }

        public Command ContinueCommand { get; }

        public SelectModeViewModel(SelectModePage page)
        {
            this.page = page;

            Title = @"Выбор режима демонстрации";

            ContinueCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//CurrentMenu");
            });
        }

        private async void SelectMode(string mode)
        {
            switch (mode)
            {
                case "Local Demo":
                    await page.DisplayAlert(@"РЕЖИМ ДЕМО!", 
                        @"Вы выбрали режим ЛОКАЛЛЬНОЙ демонстрации!", @"Ok");
                    DependencyService.Register<ICanteenService, CanteenDemoService>();

                    break;
                case "Network Demo":
                    await page.DisplayAlert(@"РЕЖИМ ДЕМО!",
                        @"Вы выбрали режим СЕТЕВОЙ демонстрации!", @"Ok");
                    DependencyService.Register<ICanteenService, CanteenDemoService>();
                    break;
                default: // недопустимое значение
                    break;
            }
        }
    }
}
