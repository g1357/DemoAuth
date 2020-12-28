using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления показа всех отзывов
    /// </summary>
    public class AllFeedbacksViewModel : BaseViewModel
    {
        AllFeedbacksPage _page;

        public AllFeedbacksViewModel(AllFeedbacksPage page)
        {
            _page = page;
        }
    }
}
