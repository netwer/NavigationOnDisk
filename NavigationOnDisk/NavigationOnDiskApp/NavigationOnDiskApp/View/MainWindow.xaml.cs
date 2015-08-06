using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using NavigationOnDiskApp.ViewModel;
using NavigationOnDiskLib.Exceptions;
using NavigationOnDiskLib.Services.Implementations;
using NavigationOnDiskLib.Services.Interfaces;
using NavigationOnDiskModel.FileSystem;

namespace NavigationOnDiskApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /*private readonly INavigationOnDiskService _navigationOnDiskService;
        private readonly NavigationOnDiskViewModel _navigationOnDiskViewModel;

        public MainWindow(INavigationOnDiskService navigationOnDiskService, NavigationOnDiskViewModel navigationOnDiskViewModel)
        {
            _navigationOnDiskService = navigationOnDiskService;
            _navigationOnDiskViewModel = navigationOnDiskViewModel;
            InitializeComponent();
         * MainUserControl view1 = new MainUserControl(new NavigationOnDiskService(), new NavigationOnDiskViewModel());
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var localCItem = new Item
            {
                Name = @"C:\",
                Path = @"C:\",
                ItemType = ItemType.LogicalDisk
            };

            var item = new TreeViewItem
            {
                Header = @"C:\",
                Tag = localCItem,
                FontWeight = FontWeights.Normal
            };
            item.Items.Add(null);
            item.Expanded += new RoutedEventHandler(FolderExpanded);
            FoldersItem.Items.Add(item);
        }

        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemTree = (TreeViewItem) sender;
                var currentItem = (Item) itemTree.Tag;
                var items = _navigationOnDiskService.GetItems(currentItem.Path);
                
                if (itemTree.Items.Count != 1 || itemTree.Items[0] != null) return;
                
                itemTree.Items.Clear();

                foreach (var item in items)
                {
                    var subitem = new TreeViewItem
                    {
                        Header = item.Name,
                        Tag = item,
                        FontWeight = FontWeights.Normal
                    };
                    if (!_navigationOnDiskService.IsFile(item))
                    {
                        subitem.Items.Add(null);
                        subitem.Expanded += new RoutedEventHandler(FolderExpanded);
                    }
                    itemTree.Items.Add(subitem);
                }
            }
            catch (NavigationOnDiskException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (UnauthorizedAccessException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (DirectoryNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
            }            
        }
        
        private void FoldersItem_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var itemTree = (TreeView)sender;
            var itemTree1 = (TreeViewItem)itemTree.SelectedItem;
            var currentItem = (Item)itemTree1.Tag;

            _navigationOnDiskViewModel.Name = currentItem.Name;
            var bindindName = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Name"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            this.TbName.SetBinding(TextBlock.TextProperty, bindindName).UpdateSource();

            _navigationOnDiskViewModel.Path = (currentItem.Path.Length > 30) ? "..." + currentItem.Path.Substring(currentItem.Path.Length - 30, 30) : currentItem.Path;
            var bindingPath = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Path") };
            this.TbPath.SetBinding(TextBlock.TextProperty, bindingPath);

            if (!_navigationOnDiskService.IsFile(currentItem))
            {
                _navigationOnDiskViewModel.Type = ItemType.Directory.ToString();
                var bindingType = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Type") };
                this.TbType.SetBinding(TextBlock.TextProperty, bindingType);

                _navigationOnDiskViewModel.Extension = "";
                var bindingExtension = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Extension") };
                this.TbExtension.SetBinding(TextBlock.TextProperty, bindingExtension);

                _navigationOnDiskViewModel.Size = "";
                var bindingSize = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Size") };
                this.TbSize.SetBinding(TextBlock.TextProperty, bindingSize);
            }
            else
            {
                _navigationOnDiskViewModel.Type = ItemType.File.ToString();
                var bindingType = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Type") };
                this.TbType.SetBinding(TextBlock.TextProperty, bindingType);
                FileItem fileItem;
                try
                {
                    fileItem = _navigationOnDiskService.GetFileInfo(currentItem.Path);
                }
                catch (NavigationOnDiskException exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }

                _navigationOnDiskViewModel.Extension = fileItem.Extension;
                var bindingExtension = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Extension") };
                this.TbExtension.SetBinding(TextBlock.TextProperty, bindingExtension);

                _navigationOnDiskViewModel.Size = (fileItem.Size/1024f/1024f).ToString(CultureInfo.InvariantCulture);
                var bindingSize = new Binding { Source = _navigationOnDiskViewModel, Path = new PropertyPath("Size") };
                this.TbSize.SetBinding(TextBlock.TextProperty, bindingSize);
            }
        }*/
    }
}
