using Barbearia.Domain.ValueObjects;

namespace Barbearia.Domain.Entities;

public class Servico
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public TimeSpan Duracao { get; private set; }
    public decimal Valor { get; private set; }
    
    protected Servico() { }

    public Servico(string nome, TimeSpan duracao, decimal valor)
    {
        if (String.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome do serviço é obrigatório.", nameof(nome));
        }

        if (duracao < TimeSpan.Zero)
        {
            throw new ArgumentException("Duração deve ser maior que zero.", nameof(duracao));
        }

        if (Valor < 0)
        {
            throw new ArgumentException("Valor deve ser maior que zero.", nameof(valor));
        }
        
        Id = new Guid();
        Nome = nome;
        Duracao = duracao;
        Valor = valor;
    }

    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
    }

    public void AtualizarDuracao(TimeSpan duracao)
    {
        Duracao = duracao;
    }

    public void AtualizarValor(decimal valor)
    {
        Valor = valor;
    }
    
}