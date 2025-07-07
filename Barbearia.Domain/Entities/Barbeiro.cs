using Barbearia.Domain.ValueObjects;

namespace Barbearia.Domain.Entities;

public class Barbeiro
{
    public Guid Id { get; private set; }
    public string Nome { get; private set ; }
    public Email Email { get; private set ; }
    public Telefone Telefone { get; private set ; }
    
    protected Barbeiro() { }

    public Barbeiro(string nome, Email email, Telefone telefone)
    {
        Id = new Guid();

        if (String.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome));
        }
        
        Email = email;
        Telefone = telefone;
        
    }

    public void AtualizarTelefone(Telefone novoTelefone)
    {
        Telefone = novoTelefone;
    }

    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
    }

    public void AtualizarEmail(Email novoEmail)
    {
        Email = novoEmail;
    }
}