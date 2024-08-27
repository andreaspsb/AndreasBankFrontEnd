using AndreasBank.Services;

namespace AndreasBank.View;

public partial class AgenciaPage : ContentPage
{
	public AgenciaPage()
	{
		InitializeComponent();
		BindingContext = new AgenciaPageViewModel(new AgenciaService());

	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as AgenciaPageViewModel).GetAgenciasAsync();
	}
}