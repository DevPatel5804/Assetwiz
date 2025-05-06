using Microsoft.AspNetCore.Mvc;
using AssetWiz.ViewModels;
using AssetWiz.BusinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetWiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamBusinessObject _teamBusinessObject;

        public TeamController(TeamBusinessObject teamBussinessObject)
        {
            _teamBusinessObject = teamBussinessObject;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamViewModel>>> GetTeams()
        {
            var teams = await _teamBusinessObject.GetTeams();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamViewModel>> GetTeamById(long id)
        {
            var team = await _teamBusinessObject.GetTeamById(id);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamViewModel>> CreateTeam(TeamViewModel teamviewModel)
        {
            var created = await _teamBusinessObject.CreateTeam(teamviewModel);
            return CreatedAtAction(nameof(GetTeamById), new { id = created.TeamId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(long id, TeamViewModel teamviewModel)
        {
            var success = await _teamBusinessObject.UpdateTeam(id, teamviewModel);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(long id)
        {
            var success = await _teamBusinessObject.DeleteTeam(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
