using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmDialogs;
using NavigationOnDiskProjectLib.Exceptions;
using NavigationOnDiskProjectLib.Services.Interfaces;
using NavigationOnDiskProjectModel.FileSystem;

namespace NavigationOnDiskProject.ViewModel
{
    /// <summary>
    /// ViewModel
    /// </summary>
    public class NavigationOnDiskViewModel : ViewModelBase
    {
        #region Ctors

        public NavigationOnDiskViewModel(IDialogService dialogService, INavigationOnDiskService navigationOnDiskService)
        {
            _dialogService = dialogService;
            _navigationOnDiskService = navigationOnDiskService;
            Items = new ObservableCollection<Item>(
                Directory.GetLogicalDrives().Select(x => new Item {
                                                                        Name = x,
                                                                        Path = x,
                                                                        Children = new ObservableCollection<Item> {new Item()}
                                                                  }));
            Messenger.Default.Register<Item>(this, item =>
            {
                Name = item.Name;
                Path = (item.Path.Length > 30) ? string.Format("...{0}", item.Path.Substring(item.Path.Length - 30, 30)) : item.Path;
                Type = item.ItemType.ToString();
                Size = item is FileItem ? ((FileItem)item).Size.ToString(CultureInfo.InvariantCulture) : "";
                Extension = item is FileItem ? ((FileItem)item).Extension : "";
            });
        }
        
        #endregion

        #region Private Fields

        private readonly INavigationOnDiskService _navigationOnDiskService;
        private ObservableCollection<Item> _items;
        private string _name;
        private string _path;
        private string _type;
        private string _extension;
        private string _size;
        private bool _isExpanded;
        private bool _isSelected;
        private readonly IDialogService _dialogService;

        #endregion

        #region Fields

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { Set(() => IsExpanded, ref _isExpanded, value); }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(() => IsSelected, ref _isSelected, value); }
        }

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { Set(() => Items, ref _items, value); }
        }

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        public string Path
        {
            get { return _path; }
            set { Set(() => Path, ref _path, value); }
        }

        public string Type
        {
            get { return _type; }
            set { Set(() => Type, ref _type, value); }
        }

        public string Extension
        {
            get { return _extension; }
            set { Set(() => Extension, ref _extension, value); }
        }

        public string Size
        {
            get { return _size; }
            set { Set(() => Size, ref _size, value); }
        }

        #endregion

        #region Commands

        public RelayCommand<Item> GetItemsCommand
        {
            get { return new RelayCommand<Item>(GetItems); }
        }
        
        private void GetItems(Item item)
        {
            try
            {
                if (item.ItemType == ItemType.Directory)
                {
                    item.Children.RemoveAt(0);
                    _navigationOnDiskService.GetItems(item.Path).ForEach(x => item.Children.Add(x));
                }

                Messenger.Default.Send(item);
            }
            catch (NavigationOnDiskException e)
            {
                _dialogService.ShowMessageBox(this, e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                _dialogService.ShowMessageBox(this, e.Message);
            }
            catch (TargetInvocationException e)
            {
                _dialogService.ShowMessageBox(this, e.Message);
            }
            
        }

        #endregion
    }
}
