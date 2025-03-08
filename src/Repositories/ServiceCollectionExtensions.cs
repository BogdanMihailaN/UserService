using Microsoft.Extensions.DependencyInjection;
using Repositories.Role;
using Repositories.User;

namespace Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}