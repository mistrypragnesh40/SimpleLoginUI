using SimpleLoginUI.Models;
using SimpleLoginUI.ViewModels;
using SimpleLoginUI.Views.Dashboard;

namespace SimpleLoginUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new AppShellViewModel();

       
    }
}
