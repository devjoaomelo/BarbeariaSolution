using Barbearia.Domain.ValueObjects;

namespace Barbearia.Domain.Entities;

public class Cliente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    
    protected Cliente(){ }

    public Cliente(string nome, Email email, Telefone telefone)
    {
        Id = new Guid();

        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome));
        }
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public void AtualizarTelefone(Telefone novoTelefone)
    {
        Telefone = novoTelefone;
    }

    public void AtualizarEmail(Email novoEmail)
    {
        Email = novoEmail;
    }

    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
    }
}