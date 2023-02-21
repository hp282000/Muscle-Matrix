using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Infrastructure.Domain.Context;

namespace Muscle_Matrix.Configuration
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Default"];

            services.AddDbContext<ProjectContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("MuscleMatrix.Infrastructure.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Singleton);
        }
    }
}
