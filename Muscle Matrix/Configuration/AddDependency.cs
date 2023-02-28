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
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IUserRoleService,UserRoleService>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IAuthenticateRepository,AuthenticateRepository>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddAutoMapper(typeof(Program));
        }

    }
}
