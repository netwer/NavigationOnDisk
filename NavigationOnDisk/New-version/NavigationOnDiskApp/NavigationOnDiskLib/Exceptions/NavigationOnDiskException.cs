using System;

namespace NavigationOnDiskProjectLib.Exceptions
{
    /// <summary>
    ///     NavigationOnDisk Exception
    /// </summary>
    public class NavigationOnDiskException : Exception
    {
        public NavigationOnDiskException()
        {
        }

        public NavigationOnDiskException(string message)
            : base(message)
        {
        }

        public NavigationOnDiskException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
