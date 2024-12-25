using Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .IsRequired();
        }
    }
}
