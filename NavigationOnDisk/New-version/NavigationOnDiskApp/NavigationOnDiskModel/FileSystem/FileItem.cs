namespace NavigationOnDiskProjectModel.FileSystem
{
    /// <summary>
    ///     File
    /// </summary>
    public class FileItem : Item
    {
        public FileItem(string name, string path, string extension, double size)
        {
            Name = name;
            Path = path;
            Extension = extension;
            Size = size;
            ItemType = ItemType.File;
        }

        public string Extension { get; private set; }
        public double Size { get; private set; }
    }
}
