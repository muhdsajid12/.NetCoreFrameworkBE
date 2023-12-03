using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CreditManagement
    {
        private const int CreditLimit = 1000;

        public static async Task<bool> CreateCredit(int userId)
        {
            using (var ctx = new YamurDbContext())
            {
                try
                {
                    bool checkUserExist = UserManagement.UserExist(userId);
                    if (checkUserExist)
                        return false;

                    await ctx.DtCredits.AddAsync(new DtCredit()
                    {
                        Limit = CreditLimit,
                        UserId = userId
                    });
                    await ctx.SaveChangesAsync();
                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public static async Task<string> RefreshCredit(int userId) 
        {
            using (var ctx = new YamurDbContext())
            {
                try
                {
                    var credit = ctx.DtCredits.Where(q => q.UserId == userId).FirstOrDefault();
                    if (credit == null)
                        return $"User not found for Id: {userId}";

                    credit.Limit = CreditLimit;
                    await ctx.SaveChangesAsync();
                    return $"Succesfully refresh credit Id: {credit.CreditId}";

                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

        }
    }
}
