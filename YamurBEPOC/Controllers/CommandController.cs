using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using WhatsappBusiness.CloudApi.Exceptions;
using WhatsappBusiness.CloudApi.Messages.Requests;
using WhatsappBusiness.CloudApi.Configurations;
using WhatsappBusiness.CloudApi.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;

namespace YamurBEPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        
        private readonly IWhatsAppBusinessClient _whatsAppBusinessClient;
        private readonly WhatsAppBusinessCloudApiConfig _whatsAppConfig;
        private readonly IWebHostEnvironment _environment;

        public CommandController(IWhatsAppBusinessClient whatsAppBusinessClient,
            IOptions<WhatsAppBusinessCloudApiConfig> whatsAppConfig, IWebHostEnvironment environment)
        {
            _whatsAppBusinessClient = whatsAppBusinessClient;
            _whatsAppConfig = whatsAppConfig.Value;
            _environment = environment;
        }

        // POST: api/Insert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Insert")]
        public async Task<Result> InsertCommand([FromBody] CommandInput input)
        {
            var res = new Result();

            res.Success = await CommandManagement.AddCommandAsync(input.UserId, input.Message, input.IntervalTime, input.Auto);

            return res;
        }

        // POST: api/Insert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update")]
        public async Task<Result> UpdateCommand([FromBody] CommandInput input)
        {
            var res = new Result();

            res.Message = await CommandManagement.UpdateCommand(input.UserId, input.CommandId, input.Message);

            return res;
        }

        // POST: api/Insert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpDelete("delete")]
        public async Task<Result> DeleteCommand([FromBody] CommandInput input)
        {
            var res = new Result();

            res.Message = await CommandManagement.DeleteCommand(input.UserId, input.CommandId);

            return res;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> SendWhatsAppTextMessage(SendTextMessageViewModel sendTextMessageViewModel)
        {
            try
            {
                TextMessageRequest textMessageRequest = new TextMessageRequest();
                textMessageRequest.To = sendTextMessageViewModel.RecipientPhoneNumber;
                textMessageRequest.Text = new WhatsAppText();
                textMessageRequest.Text.Body = sendTextMessageViewModel.Message;
                textMessageRequest.Text.PreviewUrl = false;

                var results = await _whatsAppBusinessClient.SendTextMessageAsync(textMessageRequest);

                return new Result() { Success = true};
            }
            catch (WhatsappBusinessCloudAPIException ex)
            {
                return new Result() { Success = true, Message = ex.Message };
            }
        }

        // POST: api/Insert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("refresh")]
        public async Task<Result> RefreshCreditUser([FromBody] string userToken, int userId)
        {
            var res = new Result();

            res.Message = await CreditManagement.RefreshCredit(userId);

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
        public int CommandId { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public double IntervalTime { get; set; }
        public bool Auto { get; set; }
    }

    public class SendTextMessageViewModel
    {
        public string RecipientPhoneNumber { get; set; }
        public string Message { get; set; }
    }

}

