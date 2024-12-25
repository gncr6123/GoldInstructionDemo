using Domain.Instructions;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    /// <summary>
    /// Talimatlarla ilgili DbContext sınıfı.
    /// </summary>
    public class InstructionDbContext : DbContext
    {
        public InstructionDbContext(DbContextOptions<InstructionDbContext> options)
            : base(options) { }

        // Instruction tablosu
        public DbSet<Instruction> Instructions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Instruction yapılandırmasını uygula
            modelBuilder.ApplyConfiguration(new InstructionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
