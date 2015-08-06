namespace NavigationOnDiskModel.FileSystem
{
    /// <summary>
    /// Base class
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ItemType ItemType { get; set; }
    }
}
