using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;

namespace AndreasBank.Services;

public class ContaService
{
    HttpClient httpClient;

    public ContaService()
    {
        httpClient = new HttpClient();
    }

    List<Conta> contas = new List<Conta>();

    public async Task<List<Conta>> GetContas()
    {
        if (contas?.Count > 0)
        {
            return contas;
        }

        var url = "http://localhost:8080/conta/listar";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            contas = await response.Content.ReadFromJsonAsync<List<Conta>>();
        }

        return contas;

    }

    public async Task<Conta> GetConta(int id)
    {
        Conta conta = new Conta();

        var url = $"http://localhost:8080/conta/{id}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            conta = await response.Content.ReadFromJsonAsync<Conta>();
        }

        return conta;

    }

    internal async Task<Boolean> DeleteConta(int id)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/conta/{id}/excluir";

        var response = await httpClient.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //await response.Content.ReadFromJsonAsync<Agencia>();
            contas.Remove(contas.Find(x => x.Id == id));
            retorno = true;
        }

        return retorno;
    }

}
    
