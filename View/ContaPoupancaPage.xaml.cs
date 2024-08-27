using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ContaPoupancaPage : ContentPage
{
	public ContaPoupancaPage()
	{
		InitializeComponent();
		BindingContext = new ContaPoupancaPageViewModel(new ContaPoupancaService());
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as ContaPoupancaPageViewModel).GetContasPoupancaAsync();
	}
}