using ApiWithDapperModels.User;
using ApiWithDapperRepositories.UserRepository.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWithDapper.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try 
            {
                await _userRepository.CreateUser(user);
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message); 
            } 
        }
    }
       
}
