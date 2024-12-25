using Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string userConnStr, string instructionConnStr, string notificationConnStr)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(userConnStr));

            services.AddDbContext<InstructionDbContext>(options =>
                options.UseSqlServer(instructionConnStr));

            services.AddDbContext<NotificationDbContext>(options =>
                options.UseSqlServer(notificationConnStr));

            return services;
        }
    }
}
