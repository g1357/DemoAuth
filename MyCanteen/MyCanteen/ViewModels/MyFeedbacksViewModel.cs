﻿using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    /// <summary>
    /// Модель представления моих отзывов
    /// </summary>
    public class MyFeedbacksViewModel : BaseViewModel
    {
        MyFeedbacksPage _page;

        public MyFeedbacksViewModel(MyFeedbacksPage page)
        {
            _page = page;
        }
    }
}
