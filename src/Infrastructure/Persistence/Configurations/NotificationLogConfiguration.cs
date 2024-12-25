using Domain.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class NotificationLogConfiguration : IEntityTypeConfiguration<NotificationLog>
    {
        public void Configure(EntityTypeBuilder<NotificationLog> builder)
        {
            
            builder.HasKey(nl => nl.Id);
            
            builder.Property(nl => nl.NotificationId)
                .IsRequired();

            builder.HasOne(nl => nl.Notification)
                .WithMany(n => n.NotificationLogs)
                .HasForeignKey(nl => nl.NotificationId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(nl => nl.ChannelId)
                .IsRequired();

            builder.HasOne(nl => nl.Channel)
                .WithMany()
                .HasForeignKey(nl => nl.ChannelId)
                .OnDelete(DeleteBehavior.Restrict);

            // IsSent
            builder.Property(nl => nl.IsSent)
                .IsRequired();

            // SentAt
            builder.Property(nl => nl.SentAt)
                .IsRequired(false); // Nullable alan

            // ErrorMessage
            builder.Property(nl => nl.ErrorMessage)
                .HasMaxLength(500)
                .IsRequired(false); // Nullable alan
        }
    }
}
