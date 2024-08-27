namespace AndreasBank;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		/*count++;

		if (count == 1)
			BtnEntrar.Text = $"Clicked {count} time";
		else
			BtnEntrar.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(BtnEntrar.Text);*/
	}
}

