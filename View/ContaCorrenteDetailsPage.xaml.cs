using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ContaCorrenteDetailsPage : ContentPage
{
	
	public ContaCorrenteDetailsPage()
	{
		InitializeComponent();
		BindingContext = new ContaCorrenteDetailsViewModel(new ContaCorrenteService());		
	}	
}