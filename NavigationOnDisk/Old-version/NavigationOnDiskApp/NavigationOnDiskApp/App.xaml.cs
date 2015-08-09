using System.Windows;
using NavigationOnDiskApp.View;
using NavigationOnDiskApp.ViewModel;
using NavigationOnDiskLib.Services.Implementations;

namespace NavigationOnDiskApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainUserControl mainUserControl = new MainUserControl(new NavigationOnDiskService(), new NavigationOnDiskViewModel());
            MainWindow view = new MainWindow {Content = mainUserControl};
            view.Show();
        }
    }
}
