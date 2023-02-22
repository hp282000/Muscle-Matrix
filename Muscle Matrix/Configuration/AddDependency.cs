using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Service;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Repository;

namespace Muscle_Matrix.Configuration
{
    public static class AddDependency
    {

        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(Program));
        }

    }
}
