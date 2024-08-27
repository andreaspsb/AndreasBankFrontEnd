using AndreasBank.Services;
using AndreasBank.View;

namespace AndreasBank.ViewModel;

public partial class ContaCorrentePageViewModel : BaseViewModel
{

    ContaCorrenteService contaCorrenteService;
    public ObservableCollection<ContaCorrente> ContasCorrente { get; } = new();
    //public static int ContaCorrenteId { get; private set; }

    [ObservableProperty]
    ContaCorrente contaCorrente;

    public ContaCorrentePageViewModel(ContaCorrenteService contaCorrenteService)
    {
        Title = "ContaCorrente";
        this.contaCorrenteService = contaCorrenteService;
    }

    [RelayCommand]
    public async Task GetContasCorrenteAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var contasCorrente = await contaCorrenteService.GetContasCorrente();
            if (ContasCorrente.Count != 0)
            {
                ContasCorrente.Clear();
            }

            foreach (var contaCorrente in contasCorrente)
            {
                ContasCorrente.Add(contaCorrente);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get conta corrente: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task DeleteContaCorrenteAsync(int id)
    {
        try
        {
            Boolean retorno = await contaCorrenteService.DeleteContaCorrente(id);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Exclusão de conta corrente falhou", "OK");
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Exclusão de conta corrente realizada com sucesso", "OK");
            }
            
            await this.GetContasCorrenteAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get conta corrente: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    async Task GoToContaCorrenteDetailsAsync()
    {
        await Application.Current.MainPage.DisplayAlert("Erro!", "A implementar", "OK");
        
        //await Shell.Current.GoToAsync(nameof(ContaCorrenteDetailsPage));

    }

    [RelayCommand]
    async Task GoToContaCorrenteDetailsPostAsync()
    {
        await Application.Current.MainPage.DisplayAlert("Erro!", "A implementar", "OK");


        //await Shell.Current.GoToAsync(nameof(ContaCorrenteDetailsPage),
        //new Dictionary<string, object>()
        //{
        //    {"ContaCorrente", ContaCorrente }
        //});

    }

}
