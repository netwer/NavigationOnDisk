namespace NavigationOnDiskModel.FileSystem
{
    /// <summary>
    /// File
    /// </summary>
    public class FileItem : Item
    {
        public string Extension { get; set; }
        public long Size { get; set; }
    }
}
