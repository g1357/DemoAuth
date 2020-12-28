using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления полного меню
    /// </summary>
    public class FullMenuViewModel : BaseViewModel
    {
        FullMenuPage _page;

        public FullMenuViewModel(FullMenuPage page)
        {
            _page = page;
        }
    }
}
