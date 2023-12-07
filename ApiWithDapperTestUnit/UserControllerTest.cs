using ApiWithDapper.Controllers.Users;
using ApiWithDapperModels.User;
using ApiWithDapperRepositories.UserRepository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiWithDapperTestUnit
{
    public class UserControllerTest
    {
        private readonly UserController _controller;
        
        public UserControllerTest()
        {
            var repo = new Mock<IUserRepository>();
            _controller = new UserController(repo.Object);
        }
        [Fact]
        public async void Post_WhenCalled_InsertAnUser() 
        {
            //ACT
            var okResult =await  _controller.CreateUser(getUserTest());
            //Assert
            Assert.IsType<OkResult>(okResult);
        }
        public User getUserTest()
        {
            return new User
            {
                DateOfBirth = new DateTime(),
                Email = "Test@test",
                Name = "Test",
                Password = "Test",
                Surname = "Test",
                Username = "Test"
            };
        }
    }
}