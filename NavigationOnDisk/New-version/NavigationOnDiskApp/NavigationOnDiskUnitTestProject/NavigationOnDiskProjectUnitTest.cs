using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationOnDiskProjectLib.Exceptions;
using NavigationOnDiskProjectLib.Services.Implementations;
using NavigationOnDiskProjectLib.Services.Interfaces;

namespace NavigationOnDiskProjectUnitTestProject
{
    [TestClass]
    public class NavigationOnDiskProjectUnitTest
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
            Assert.AreEqual(directories.Count() + files.Count(), items.Count);
        }

    }
}
