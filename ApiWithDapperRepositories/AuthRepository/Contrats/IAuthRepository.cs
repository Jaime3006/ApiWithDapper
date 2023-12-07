using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithDapperRepositories.AuthRepository.Contrats
{
    public interface IAuthRepository
    {
        public Task<bool> CheckUsername(string username);
        public Task<bool> CheckPasword(string password, string username);
    }
}
