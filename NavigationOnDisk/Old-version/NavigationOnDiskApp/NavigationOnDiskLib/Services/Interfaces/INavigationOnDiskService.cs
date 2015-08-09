using System.Collections.Generic;
using NavigationOnDiskModel.FileSystem;

namespace NavigationOnDiskLib.Services.Interfaces
{
    /// <summary>
    /// Interface INavigationOnDiskService
    /// </summary>
    public interface INavigationOnDiskService
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        List<Item> GetItems(string path);

        /// <summary>
        /// Gets the file information.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        FileItem GetFileInfo(string path);

        /// <summary>
        /// Determines whether the specified item is file.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        bool IsFile(Item item);
    }
}
