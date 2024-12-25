using Domain.Notifications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class NotificationChannelConfiguration : IEntityTypeConfiguration<NotificationChannel>
    {
        public void Configure(EntityTypeBuilder<NotificationChannel> builder)
        {
            builder.HasKey(nc => nc.Id);

            builder.Property(nc => nc.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(nc => nc.CreatedAt)
                   .IsRequired();
        }
    }
}
