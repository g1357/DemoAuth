using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления новостей
    /// </summary>
    public class NewsViewModel :BaseViewModel
    {
        NewsPage _page;

        public NewsViewModel(NewsPage page)
        {
            _page = page;
        }
    }
}
