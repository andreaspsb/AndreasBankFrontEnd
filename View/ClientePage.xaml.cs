using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ClientePage : ContentPage
{
	public ClientePage()
	{
		InitializeComponent();
		BindingContext = new ClientePageViewModel(new ClienteService());
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as ClientePageViewModel).GetClientesAsync();
	}
}