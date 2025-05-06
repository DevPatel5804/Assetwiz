using AssetWiz.Data;
using AssetWiz.ViewModels;
using Assetwiz_Contact.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetWiz.BusinessObject
{
    public class UserBusinessObject
    {
        private readonly AppDbContext _context;

        public UserBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            return await _context.Users
                                 .Include(r => r.Roles)
                                            .ThenInclude(p => p.Permissions)
                                 .Include(t => t.Teams)
                                 .ToListAsync();
        }

        public async Task<UserViewModel?> GetUserById(long id)
        {
            return await _context.Users
                                 .Include(r => r.Roles)
                                            .ThenInclude(p => p.Permissions)
                                 .Include(t => t.Teams)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateUser(long id, UserViewModel userviewModel)
        {
            _context.Entry(userviewModel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<UserViewModel> CreateUser(UserViewModel userviewModel)
        {


            _context.Users.Add(userviewModel);
            await _context.SaveChangesAsync();
            return userviewModel;
        }


        public async Task<bool> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
