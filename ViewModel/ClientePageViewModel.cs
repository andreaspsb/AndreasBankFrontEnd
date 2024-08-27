using AndreasBank.Services;
using AndreasBank.View;

namespace AndreasBank.ViewModel;

public partial class ClientePageViewModel : BaseViewModel
{

    ClienteService clienteService;
    public ObservableCollection<Cliente> Clientes { get; } = new();
    //public static int ClienteId { get; private set; }

    [ObservableProperty]
    Cliente cliente;

    public ClientePageViewModel(ClienteService clienteService)
    {
        Title = "Clientes";
        this.clienteService = clienteService;
    }

    [RelayCommand]
    public async Task GetClientesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var clientes = await clienteService.GetClientes();
            if (Clientes.Count != 0)
            {
                clientes.Clear();
            }

            foreach (var cliente in clientes)
            {
                Clientes.Add(cliente);
            }

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

    [RelayCommand]
    async Task DeleteClienteAsync(int id)
    {
        try
        {
            Boolean retorno = await clienteService.DeleteCliente(id);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Exclusão de agência falhou", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Exclusão de agência realizada com sucesso", "OK");
            }

            await this.GetClientesAsync();
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


    [RelayCommand]
    async Task GoToClienteDetailsAsync()
    {
        await Application.Current.MainPage.DisplayAlert("Erro!", "A implementar", "OK");

        //await Shell.Current.GoToAsync(nameof(ClienteDetailsPage));
    }

    [RelayCommand]
    async Task GoToClienteDetailsPostAsync()
    {
        await Application.Current.MainPage.DisplayAlert("Erro!", "A implementar", "OK");

        //await Shell.Current.GoToAsync(nameof(ClienteDetailsPage),
        //new Dictionary<string, object>()
        //{
        //    {"Cliente", Cliente }
        //});

    }

}
