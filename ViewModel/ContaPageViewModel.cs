using AndreasBank.Services;
using AndreasBank.View;

namespace AndreasBank.ViewModel;

public partial class ContaPageViewModel : BaseViewModel
{

    ContaService contaService;
    public ObservableCollection<Conta> Contas { get; } = new();
    //public static int ContaId { get; private set; }

    [ObservableProperty]
    Conta conta;

    public ContaPageViewModel(ContaService contaService)
    {
        Title = "Contas";
        this.contaService = contaService;
    }

    [RelayCommand]
    public async Task GetContasAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var contas = await contaService.GetContas();
            if (Contas.Count != 0)
            {
                contas.Clear();
            }

            foreach (var conta in contas)
            {
                Contas.Add(conta);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get contas: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task DeleteContaAsync(int id)
    {
        try
        {
            Boolean retorno = await contaService.DeleteConta(id);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Exclusão de agência falhou", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Exclusão de agência realizada com sucesso", "OK");
            }

            await this.GetContasAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get contas: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

}
