using ApiWithDapper.Context;
using ApiWithDapperRepositories.AuthRepository.Contrats;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithDapperRepositories.AuthRepository.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DBContext _context;
        public AuthRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckPasword(string password, string username)
        {
            var connection = _context.CreateConnection();

            var query = $@"SELECT CAST(COUNT(1) AS BIT) AS Expr1
                           from dbo.Users
                           where Password=@Password
                           AND
                           Username=@Username";

            var res = await connection.QueryFirstAsync<bool>(query, new { Password = password, Username= username });

            return res;
        }

        public async Task<bool> CheckUsername(string username)
        {
            var connection = _context.CreateConnection();

            var query = $@"SELECT CAST(COUNT(1) AS BIT) AS Expr1
                           from dbo.Users
                           where Username=@Username";

            var res = await connection.QueryFirstAsync<bool>(query, new { Username = username });

            return res;
        }

    }
}
