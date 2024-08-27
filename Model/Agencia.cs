using System.Text.Json.Serialization;

namespace AndreasBank.Model;

public class Agencia
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public List<Conta> Contas { get; set; }
}

[JsonSerializable(typeof(List<Agencia>))]
internal sealed partial class AgenciaContext : JsonSerializerContext
{

}
