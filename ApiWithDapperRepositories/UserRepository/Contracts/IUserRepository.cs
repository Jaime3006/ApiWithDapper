using ApiWithDapperModels.User;
namespace ApiWithDapperRepositories.UserRepository.Contracts
{
    public interface IUserRepository
    {
        public Task<int> CreateUser(User user);
        public Task<bool> CheckUsername(string username);
        public Task<bool> CheckEmail(string emaile);
        public Task <List<User>> GetAllUsers();
    }
}
