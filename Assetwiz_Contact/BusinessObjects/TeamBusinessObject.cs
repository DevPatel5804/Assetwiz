using AssetWiz.Data;

using AssetWiz.ViewModels;
using Assetwiz_Contact.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetWiz.BusinessObject
{
    public class TeamBusinessObject
    {
        private readonly AppDbContext _context;

        public TeamBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeamViewModel>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams.ToList();
        }

        public async Task<TeamViewModel?> GetTeamById(long id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return null;
            return team;
        }

        public async Task<TeamViewModel> CreateTeam(TeamViewModel teamviewModel)
        {
            _context.Teams.Add(teamviewModel);
            await _context.SaveChangesAsync();
            return teamviewModel;
        }
        public async Task<bool> UpdateTeam(long id, TeamViewModel teamviewModel)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            team.TeamName = teamviewModel.TeamName;
            team.Description = teamviewModel.Description;

            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTeam(long id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
