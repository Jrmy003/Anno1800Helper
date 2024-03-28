using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}