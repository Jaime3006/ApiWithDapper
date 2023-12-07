using ApiWithDapperRepositories.AuthRepository.Contrats;
using ApiWithDapperRepositories.AuthRepository.Repository;
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
            services.AddScoped<IAuthRepository, AuthRepository>();


            return services;
        }
    }
}