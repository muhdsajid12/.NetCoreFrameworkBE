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
        public static async Task<bool> AddCommandAsync(int userId, string message, float? intervalTime = null, bool? auto = null)
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

        public static async Task<List<double?>> GetIntervalCommandList()
        {
            using (var ctx = new YamurDbContext())
            {
                return await ctx.DtCommands.Where(q => q.Auto == true && q.Deleted == false).Select(q => q.IntervalTime)
                    .ToListAsync(); // check for auto command

            }
        }
    }
}
