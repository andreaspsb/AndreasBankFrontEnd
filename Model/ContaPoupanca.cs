using System.Text.Json.Serialization;

namespace AndreasBank.Model;

public class ContaPoupanca : Conta
{
    public int DiaAniversario { get; set; }
    public float TaxaRendimento { get; set; }
}

[JsonSerializable(typeof(List<ContaPoupanca>))]
internal sealed partial class ContaPoupancaContext : JsonSerializerContext
{

}
