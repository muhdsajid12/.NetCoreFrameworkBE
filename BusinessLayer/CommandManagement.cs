using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class CommandManagement
    {
        public static async Task<bool> AddCommandAsync(int userId, string message, double? intervalTime = null, bool? auto = null)
        {
            using (var ctx = new YamurDbContext())
            {
                if (userId == 0 || string.IsNullOrEmpty(message))
                    return false;

                ctx.DtCommands.Add(new DtCommand()
                {
                    UserId = userId,
                    Message = message,
                    IntervalTime = intervalTime,
                    Auto = auto,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now
                });
                ctx.SaveChanges();
                return true;
            }
        }

        public static async Task GetAutoCommandList() 
        {
            using (var ctx = new YamurDbContext()) 
            {
                var list = ctx.DtCommands.Where(q => q.Auto == true && q.Deleted == false)
                    .Select(q => new Commands() 
                    {
                      Message = q.Message
                    })
                    .ToList(); // check for auto command

            }
        }

        public static async Task<Dictionary<double,int>> GetIntervalCommandList()
        {
            using (var ctx = new YamurDbContext())
            {
                return await ctx.DtCommands.Where(q => q.Auto == true && q.Deleted == false && q.IntervalTime.HasValue).OrderBy(q => TimeSpan.FromSeconds(q.IntervalTime.Value))
                    .ToDictionaryAsync(q => q.IntervalTime.Value, q => q.UserId); // check for auto command
            }
        }

        public static async Task<DtCommand?> GetCommandById(int Id) 
        {
            using (var ctx = new YamurDbContext())
            {
                return await ctx.DtCommands.Where(q => q.CommandId == Id)?.FirstOrDefaultAsync(); // check for auto command
            }

        }

        public static async Task<string> UpdateCommand(int userId, int commandId, string message)
        {
            using (var ctx = new YamurDbContext())
            {
                if (userId == 0)
                    return $"User not found Id : {userId}";

                if (commandId == 0)
                    return $"Invalid Command Id : {commandId}";

                DtCommand? command = await ctx.DtCommands.Where(q => q.CommandId == Id)?.FirstOrDefaultAsync();
                if (command == null)
                    return $"Command Id : {commandId} not found";

                command.Message = message;
                ctx.SaveChanges();

                return "Successfully updated";
            }
        }

        public static async Task<string> DeleteCommand(int userId, int commandId)
        {
            using (var ctx = new YamurDbContext())
            {
                if (userId == 0)
                    return $"User not found Id : {userId}";

                if (commandId == 0)
                    return $"Invalid Command Id : {commandId}";

                DtCommand? command = await ctx.DtCommands.Where(q => q.CommandId == Id)?.FirstOrDefaultAsync();
                if (command == null)
                    return $"Command Id : {commandId} not found";

                command.Deleted = true;
                ctx.SaveChanges();

                return "Successfully deleted";
            }
        }
    }
}
