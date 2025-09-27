using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZorgmeldSysteem.Persistence.Context;

namespace ZorgmeldSysteem.Infrastructure.Configuration
{
    public static class DatabaseConfiguration
    {
        private static readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ZorgmeldSysteem;Trusted_Connection=true;MultipleActiveResultSets=true";

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ZorgmeldContext>(options =>
                options.UseSqlServer(ConnectionString));
            return services;
        }
    }
}