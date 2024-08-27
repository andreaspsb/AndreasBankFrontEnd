using AndreasBank.Services;
using AndreasBank.View;

namespace AndreasBank.ViewModel;

public partial class ContaPoupancaPageViewModel : BaseViewModel
{

    ContaPoupancaService contaPoupancaService;
    public ObservableCollection<ContaPoupanca> ContasPoupanca { get; } = new();

    [ObservableProperty]
    ContaPoupanca contaPoupanca;

    public ContaPoupancaPageViewModel(ContaPoupancaService contaPoupancaService)
    {
        Title = "ContaPoupanca";
        this.contaPoupancaService = contaPoupancaService;
    }

    [RelayCommand]
    public async Task GetContasPoupancaAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var contasPoupanca = await contaPoupancaService.GetContasPoupanca();
            if (ContasPoupanca.Count != 0)
            {
                ContasPoupanca.Clear();
            }

            foreach (var contaPoupanca in contasPoupanca)
            {
                ContasPoupanca.Add(contaPoupanca);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get conta poupanca: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task DeleteContaPoupancaAsync(int id)
    {
        try
        {
            Boolean retorno = await contaPoupancaService.DeleteContaPoupanca(id);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Exclusão de conta poupanca falhou", "OK");
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Exclusão de conta poupanca realizada com sucesso", "OK");
            }
            
            await this.GetContasPoupancaAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get conta poupanca: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    async Task GoToContaPoupancaDetailsAsync()
    {
        await Application.Current.MainPage.DisplayAlert("Erro!", "A implementar", "OK");
        
        //await Shell.Current.GoToAsync(nameof(ContaPoupancaDetailsPage));

    }

    [RelayCommand]
    async Task GoToContaPoupancaDetailsPostAsync()
    {
        await Application.Current.MainPage.DisplayAlert("Erro!", "A implementar", "OK");


        //await Shell.Current.GoToAsync(nameof(ContaPoupancaDetailsPage),
        //new Dictionary<string, object>()
        //{
        //    {"ContaPoupanca", ContaPoupanca }
        //});

    }

}
