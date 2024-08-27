using System.Text.Json.Serialization;

namespace AndreasBank.Model;

public class ContaCorrente : Conta
{
    public float Limite { get; set; }
    public float TaxaManutencao { get; set; }
}

[JsonSerializable(typeof(List<ContaCorrente>))]
internal sealed partial class ContaCorrenteContext : JsonSerializerContext
{

}
