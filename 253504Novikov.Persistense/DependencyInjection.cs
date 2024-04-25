using _253504Novikov.Persistense.Data;
using _253504Novikov.Persistense.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _253504Novikov.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection sevices, DbContextOptions options)
        {
            sevices.AddPersistence()
                .AddSingleton<AppDbContext>(
                new AppDbContext((DbContextOptions<AppDbContext>)options));
            return sevices;
        }
    }
}
