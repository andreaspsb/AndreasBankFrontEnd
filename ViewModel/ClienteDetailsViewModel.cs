using System;
using AndreasBank.Services;

namespace AndreasBank.ViewModel;

[QueryProperty(nameof(Cliente), "Cliente")]
public partial class ClienteDetailsViewModel : BaseViewModel
{

    ClienteService clienteService;

    [ObservableProperty]
    Cliente cliente;
    public ClienteDetailsViewModel(ClienteService clienteService)
    {
        Title = "Agência";
        this.clienteService = clienteService;
        cliente = new Cliente();
    }

    //[RelayCommand]
    public async void GetClienteAsync(int id)
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var clienteRetorno = await clienteService.GetCliente(id);
            Cliente = clienteRetorno;
            //if (Cliente == null)
            //{
            //    Cliente = clienteRetorno;
            //}
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get cliente: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    async Task PostClienteAsync()
    {
        try
        {
            //Cliente cliente = new Cliente();            

            Boolean retorno = await clienteService.PostCliente(Cliente);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Inclusão de cliente falhou", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Inclusão de cliente realizada com sucesso", "OK");
            }            

            //await this.GetClientesAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get clientes: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
