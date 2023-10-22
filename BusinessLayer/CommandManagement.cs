using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

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
    }
}
