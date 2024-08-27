using AndreasBank.View;

namespace AndreasBank.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {
        Title = "Andreas Bank";
    }

    [RelayCommand]
    async Task GoToAgenciasAsync()
    {
        await Shell.Current.GoToAsync(nameof(AgenciaPage));

    }

    [RelayCommand]
    async Task GoToClientesAsync()
    {
        await Shell.Current.GoToAsync(nameof(ClientePage));

    }

    [RelayCommand]
    async Task GoToContasAsync()
    {
        await Shell.Current.GoToAsync(nameof(ContaPage));

    }

    [RelayCommand]
    async Task GoToContasCorrenteAsync()
    {
        await Shell.Current.GoToAsync(nameof(ContaCorrentePage));

    }

    [RelayCommand]
    async Task GoToContasPoupancaAsync()
    {
        await Shell.Current.GoToAsync(nameof(ContaPoupancaPage));

    }


}
