using ApiWithDapperRepositories.UserRepository.Contracts;
using ApiWithDapperRepositories.UserRepository.Repository;

namespace ApiWithDapper.Configuration
{
    public static class ConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(
           this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
           

            return services;
        }
    }
}