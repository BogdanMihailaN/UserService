using Microsoft.Extensions.DependencyInjection;
using Services.UserRole;
using Services.User;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, User.UserService>();
            services.AddTransient<IUserRoleService, RoleService>();

            return services;
        }
    }
}