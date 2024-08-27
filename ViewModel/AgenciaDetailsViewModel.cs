using System;
using AndreasBank.Services;
using AndreasBank.View;

namespace AndreasBank.ViewModel;

[QueryProperty(nameof(Agencia), "Agencia")]
public partial class AgenciaDetailsViewModel : BaseViewModel
{

    AgenciaService agenciaService;

    [ObservableProperty]
    Agencia agencia;
    public AgenciaDetailsViewModel(AgenciaService agenciaService)
    {
        Title = "Agência";
        this.agenciaService = agenciaService;
        agencia = new Agencia();
    }

    //[RelayCommand]
    public async void GetAgenciaAsync(int id)
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var agenciaRetorno = await agenciaService.GetAgencia(id);
            Agencia = agenciaRetorno;
            //if (Agencia == null)
            //{
            //    Agencia = agenciaRetorno;
            //}
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get agencia: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    async Task PostAgenciaAsync()
    {
        try
        {
            //Agencia agencia = new Agencia();            

            Boolean retorno = await agenciaService.PostAgencia(Agencia);
            if (!retorno)
            {
                await Application.Current.MainPage.DisplayAlert("Erro!", "Inclusão de agência falhou", "OK");
            }
            else
            {
                Agencia.Codigo = "";
                Agencia.Nome = "";
                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Inclusão de agência realizada com sucesso", "OK");
            }



            //await this.GetAgenciasAsync();            
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
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync(nameof(AgenciaPage));
    }
}
