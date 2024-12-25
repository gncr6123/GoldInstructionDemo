using Domain.Instructions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Instruction için EF Core yapılandırması.
    /// </summary>
    public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            // Birincil anahtar
            builder.HasKey(i => i.Id);

            // DayOfMonth alanı (1-28 arası)
            builder.Property(i => i.DayOfMonth)
                   .IsRequired();

            // Amount alanı (500-99.999 arası, decimal)
            builder.Property(i => i.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            // Status alanı (nvarchar, enum olarak saklanır)
            builder.Property(i => i.Status)
                   .HasConversion<string>() // Enum değerini string olarak saklar
                   .HasMaxLength(20)
                   .IsRequired();

            // UserId yabancı anahtar ilişkisi (Kullanıcı)
            builder.Property(i => i.UserId)
                   .IsRequired();

            // CreatedAt ve UpdatedAt
            builder.Property(i => i.CreatedAt)
                   .IsRequired();
            builder.Property(i => i.UpdatedAt);

            // Silme işlemi için DeletedAt ve IsDeleted
            builder.Property(i => i.DeletedAt);
            builder.Property(i => i.IsDeleted)
                   .IsRequired();
        }
    }
}
