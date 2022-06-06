using SimpleLoginUI.ViewModels;
using SimpleLoginUI.Views.Dashboard;

namespace SimpleLoginUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new AppShellViewModel();
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
    }
}
