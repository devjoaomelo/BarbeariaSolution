using Barbearia.Domain.Entities;

namespace Barbearia.Domain.Interfaces;

public interface IAgendamentoRepository
{
    // Add agentamento
    void Add(Agendamento agendamento);
    
    // Atualizada existente
    void Update(Agendamento agendamento);
    
    // Agendamento por Id
    Agendamento? GetById(Guid id);
    
    // Lista todos agendamento de um cliente
    IEnumerable<Agendamento> GetByClienteId();
    
    // Lista todos agendamentos do barbeiro naquele periodo
    IEnumerable<Agendamento> GetByBarbeiroAndPeriodo(Guid barbeiroId, DateTime inicio, DateTime fim);

    // Lista todos agendamento
    IEnumerable<Agendamento> GetAll();
}