using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления истории заказов
    /// </summary>
    public class OrderHistoryViewModel : BaseViewModel
    {
        OrderHistoryPage _page;

        public OrderHistoryViewModel(OrderHistoryPage page)
        {
            _page = page;
        }
    }
}
