using System.Collections.Generic;
using System.Windows.Input;
using NavigationOnDiskLib.Services.Interfaces;
using NavigationOnDiskModel.FileSystem;

namespace NavigationOnDiskApp.ViewModel
{
    /// <summary>
    /// ViewModel
    /// </summary>
    public class NavigationOnDiskViewModel : ObservableObject
    {
        #region Private Fields

        private readonly INavigationOnDiskService _navigationOnDiskService;
        private List<Item> _items;
        private string _name;
        private string _path;
        private string _type;
        private string _extension;
        private string _size;

        #endregion

        #region Ctors

        public NavigationOnDiskViewModel()
        {

        }

        public NavigationOnDiskViewModel(INavigationOnDiskService navigationOnDiskService)
        {
            _navigationOnDiskService = navigationOnDiskService;
        }

        #endregion

        #region Fields

        public List<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                OnPropertyChanged("Extension");
            }
        }

        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        #endregion

        #region Commands

        public ICommand GetItemsCommand
        {
            get { return new DelegateCommand(GetItems); }
        }

        private void GetItems()
        {
            Items = _navigationOnDiskService.GetItems(@"C:/");
        }

        public ICommand GetItemInfoCommand
        {
            get { return new DelegateCommand(GetItemInfo); }
        }

        private void GetItemInfo()
        {
            var itemInfo = _navigationOnDiskService.GetFileInfo(@"C:\DRIVERS\WIN\43142WLAN\Setup.exe");
            Name = itemInfo.Name;
            Path = itemInfo.Path;
        }

        #endregion
    }
}
