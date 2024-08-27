using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ContaPoupancaDetailsPage : ContentPage
{
	
	public ContaPoupancaDetailsPage()
	{
		InitializeComponent();
		BindingContext = new ContaPoupancaDetailsViewModel(new ContaPoupancaService());		
	}	
}