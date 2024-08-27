using System;
using AndreasBank.Services;

namespace AndreasBank.ViewModel;

[QueryProperty(nameof(ContaPoupanca), "ContaPoupanca")]
public partial class ContaPoupancaDetailsViewModel : BaseViewModel
{

    ContaPoupancaService contaPoupancaService;

    [ObservableProperty]
    ContaPoupanca contaPoupanca;
    public ContaPoupancaDetailsViewModel(ContaPoupancaService contaPoupancaService)
    {
        Title = "Conta Poupanca";
        this.contaPoupancaService = contaPoupancaService;
        contaPoupanca = new ContaPoupanca();
    }

    //[RelayCommand]
    public async void GetContaPoupancaAsync(int id)
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var contaPoupancaRetorno = await contaPoupancaService.GetContaPoupanca(id);
            ContaPoupanca = contaPoupancaRetorno;
            //if (ContaPoupanca == null)
            //{
            //    ContaPoupanca = clienteRetorno;
            //}
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
    async Task PostContaPoupancaAsync()
    {
        try
        {
            //ContaPoupanca cliente = new ContaPoupanca();            

            Boolean retorno = await contaPoupancaService.PostContaPoupanca(ContaPoupanca);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Inclusão de conta poupanca falhou", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Inclusão de conta poupanca realizada com sucesso", "OK");
            }

            //await this.GetContaPoupancasAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get contas poupanca: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
