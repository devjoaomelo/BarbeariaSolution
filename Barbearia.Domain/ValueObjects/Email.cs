using System.Text.RegularExpressions;

namespace Barbearia.Domain.ValueObjects;

public partial class Email
{
    public string Endereco { get; }
    
    protected Email() { }

    public Email(string endereco)
    {
        if (string.IsNullOrWhiteSpace(endereco))
        {
            throw new ArgumentNullException(nameof(endereco));
        }

        if (!EmailRegex().IsMatch(endereco))
        {
            throw new ArgumentException("Formato de email inválido");
        }

        Endereco = endereco;
    }
    
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegex();

    public override string ToString() => Endereco;

    public override bool Equals(object? obj)
    {
        return obj is Email other && Endereco.Equals(other.Endereco, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Endereco.ToLowerInvariant().GetHashCode();
}