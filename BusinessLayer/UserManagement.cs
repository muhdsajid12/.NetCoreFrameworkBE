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

        public static async Task<bool> Register(string username, string password)
        {
            using (var ctx = new YamurDbContext())
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;


                // password Hashing & Salt

                ctx.DtUsers.Add(new DtUser()
                {
                    Username = username,
                    Token = password,
                    CreatedDate = DateTime.Now
                });
                ctx.SaveChanges();

                return true;
            }
        }

    }
}
