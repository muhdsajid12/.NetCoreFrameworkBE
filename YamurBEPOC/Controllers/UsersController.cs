using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;
using BusinessLayer.Models;

namespace YamurBEPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name = "GetUsers")]
        public List<Users> GetList()
        {
            return UserManagement.GetUser();
        }

        // POST: api/TodoItems
        [HttpPost("Register")]
        public async Task<Result> Register([FromBody] UserInput input)
        {
            var res = new Result();

            res.Success = await UserManagement.Register(input.Username, input.Password);

            return res;
        }
    }
}

public class UserInput 
{
    public string Username { get; set; }
    public string Password { get; set; }

}
