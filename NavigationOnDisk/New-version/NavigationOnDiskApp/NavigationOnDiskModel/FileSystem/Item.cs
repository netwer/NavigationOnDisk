using System.Collections.ObjectModel;

namespace NavigationOnDiskProjectModel.FileSystem
{
    /// <summary>
    ///     Base class
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ItemType ItemType { get; set; }
        public ObservableCollection<Item> Children { get; set; }
    }
}
