using System.Collections.Generic;

namespace NavigationOnDiskModel.FileSystem
{
    /// <summary>
    /// Directory
    /// </summary>
    public class DirectoryItem : Item
    {
        public List<Item> Items { get; set; }
    }
}
