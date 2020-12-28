using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления формы напискать отзыв
    /// </summary>
    public class WriteFeedbackViewModel : BaseViewModel
    {
        WriteFeedbackPage _page;

        public WriteFeedbackViewModel(WriteFeedbackPage page)
        {
            _page = page;
        }
    }
}
