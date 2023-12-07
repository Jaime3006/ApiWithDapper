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
        public async Task<bool> CheckUsername(string username)
        {
            var connection =_context.CreateConnection();

            var query = $@"SELECT CAST(COUNT(1) AS BIT) AS Expr1
                           from dbo.Users
                           where Username=@Username";

            var res = await connection.QueryFirstAsync<bool>(query, new { Username = username });
                     
            return res;
        }
        public async Task<bool>CheckEmail(string email) 
        {

            var connection = _context.CreateConnection();

            var  query = $@"SELECT CAST(COUNT(1) AS BIT) AS Expr1
                           from dbo.Users
                           where Email=@Email";
            var res = await connection.QueryFirstAsync<bool>(query, new { Email = email });
            
            return res;
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
        //Get
        public async Task<List<User>> GetAllUsers() 
        { 
        var connection =_context.CreateConnection();
            var query = $@"Select * from dbo.Users";
            var res = await connection.QueryAsync<User>(query);
            return res.ToList();
        
        }
    }
}
