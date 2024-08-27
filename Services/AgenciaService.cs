using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;

namespace AndreasBank.Services;

public class AgenciaService
{
    HttpClient httpClient;

    public AgenciaService()
    {
        httpClient = new HttpClient();
    }

    List<Agencia> agencias = new List<Agencia>();

    public async Task<List<Agencia>> GetAgencias()
    {
        //if (agencias?.Count > 0)
        //{
        //    return agencias;
        //}

        var url = "http://localhost:8080/agencia/listar";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            agencias = await response.Content.ReadFromJsonAsync<List<Agencia>>();
        }

        return agencias;

    }

    public async Task<Agencia> GetAgencia(int id)
    {
        Agencia agencia = new Agencia();

        var url = $"http://localhost:8080/agencia/{id}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            agencia = await response.Content.ReadFromJsonAsync<Agencia>();
        }

        return agencia;

    }

    internal async Task<Boolean> DeleteAgencia(int id)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/agencia/{id}/excluir";

        var response = await httpClient.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //await response.Content.ReadFromJsonAsync<Agencia>();
            agencias.Remove(agencias.Find(x => x.Id == id));
            retorno = true;
        }

        return retorno;
    }

    internal async Task<bool> PostAgencia(Agencia agencia)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/agencia/incluir";

        var json = JsonSerializer.Serialize<Agencia>(agencia);

        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(url, content);

        //var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //await response.Content.ReadFromJsonAsync<Agencia>();

            retorno = true;
        }

        return retorno;
    }
}
