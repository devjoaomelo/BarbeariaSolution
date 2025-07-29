using Barbearia.Domain.Entities;
using Barbearia.Domain.Interfaces;


namespace Barbearia.Infrastructure.Persistence.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly BarbeariaDbContext _context;

        public AgendamentoRepository(BarbeariaDbContext context)
        {
            _context = context;
        }

        public void Add(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public void Update(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            _context.SaveChanges();
        }

        public Agendamento? GetById(Guid id)
        {
            return _context.Agendamentos.Find(id);
        }

        public IEnumerable<Agendamento> GetByClienteId(Guid clienteId)
        {
            return _context.Agendamentos
                .AsNoTracking()
                .Where(a => a.ClienteId == clienteId)
                .ToList();
        }

        public IEnumerable<Agendamento> GetByBarbeiroAndPeriodo(Guid barbeiroId, DateTime inicio, DateTime fim)
        {
            return _context.Agendamentos
                .AsNoTracking()
                .Where(a => a.BarbeiroId == barbeiroId
                            && a.DataHoraInicio >= inicio
                            && a.DataHoraFim <= fim)
                .ToList();
        }

        public IEnumerable<Agendamento> GetAll()
        {
            return _context.Agendamentos
                .AsNoTracking()
                .ToList();
        }
    }
}