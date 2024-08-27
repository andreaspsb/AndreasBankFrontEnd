using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;

namespace AndreasBank.Services;

public class ContaCorrenteService
{
    HttpClient httpClient;

    public ContaCorrenteService()
    {
        httpClient = new HttpClient();
    }

    List<ContaCorrente> contasCorrente = new List<ContaCorrente>();

    public async Task<List<ContaCorrente>> GetContasCorrente()
    {
        if (contasCorrente?.Count > 0)
        {
            return contasCorrente;
        }

        var url = "http://localhost:8080/contacorrente/listar";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            contasCorrente = await response.Content.ReadFromJsonAsync<List<ContaCorrente>>();
        }

        return contasCorrente;

    }

    public async Task<ContaCorrente> GetContaCorrente(int id)
    {
        ContaCorrente contaCorrente = new ContaCorrente();

        var url = $"http://localhost:8080/contacorrente/{id}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            contaCorrente = await response.Content.ReadFromJsonAsync<ContaCorrente>();
        }

        return contaCorrente;

    }

    internal async Task<Boolean> DeleteContaCorrente(int id)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/contacorrente/{id}/excluir";

        var response = await httpClient.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //await response.Content.ReadFromJsonAsync<Agencia>();
            contasCorrente.Remove(contasCorrente.Find(x => x.Id == id));
            retorno = true;
        }

        return retorno;
    }

    internal async Task<bool> PostContaCorrente(ContaCorrente contaCorrente)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/contacorrente/incluir";

        var json = JsonSerializer.Serialize<ContaCorrente>(contaCorrente);

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
