using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace YamurBEPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Insert")]
        public async Task<Result> CreateTodoItem([FromBody] CommandInput input)
        {
            var res = new Result();

            res.Success = await CommandManagement.AddCommandAsync(input.UserId, input.Message, input.IntervalTime, input.Auto);

            return res;
        }
    }

    public class Result 
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class CommandInput 
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public float IntervalTime { get; set; }
        public bool Auto { get; set; }
    }

}
