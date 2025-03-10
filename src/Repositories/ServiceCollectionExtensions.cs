using Microsoft.Extensions.DependencyInjection;
using Repositories.UserRole;
using Repositories.User;

namespace Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();

            return services;
        }
    }
}