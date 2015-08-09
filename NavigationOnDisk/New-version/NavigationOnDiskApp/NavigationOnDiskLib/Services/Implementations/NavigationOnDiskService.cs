using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using NavigationOnDiskProjectLib.Exceptions;
using NavigationOnDiskProjectLib.Services.Interfaces;
using NavigationOnDiskProjectModel.FileSystem;

namespace NavigationOnDiskProjectLib.Services.Implementations
{
    /// <summary>
    /// Implementation INavigationOnDiskService
    /// </summary>
    public class NavigationOnDiskService : INavigationOnDiskService
    {
        public List<Item> GetItems(string path)
        {
            if (String.IsNullOrEmpty(path))
                throw new NavigationOnDiskException("Path is null.");

            var directoryInfo = new DirectoryInfo(path);
            var items = new List<Item>();

            items.AddRange(directoryInfo.GetDirectories().Select(dir => new DirectoryItem
            {
                Name = dir.Name,
                Path = dir.FullName,
                ItemType = ItemType.Directory,
                Children = new ObservableCollection<Item> { new Item() }
            }));

            items.AddRange(directoryInfo.GetFiles().Select(
                file => new FileItem(
                        file.Name,
                        file.FullName,
                        Path.GetExtension(file.FullName),
                        new FileInfo(file.FullName).Length / 1024d / 1024d)
                        ));
            return items;
        }
    }
}
