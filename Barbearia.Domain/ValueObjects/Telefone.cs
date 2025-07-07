using System.Text.RegularExpressions;

namespace Barbearia.Domain.ValueObjects;

public partial class Telefone
{
    public string Numero { get; }
    
    protected Telefone() { }

    public Telefone(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
        {
            throw new ArgumentNullException(nameof(numero));
        }

        if (!ValidarFormato(numero))
        {
            throw new ArgumentException("Formato de telefone inválido");
        }
        
        Numero = numero;
    }

    [GeneratedRegex(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")]
    private static partial Regex TelefoneRegex();

    private bool ValidarFormato(string numero)
    {
        return TelefoneRegex().IsMatch(numero);
    }
    
    public override string ToString() => Numero;

    public override bool Equals(object? obj)
    {
        return obj is Telefone other && other.Numero == Numero;
    }
    
    public override int GetHashCode() => Numero.GetHashCode();
}