using SimpleLoginUI.ViewModels.Startup;

namespace SimpleLoginUI.Views.Startup;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}