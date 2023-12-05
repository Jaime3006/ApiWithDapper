using ApiWithDapperModels.User;
namespace ApiWithDapperRepositories.UserRepository.Contracts
{
    public interface IUserRepository
    {
        public Task<int> CreateUser(User user);
    }
}
