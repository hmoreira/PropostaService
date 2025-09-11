using PropostaService.Core.Domain.Entities; // Importe as entidades do seu Core
using PropostaService.Core.Domain.Interfaces; // Importe a interface do repositório
using Microsoft.EntityFrameworkCore;

namespace PropostaService.Adapters.Data
{
    public class PropostaDbContext : DbContext
    {
        // DbSet para a sua entidade principal
        public DbSet<Proposta> Propostas { get; set; }

        // Para outras entidades e Value Objects que podem precisar de DbSet próprio ou configuração específica

        public PropostaDbContext(DbContextOptions<PropostaDbContext> options)
            : base(options)
        {
        }

        // Opcional: Sobrescrever OnModelCreating para configurar Mapeamentos, Chaves, Índices, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemplo de configuração da entidade Proposta (pode ser movido para uma classe separada de mapeamento)
            modelBuilder.Entity<Proposta>(entity =>
            {
                entity.HasKey(p => p.Id);
                //entity.Property(p => p.ClienteId).IsRequired();
                entity.Property(p => p.Valor).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });


        }
    }
}
