using AndreasBank.Services;

namespace AndreasBank.View;

public partial class ClienteDetailsPage : ContentPage
{
	
	public ClienteDetailsPage()
	{
		InitializeComponent();
		BindingContext = new ClienteDetailsViewModel(new ClienteService());		
	}	
}