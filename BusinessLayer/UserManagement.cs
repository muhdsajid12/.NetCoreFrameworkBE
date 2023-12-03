using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataLayer;

namespace BusinessLayer
{
    public class UserManagement
    {
        public static List<Users> GetUser() 
        {
            using (var ctx = new YamurDbContext()) 
            {
                return ctx.DtUsers.Select(q => new Users() 
                {
                    UserId = q.UserId,
                    Username = q.Username
                }).ToList();
            }
        }

        public static bool UserExist(int userId) 
        {
            using (var ctx = new YamurDbContext())
            {
                return ctx.DtUsers.Any(q => q.UserId == userId);
            }
        }

        public static async Task<bool> Register(string username, string password)
        {
            using (var ctx = new YamurDbContext())
            {
                try 
                {
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                        return false;

                    // password Hashing & Salt
                    DtUser user = new()
                    {
                        Username = username,
                        Token = password,
                        CreatedDate = DateTime.Now
                    };
                    ctx.DtUsers.Add(user);
                    ctx.SaveChanges();

                    var addUserCredit = await CreditManagement.CreateCredit(user.UserId);
                    if (!addUserCredit)
                        return false;

                    return true;

                }
                catch (Exception e) 
                {
                    return false;
                }
            }
        }

    }
}
