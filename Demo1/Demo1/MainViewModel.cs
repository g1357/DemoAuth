using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

namespace Demo1
{
    public class MainViewModel
    {
        public ObservableCollection<A> lst { get; set; }
        public MainViewModel()
        {
            var lst1 = new ObservableCollection<A>()
            {
                new A()
                {
                    ItemName = "Item 1",
                    ItemList = new ObservableCollection<ItemDetails>()
                    {
                        new ItemDetails() { stockQty = "2"},
                        new ItemDetails() { stockQty = "3"}
                    }
                },
                 new A()
                {
                    ItemName = "Item 2",
                    ItemList = new ObservableCollection<ItemDetails>()
                    {
                        new ItemDetails() { stockQty = "3"},
                        new ItemDetails() { stockQty = "4"}
                    }
                },
           };
            lst = lst1;
        }

    }
}
