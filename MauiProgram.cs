using AndreasBank.View;
using AndreasBank.ViewModel;
using Microsoft.Extensions.Logging;

namespace AndreasBank;

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

		//builder.Services.AddSingleton<INavigationService,NavigationService>();
		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<AgenciaPage>();
		builder.Services.AddTransient<AgenciaPageViewModel>();
		builder.Services.AddTransient<AgenciaDetailsPage>();
		builder.Services.AddTransient<AgenciaDetailsViewModel>();


		Routing.RegisterRoute(nameof(AgenciaPage), typeof(AgenciaPage));
		Routing.RegisterRoute(nameof(AgenciaDetailsPage), typeof(AgenciaDetailsPage));

		Routing.RegisterRoute(nameof(ClientePage), typeof(ClientePage));
		Routing.RegisterRoute(nameof(ClienteDetailsPage), typeof(ClienteDetailsPage));

		Routing.RegisterRoute(nameof(ContaPage), typeof(ContaPage));

		Routing.RegisterRoute(nameof(ContaCorrentePage), typeof(ContaCorrentePage));
		Routing.RegisterRoute(nameof(ContaCorrenteDetailsPage), typeof(ContaCorrenteDetailsPage));

		Routing.RegisterRoute(nameof(ContaPoupancaPage), typeof(ContaPoupancaPage));
		Routing.RegisterRoute(nameof(ContaPoupancaDetailsPage), typeof(ContaPoupancaDetailsPage));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
