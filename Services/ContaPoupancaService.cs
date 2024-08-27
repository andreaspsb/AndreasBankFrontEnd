using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;

namespace AndreasBank.Services;

public class ContaPoupancaService
{
    HttpClient httpClient;

    public ContaPoupancaService()
    {
        httpClient = new HttpClient();
    }

    List<ContaPoupanca> contasPoupanca = new List<ContaPoupanca>();

    public async Task<List<ContaPoupanca>> GetContasPoupanca()
    {
        if (contasPoupanca?.Count > 0)
        {
            return contasPoupanca;
        }

        var url = "http://localhost:8080/contapoupanca/listar";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            contasPoupanca = await response.Content.ReadFromJsonAsync<List<ContaPoupanca>>();
        }

        return contasPoupanca;

    }

    public async Task<ContaPoupanca> GetContaPoupanca(int id)
    {
        ContaPoupanca contaPoupanca = new ContaPoupanca();

        var url = $"http://localhost:8080/contapoupanca/{id}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            contaPoupanca = await response.Content.ReadFromJsonAsync<ContaPoupanca>();
        }

        return contaPoupanca;

    }

    internal async Task<Boolean> DeleteContaPoupanca(int id)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/contapoupanca/{id}/excluir";

        var response = await httpClient.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //await response.Content.ReadFromJsonAsync<Agencia>();
            contasPoupanca.Remove(contasPoupanca.Find(x => x.Id == id));
            retorno = true;
        }

        return retorno;
    }

    internal async Task<bool> PostContaPoupanca(ContaPoupanca contaPoupanca)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/contapoupanca/incluir";

        var json = JsonSerializer.Serialize<ContaPoupanca>(contaPoupanca);

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
