using Microsoft.EntityFrameworkCore;
using Barbearia.Domain.Entities;

namespace Barbearia.Infrastructure.Persistence;

public class BarbeariaDbContext : DbContext
{
    public BarbeariaDbContext(DbContextOptions<BarbeariaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Barbeiro> Barbeiros { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nome).IsRequired();
            entity.OwnsOne(c => c.Telefone, vo =>
            {
                vo.Property(v => v.Numero)
                  .HasColumnName("Telefone")
                  .IsRequired();
            });
            entity.OwnsOne(c => c.Email, vo =>
            {
                vo.Property(v => v.Endereco)
                  .HasColumnName("Email")
                  .IsRequired();
            });
        });

        modelBuilder.Entity<Barbeiro>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Nome).IsRequired();
            entity.OwnsOne(b => b.Telefone, vo =>
            {
                vo.Property(v => v.Numero)
                  .HasColumnName("Telefone")
                  .IsRequired();
            });
            entity.OwnsOne(b => b.Email, vo =>
            {
                vo.Property(v => v.Endereco)
                  .HasColumnName("Email")
                  .IsRequired();
            });
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Nome).IsRequired();
            entity.Property(s => s.Duracao).IsRequired();
            entity.Property(s => s.Valor)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();
        });

        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.ClienteId).IsRequired();
            entity.Property(a => a.ServicoId).IsRequired();
            entity.Property(a => a.BarbeiroId);
            entity.Property(a => a.DataHoraInicio).IsRequired();
            entity.Property(a => a.DataHoraFim).IsRequired();
            entity.Property(a => a.Status).IsRequired();
        });
    }
}
