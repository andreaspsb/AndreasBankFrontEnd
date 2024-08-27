using System.Text.Json.Serialization;

namespace AndreasBank.Model;

public class Cliente
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }
}

[JsonSerializable(typeof(List<Cliente>))]
internal sealed partial class ClienteContext : JsonSerializerContext
{

}
