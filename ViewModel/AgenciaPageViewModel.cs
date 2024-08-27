using AndreasBank.Services;
using AndreasBank.View;

namespace AndreasBank.ViewModel;

public partial class AgenciaPageViewModel : BaseViewModel
{

    AgenciaService agenciaService;
    public ObservableCollection<Agencia> Agencias { get; } = new();
    //public static int AgenciaId { get; private set; }

    [ObservableProperty]
    Agencia agencia;

    public AgenciaPageViewModel(AgenciaService agenciaService)
    {
        Title = "Agências";
        this.agenciaService = agenciaService;
    }

    [RelayCommand]
    public async Task GetAgenciasAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var agencias = await agenciaService.GetAgencias();
            if (Agencias.Count != 0)
            {
                Agencias.Clear();
            }

            foreach (var agencia in agencias)
            {
                Agencias.Add(agencia);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get agencias: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task DeleteAgenciaAsync(int id)
    {
        try
        {
            Boolean retorno = await agenciaService.DeleteAgencia(id);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Exclusão de agência falhou", "OK");
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Exclusão de agência realizada com sucesso", "OK");
            }
            
            await this.GetAgenciasAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get agencias: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    async Task GoToAgenciaDetailsAsync()
    {
        await Shell.Current.GoToAsync(nameof(AgenciaDetailsPage));

        //await Shell.Current.GoToAsync($"{nameof(AgenciaDetailsPage)}?{nameof(AgenciaViewModel.AgenciaId)}={agencia.Id}");
        //await Shell.Current.GoToAsync($"{nameof(AgenciaDetailsPage)}

    }

    [RelayCommand]
    async Task GoToAgenciaDetailsPostAsync()
    {
        //if (agencia == null)
        //    return;


        await Shell.Current.GoToAsync(nameof(AgenciaDetailsPage),
        new Dictionary<string, object>()
        {
            {"Agencia", Agencia }
        });

        //await Shell.Current.GoToAsync($"{nameof(AgenciaDetailsPage)}?{nameof(AgenciaViewModel.AgenciaId)}={agencia.Id}");
        //await Shell.Current.GoToAsync($"{nameof(AgenciaDetailsPage)}

    }

}
