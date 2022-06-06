using SimpleLoginUI.ViewModels.Startup;

namespace SimpleLoginUI.Views.Startup;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}