using BeitragRdr.DTOs;
using BeitragRdr.Models.UserModel;
using BeitragRdrDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdrDataAccessLibrary.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext context;

        public UserRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Task<User> GetUser(string objectId)
        {

            var output =  context.users.Where(o => o.ObjectIdentifier == objectId)
                .Include(c => c.companies).ThenInclude(a => a.addresses)
                .Include(c => c.companies).ThenInclude(p => p.phoneNumbers)
                .Include(c => c.companies).ThenInclude(b => b.beitrags)
                .FirstOrDefaultAsync();

            return output;
        }

        public void CreateUser(User user)
        {
            context.users.Add(user);
            context.SaveChangesAsync();
        }
    }
}
