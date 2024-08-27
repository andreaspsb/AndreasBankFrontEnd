using System;
using AndreasBank.Services;

namespace AndreasBank.ViewModel;

[QueryProperty(nameof(ContaCorrente), "ContaCorrente")]
public partial class ContaCorrenteDetailsViewModel : BaseViewModel
{

    ContaCorrenteService contaCorrenteService;

    [ObservableProperty]
    ContaCorrente contaCorrente;
    public ContaCorrenteDetailsViewModel(ContaCorrenteService contaCorrenteService)
    {
        Title = "Conta Corrente";
        this.contaCorrenteService = contaCorrenteService;
        contaCorrente = new ContaCorrente();
    }

    //[RelayCommand]
    public async void GetContaCorrenteAsync(int id)
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var contaCorrenteRetorno = await contaCorrenteService.GetContaCorrente(id);
            ContaCorrente = contaCorrenteRetorno;
            //if (ContaCorrente == null)
            //{
            //    ContaCorrente = clienteRetorno;
            //}
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
    async Task PostContaCorrenteAsync()
    {
        try
        {
            //ContaCorrente cliente = new ContaCorrente();            

            Boolean retorno = await contaCorrenteService.PostContaCorrente(ContaCorrente);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Inclusão de conta corrente falhou", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Inclusão de conta corrente realizada com sucesso", "OK");
            }

            //await this.GetContaCorrentesAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get contas corrente: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
