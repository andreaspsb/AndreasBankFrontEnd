using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ContaPage : ContentPage
{
	public ContaPage()
	{
		InitializeComponent();
		BindingContext = new ContaPageViewModel(new ContaService());
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as ContaPageViewModel).GetContasAsync();
	}
}