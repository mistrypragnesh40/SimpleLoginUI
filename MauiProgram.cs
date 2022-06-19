using SimpleLoginUI.Services;
using SimpleLoginUI.ViewModels;
using SimpleLoginUI.ViewModels.Dashboard;
using SimpleLoginUI.ViewModels.Startup;
using SimpleLoginUI.Views.Dashboard;
using SimpleLoginUI.Views.Startup;

namespace SimpleLoginUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		builder.Services.AddSingleton<ILoginService, LoginService>();

        //Views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<StudentDashboardPage>();
        builder.Services.AddSingleton<LoadingPage>();


        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<StudentDashboardPageVieiwModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();

        return builder.Build();
	}
}
