using Domain.Notifications;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
            : base(options) { }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationChannel> NotificationChannels { get; set; }
        public DbSet<NotificationChannelMapping> NotificationChannelMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationChannelConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationChannelMappingConfiguration());

            modelBuilder.Entity<NotificationChannel>().HasData(
                new
                {
                    Id = new Guid("CF7D73AA-C172-4EB2-9782-5491C76018B9"),
                    Name = "EMAIL",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new
                {
                    Id = new Guid("061898E6-C619-4F9E-96FC-F517E18F1FE7"),
                    Name = "SMS",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new
                {
                    Id = new Guid("829FE06A-2FA2-477C-979D-D1080CA86BBC"),
                    Name = "PUSH",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
