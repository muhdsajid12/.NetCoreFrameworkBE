using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WhatsappBusiness.CloudApi.Configurations;
using WhatsappBusiness.CloudApi.Exceptions;
using WhatsappBusiness.CloudApi.Extensions;
using WhatsappBusiness.CloudApi.Interfaces;
using WhatsappBusiness.CloudApi.Messages.Requests;

namespace BusinessLayer
{
    public class WSManagement
    {
        public static async Task<bool> SendWhatsAppTextMessage(SendTextMessageViewModel sendTextMessageViewModel, IWhatsAppBusinessClient client)
        {
            try
            {
                TextMessageRequest textMessageRequest = new TextMessageRequest();
                textMessageRequest.To = sendTextMessageViewModel.RecipientPhoneNumber;
                textMessageRequest.Text = new WhatsAppText();
                textMessageRequest.Text.Body = sendTextMessageViewModel.Message;
                textMessageRequest.Text.PreviewUrl = false;

                var results = await client.SendTextMessageAsync(textMessageRequest);

                return true;
            }
            catch (WhatsappBusinessCloudAPIException ex)
            {
                return false;
            }
        }
        #region Archive


        //// Replace these with your Twilio Account SID and Auth Token
        //public static string accountSid = "YourAccountSid";
        //public static string authToken = "YourAuthToken";
        //private static string serviceSid = "YourServiceSid";

        //// Replace this with your Twilio WhatsApp Sandbox number
        //public static string fromNumber = "whatsapp:YOUR_SANDBOX_NUMBER";

        //public static async Task<string> SendWhatsAppMessageAsync(string recipientPhoneNumber, string messageText)
        //{
        //    // Initialize the Twilio client
        //    TwilioClient.Init(accountSid, authToken);

        //    // Replace this with the recipient's WhatsApp number
        //    var to = new PhoneNumber("whatsapp:" + recipientPhoneNumber);

        //    try
        //    {
        //        var message = await MessageResource.CreateAsync(
        //            from: fromNumber,
        //            to: to,
        //            body: messageText
        //        );

        //        return $"WhatsApp message sent with SID: {message.Sid}";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Error: {ex.Message}";
        //    }
        //}

        //public static async Task<string> SendWhatsAppGroupMessageAsync(string groupSid, string messageText)
        //{
        //    // Initialize the Twilio client
        //    TwilioClient.Init(accountSid, authToken);

        //    try
        //    {
        //        var message = await MessageResource.CreateAsync(
        //            from: fromNumber,
        //            to: new PhoneNumber("whatsapp:" + groupSid), // Use the group SID
        //            body: messageText
        //        );

        //        return $"WhatsApp group message sent with SID: {message.Sid}";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Error: {ex.Message}";
        //    }
        //}

        //public static List<GroupContact> GetWhatsAppGroupContacts(string groupSid)
        //{
        //    TwilioClient.Init(accountSid, authToken);

        //    var groupContacts = new List<GroupContact>();

        //    try
        //    {
        //        // Query for group members
        //        var members = MemberResource.Read(
        //            to: new PhoneNumber("whatsapp:" + groupSid)
        //        );

        //        foreach (var member in members)
        //        {
        //            groupContacts.Add(new GroupContact
        //            {
        //                PhoneNumber = member.Identity,
        //                DisplayName = member.Attributes["participant_name"]
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }

        //    return groupContacts;
        //}
        #endregion
    }
}

public class SendTextMessageViewModel
{
    public string RecipientPhoneNumber { get; set; }
    public string Message { get; set; }
}
