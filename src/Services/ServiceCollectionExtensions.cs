using Microsoft.Extensions.DependencyInjection;
using Services.User;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, User.UserService>();

            return services;
        }
    }
}