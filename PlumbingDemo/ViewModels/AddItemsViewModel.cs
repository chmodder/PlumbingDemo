using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using PlumbingDemo.Annotations;

namespace PlumbingDemo
{
    class AddItemsViewModel : INotifyPropertyChanged
    {
        public AddItemsViewModel()
        {
            ListData = new ObservableCollection<string>() { "item 1", "Item 2", "Item 3" };
            AddItemCommand = new RelayCommand(DoAddItem);
            AddDefaultItemCommand = new RelayCommand(DoAddDefaultItem);
            RemoveItemCommand = new RelayCommand(DoRemoveAnItem);
            ClearListCommand = new RelayCommand(DoClearList);
        }

        private ObservableCollection<string> _listData;

        public ObservableCollection<string> ListData
        {
            get
            {
                return _listData;
            }

            set
            {
                _listData = value;
                OnPropertyChanged("ListData");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand AddItemCommand { get; set; }

        public RelayCommand RemoveItemCommand { get; set; }

        public RelayCommand ClearListCommand { get; set; }

        public RelayCommand AddDefaultItemCommand { get; set; }

        public void DoAddItem(object itemString)
        {
            var newItem = itemString as string;
            if (!string.IsNullOrEmpty(newItem))
            {
                _listData.Add(newItem);
            }
        }

        public void DoAddDefaultItem(object itemString)
        {
            _listData.Add("Item " + (_listData.Count + 1).ToString());
        }

        public void DoRemoveAnItem(object itemString)
        {
            var newItem = itemString as string;
            while (_listData.Contains(newItem))
            {
                ListData.Remove(newItem);
            }
        }

        public void DoClearList(object itemString)
        {
            ListData.Clear();
        }
    }
}
