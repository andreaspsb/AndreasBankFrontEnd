using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;

namespace AndreasBank.Services;

public class ClienteService
{
    HttpClient httpClient;

    public ClienteService()
    {
        httpClient = new HttpClient();
    }

    List<Cliente> clientes = new List<Cliente>();

    public async Task<List<Cliente>> GetClientes()
    {
        if (clientes?.Count > 0)
        {
            return clientes;
        }

        var url = "http://localhost:8080/cliente/listar";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            clientes = await response.Content.ReadFromJsonAsync<List<Cliente>>();
        }

        return clientes;

    }

    public async Task<Cliente> GetCliente(int id)
    {
        Cliente cliente = new Cliente();

        var url = $"http://localhost:8080/cliente/{id}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            cliente = await response.Content.ReadFromJsonAsync<Cliente>();
        }

        return cliente;

    }

    internal async Task<Boolean> DeleteCliente(int id)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/cliente/{id}/excluir";

        var response = await httpClient.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //await response.Content.ReadFromJsonAsync<Agencia>();
            clientes.Remove(clientes.Find(x => x.Id == id));
            retorno = true;
        }

        return retorno;
    }

    internal async Task<bool> PostCliente(Cliente cliente)
    {
        Boolean retorno = false;

        var url = $"http://localhost:8080/cliente/incluir";

        var json = JsonSerializer.Serialize<Cliente>(cliente);

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
