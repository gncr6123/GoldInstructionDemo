using Domain.Notifications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.InstructionId)
                   .IsRequired();

            builder.Property(n => n.Message)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(n => n.CreatedAt)
                   .IsRequired();
        }
    }
}
