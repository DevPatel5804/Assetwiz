using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class TeamUsersBusinessObject
    {
        private readonly AppDbContext _context;

        public TeamUsersBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeamUsersViewModel>> GetAllTeamUsersAsync()
        {
            return await _context.TeamUsers.ToListAsync();
        }

        public async Task<TeamUsersViewModel?> GetTeamUserByIdAsync(long teamId, long userId)
        {
            return await _context.TeamUsers
                .FirstOrDefaultAsync(tu => tu.TeamID == teamId && tu.UserID == userId);
        }

        public async Task<TeamUsersViewModel> AddTeamUserAsync(TeamUsersViewModel teamUser)
        {
            _context.TeamUsers.Add(teamUser);
            await _context.SaveChangesAsync();
            return teamUser;
        }

        public async Task<TeamUsersViewModel?> UpdateTeamUserAsync(long teamId, long userId, TeamUsersViewModel updatedTeamUser)
        {
            var existing = await _context.TeamUsers
                .FirstOrDefaultAsync(tu => tu.TeamID == teamId && tu.UserID == userId);

            if (existing == null) return null;

            existing.UserName = updatedTeamUser.UserName;
            existing.ModuleID = updatedTeamUser.ModuleID;
            existing.ModuleName = updatedTeamUser.ModuleName;
            existing.LocationID = updatedTeamUser.LocationID;
            existing.LocationName = updatedTeamUser.LocationName;
            existing.RoleID = updatedTeamUser.RoleID;
            existing.IsEnabled = updatedTeamUser.IsEnabled;
            existing.ModifiedBy = updatedTeamUser.ModifiedBy;
            existing.ModifiedByName = updatedTeamUser.ModifiedByName;
            existing.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return updatedTeamUser;
        }

        public async Task<bool> DeleteTeamUserAsync(long teamId, long userId)
        {
            var teamUser = await _context.TeamUsers
                .FirstOrDefaultAsync(tu => tu.TeamID == teamId && tu.UserID == userId);

            if (teamUser == null) return false;

            _context.TeamUsers.Remove(teamUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
