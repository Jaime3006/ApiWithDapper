using ApiWithDapperModels.User;
using ApiWithDapperRepositories.UserRepository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

                IDictionary<int,string> res = await CheckData(user);

                if (res.IsNullOrEmpty())
                {
                    await _userRepository.CreateUser(user);
                    return Ok();
                }             
             
                    return Conflict(res) ;              
               
              
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message); 
            } 
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllUsers() 
        {
            try
            { 
              var res=  await _userRepository.GetAllUsers();
                return Ok(res);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);

            }
        
        }
        [NonAction]
        public async Task<IDictionary<int,string>> CheckData(User user) 
        {
            var checks = new Dictionary<int, string>() { }; 
            if (await _userRepository.CheckUsername(user.Username))
            {
                checks.Add(1, "This usernanme already exists");
            }
            if (await _userRepository.CheckEmail(user.Email))
            {
                checks.Add(2, "This email already exists");
            }

                return checks;
        }
    }
       
}
