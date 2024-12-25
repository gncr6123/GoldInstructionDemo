using Domain.Notifications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class NotificationChannelMappingConfiguration : IEntityTypeConfiguration<NotificationChannelMapping>
    {
        public void Configure(EntityTypeBuilder<NotificationChannelMapping> builder)
        {
            builder.HasKey(ncm => new { ncm.NotificationId, ncm.ChannelId });

            builder.Property(ncm => ncm.IsSent)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(ncm => ncm.SentAt);

            builder.HasOne(ncm => ncm.Notification)
                   .WithMany(n => n.ChannelMappings)
                   .HasForeignKey(ncm => ncm.NotificationId);

            builder.HasOne(ncm => ncm.Channel)
                   .WithMany()
                   .HasForeignKey(ncm => ncm.ChannelId);
        }
    }
}
