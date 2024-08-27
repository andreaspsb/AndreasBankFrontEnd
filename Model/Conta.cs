using System.Text.Json.Serialization;

namespace AndreasBank.Model;

public class Conta
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public float Saldo { get; set; }
    public bool IsAtivo { get; set; }
}

[JsonSerializable(typeof(List<Conta>))]
internal sealed partial class ContaContext : JsonSerializerContext
{

}
