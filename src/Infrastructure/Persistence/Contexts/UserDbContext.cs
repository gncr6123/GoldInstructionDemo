using Domain.Users;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // Dummy kullanıcı ekleme
            modelBuilder.Entity<User>().HasData(
        new
        {
            Id = Guid.NewGuid(), // BaseEntity'den gelen özellik
            Name = "Test User 1",
            Email = "testuser1@example.com",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        },
        new
        {
            Id = Guid.NewGuid(),
            Name = "Test User 2",
            Email = "testuser2@example.com",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        }
    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
