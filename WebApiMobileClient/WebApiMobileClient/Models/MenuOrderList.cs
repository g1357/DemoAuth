using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebApiMobileClient.Models
{
    public class MenuOrderList
    {
        public ObservableCollection<MenuOrder> WeekList { get; set; }
        public bool MenuVisible => WeekList != null; 
        public bool MsgVisible => WeekList == null;
    }
}
