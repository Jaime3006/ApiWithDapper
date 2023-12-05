using ApiWithDapper.Context;
using ApiWithDapperModels.User;
using ApiWithDapperRepositories.UserRepository.Contracts;
using Dapper;
using System;
using System.Data;

namespace ApiWithDapperRepositories.UserRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
          var connection= _context.CreateConnection();
            var query = $@"INSERT INTO dbo.Users(
                                       Name,
                                       Surname,
                                       Username,
                                       Password,
                                       Email,DateOfBirth,
                                       WWC,
                                       WWM
                                    )
                                    VALUES(
                                       @Name,
                                       @Surname,
                                       @Username,
                                       @Password,
                                       @Email,
                                       @DateOfBirth,
                                       GETDATE(),
                                       GETDATE()
                                    );
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var res= await connection.ExecuteScalarAsync<int>(query,
                new { user.Name,
                    user.Surname,
                    user.Email,
                    user.Password,
                    user.DateOfBirth,
                    user.Username
                });

            return res;
               
        }
    }
}
