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
    }
}
