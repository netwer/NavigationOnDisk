using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using NavigationOnDiskApp.ViewModel;
using NavigationOnDiskLib.Exceptions;
using NavigationOnDiskLib.Services.Implementations;
using NavigationOnDiskLib.Services.Interfaces;
using NavigationOnDiskModel.FileSystem;

namespace NavigationOnDiskApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
