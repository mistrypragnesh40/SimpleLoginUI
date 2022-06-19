using SimpleLoginUI.ViewModels.Dashboard;

namespace SimpleLoginUI.Views.Dashboard;

public partial class StudentDashboardPage : ContentPage
{
	public StudentDashboardPage(StudentDashboardPageVieiwModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;

    }
}