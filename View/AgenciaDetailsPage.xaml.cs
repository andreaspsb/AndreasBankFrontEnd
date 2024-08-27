using System.Text.RegularExpressions;
using AndreasBank.Services;

namespace AndreasBank.View;

public partial class AgenciaDetailsPage : ContentPage
{
	
	public AgenciaDetailsPage()
	{
		InitializeComponent();
		BindingContext = new AgenciaDetailsViewModel(new AgenciaService());
		//AgenciaDetailsViewModel viewModel = new AgenciaDetailsViewModel(new AgenciaService());
		//BindingContext = viewModel;
		//viewModel.GetAgenciaAsync(viewModel.Agencia.Id);
		//AgenciaDetailsViewModel viewModel;
		//viewModel.GetAgenciaCommand(int id);
	}
	
	//public AgenciaDetailsPage(Dictionary<string, object> parameters)
	//{
		//InitializeComponent();
		//BindingContext = new AgenciaDetailsViewModel(new AgenciaService());
		//AgenciaDetailsViewModel viewModel = new AgenciaDetailsViewModel(new AgenciaService());
		//BindingContext = viewModel;
		//viewModel.GetAgenciaAsync(Convert.ToInt32(parameters["id"]));
		//aux(viewModel, id);
	//}

	//private async Task aux(AgenciaDetailsViewModel viewModel, int id)
	//{
	//	await viewModel.GetAgenciaAsync(id);
	//}

	// Method triggered by TextChanged.
	private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{
		// If the text field is empty or null then leave.
		string regex = e.NewTextValue;
		if (String.IsNullOrEmpty(regex))
			return;

		// If the text field only contains numbers then leave.
		if (!Regex.Match(regex, "^[0-9]+$").Success)
		{
			// This returns to the previous valid state.
			var entry = sender as Entry;
			entry.Text = (string.IsNullOrEmpty(e.OldTextValue)) ?
					string.Empty : e.OldTextValue;
		}
	}
}