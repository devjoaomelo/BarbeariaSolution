using Barbearia.Domain.Enums;

namespace Barbearia.Domain.Entities;

public class Agendamento
{
    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public Guid? BarbeiroId { get; private set; }
    public Guid ServidorId { get; private set; }
    
    public DateTime DataHoraInicio { get; private set; }
    public DateTime DataHoraFim { get; private set; }
    public StatusAgendamento Status { get; private set; }
    
    protected Agendamento() { }

    public Agendamento(Guid clientId, Guid servicoId, TimeSpan duracao, DateTime dataHoraInicio,
        Guid? barbeiroId = null)
    {
        if (clientId == Guid.Empty)
        {
            throw new ArgumentException("ClientId é obrigatório", nameof(clientId));
        }

        if (servicoId == Guid.Empty)
        {
            throw new ArgumentException("ServicoId é obrigatório", nameof(servicoId));
        }

        if (duracao <= TimeSpan.Zero)
        {
            throw new ArgumentException("Duração deve ser maior que zero", nameof(duracao));
        }
        
        Id = Guid.NewGuid();
        ClientId = clientId;
        BarbeiroId = barbeiroId;
        ServidorId = servicoId;
        DataHoraInicio = dataHoraInicio;
        DataHoraFim = dataHoraInicio.Add(duracao);
        Status = StatusAgendamento.Pendente;
    }

    public void Confirmar()
    {
        if (Status != StatusAgendamento.Pendente)
        {
            throw new InvalidOperationException("Só é possivel confirmar um agendamento pendente");
        }
        Status = StatusAgendamento.Confirmado;
    }

    public void Cancelar()
    {
        if (Status == StatusAgendamento.Cancelado)
        {
            throw new InvalidOperationException("Agendamento já esta cancelado");
        }
    }
}