using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ContaCorrentePage : ContentPage
{
	public ContaCorrentePage()
	{
		InitializeComponent();
		BindingContext = new ContaCorrentePageViewModel(new ContaCorrenteService());
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as ContaCorrentePageViewModel).GetContasCorrenteAsync();
	}
}