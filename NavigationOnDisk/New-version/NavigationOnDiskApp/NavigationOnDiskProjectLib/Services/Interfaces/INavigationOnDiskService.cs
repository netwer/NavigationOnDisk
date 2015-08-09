using System.Collections.Generic;
using NavigationOnDiskProjectModel.FileSystem;

namespace NavigationOnDiskProjectLib.Services.Interfaces
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
    }
}
