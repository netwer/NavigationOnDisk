using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NavigationOnDiskLib.Exceptions;
using NavigationOnDiskLib.Services.Interfaces;
using NavigationOnDiskModel.FileSystem;

namespace NavigationOnDiskLib.Services.Implementations
{
    /// <summary>
    /// Implementation INavigationOnDiskService
    /// </summary>
    public class NavigationOnDiskService : INavigationOnDiskService
    {
        public List<Item> GetItems(string path)
        {
            try
            {
                if(String.IsNullOrEmpty(path))
                    throw new NavigationOnDiskException("Path is null.");

                var directoryInfo = new DirectoryInfo(path);
                var items = directoryInfo.GetDirectories().Select(dir => new DirectoryItem
                {
                    Name = dir.Name, Path = dir.FullName, ItemType = ItemType.Directory
                }).Cast<Item>().ToList();
                items.AddRange(directoryInfo.GetFiles().Select(file => new FileItem
                {
                    Name = file.Name, Path = file.FullName, Extension = Path.GetExtension(file.FullName), Size = new FileInfo(file.FullName).Length, ItemType = ItemType.File
                }).Cast<Item>().ToList());

                return items;
            }
            catch (UnauthorizedAccessException e)
            {
                throw e;
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
        }

        public FileItem GetFileInfo(string path)
        {
            if (String.IsNullOrEmpty(path))
                throw new NavigationOnDiskException("Path is null.");

            var file = new FileItem
            {
                Path = path,
                Name = Path.GetFileName(path),
                Extension = Path.GetExtension(path),
                ItemType = ItemType.File,
                Size = new FileInfo(path).Length
            };

            return file;
        }

        public bool IsFile(Item item)
        {
            if (item == null)
                throw new NavigationOnDiskException("Item is null.");

            return item.ItemType == ItemType.File;
        }
    }
}
