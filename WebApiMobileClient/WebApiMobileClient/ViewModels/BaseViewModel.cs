using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApiMobileClient.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanging
    {

        public event PropertyChangingEventHandler PropertyChanging;
    }
}
