using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationOnDiskLib.Exceptions;
using NavigationOnDiskLib.Services.Implementations;
using NavigationOnDiskLib.Services.Interfaces;

namespace NavigationOnDiskUnitTestProject
{
    [TestClass]
    public class NavigationOnDiskUnitTest
    {
        [TestMethod]
        public void NavigationOnDiskService_GetItems()
        {
            //arrange
            INavigationOnDiskService navigationOnDiskService = new NavigationOnDiskService();
            const string path = @"C:\";
            //act
            var items = navigationOnDiskService.GetItems(path);
            //assert
            Assert.IsNotNull(items);
        }

        [TestMethod]
        [ExpectedException(typeof(NavigationOnDiskException))]
        public void NavigationOnDiskService_GetItems_EmptyPath_Exception()
        {
            //arrange
            INavigationOnDiskService navigationOnDiskService = new NavigationOnDiskService();
            const string path = @"";
            //act
            var items = navigationOnDiskService.GetItems(path);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void NavigationOnDiskService_GetItems_UnauthorizedAccess_Exception()
        {
            //arrange
            INavigationOnDiskService navigationOnDiskService = new NavigationOnDiskService();
            const string path = @"C:\Documents and Settings";
            //act
            var items = navigationOnDiskService.GetItems(path);
            //assert
        }

        [TestMethod]
        public void NavigationOnDiskService_GetItems_Check_Return_Count()
        {
            //arrange
            INavigationOnDiskService navigationOnDiskService = new NavigationOnDiskService();
            const string path = @"C:\";
            //act
            var items = navigationOnDiskService.GetItems(path);
            var directories = new DirectoryInfo(path).GetDirectories();
            var files = new DirectoryInfo(path).GetFiles();
            //assert
            Assert.AreEqual(directories.Count() + files.Count(),items.Count);
        }

        [TestMethod]
        public void NavigationOnDiskService_GetGetFileInfo()
        {
            //arrange
            INavigationOnDiskService navigationOnDiskService = new NavigationOnDiskService();
            const string path = @"C:\Program Files\Microsoft Visual Studio 12.0\Common7\IDE\Microsoft.VisualStudio.Licensing.dll";
            //act
            var file = navigationOnDiskService.GetFileInfo(path);
            //assert
            Assert.IsNotNull(file);
        }
    }
}
