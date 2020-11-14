using System;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demo1
{
    public class A : INotifyPropertyChanged
    {
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ItemDetails> _itemlist;
        public ObservableCollection<ItemDetails> ItemList
        {
            get { return _itemlist; }
            set
            {
                _itemlist = value; OnPropertyChanged();
            }
        }

        public A()
        {
            ItemName = string.Empty;
            ItemList = new ObservableCollection<ItemDetails>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ItemDetails : INotifyPropertyChanged
    {
        private string _stockQty;
        public string stockQty
        {
            get { return _stockQty; }
            set { _stockQty = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

    }
}