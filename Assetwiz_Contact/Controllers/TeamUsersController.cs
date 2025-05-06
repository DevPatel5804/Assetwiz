using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamUsersController : ControllerBase
    {
        private readonly TeamUsersBusinessObject _teamUsersBO;
        public TeamUsersController(TeamUsersBusinessObject teamUsersBO)
        {
            _teamUsersBO = teamUsersBO;
        }

        [HttpGet("GetAllTeamUsers")]
        public async Task<IActionResult> GetAllTeamUsers()
        {
            var users = await _teamUsersBO.GetAllTeamUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No team users found.");
            }
            return Ok(users);
        }

        [HttpGet("GetTeamUserById")]
        public async Task<IActionResult> GetTeamUserById([FromQuery] long teamId, [FromQuery] long userId)
        {
            var user = await _teamUsersBO.GetTeamUserByIdAsync(teamId, userId);
            if (user == null)
            {
                return NotFound($"Team user with TeamID {teamId} and UserID {userId} not found.");
            }
            return Ok(user);
        }

        [HttpPost("AddTeamUser")]
        public async Task<IActionResult> AddTeamUser([FromBody] TeamUsersViewModel teamUser)
        {
            var createdUser = await _teamUsersBO.AddTeamUserAsync(teamUser);
            if (createdUser == null)
            {
                return BadRequest("Error creating team user.");
            }
            return Ok(createdUser);
        }

        [HttpPut("UpdateTeamUser")]
        public async Task<IActionResult> UpdateTeamUser([FromQuery] long teamId, [FromQuery] long userId, [FromBody] TeamUsersViewModel updatedUser)
        {
            var user = await _teamUsersBO.UpdateTeamUserAsync(teamId, userId, updatedUser);
            if (user == null)
            {
                return NotFound($"Team user with TeamID {teamId} and UserID {userId} not found.");
            }
            return Ok(new
            {
                message = "Team user updated successfully.",
                data = user
            });
        }

        [HttpDelete("DeleteTeamUser")]
        public async Task<IActionResult> DeleteTeamUser([FromQuery] long teamId, [FromQuery] long userId)
        {
            var deleted = await _teamUsersBO.DeleteTeamUserAsync(teamId, userId);
            if (!deleted)
            {
                return NotFound($"Team user with TeamID {teamId} and UserID {userId} not found.");
            }
            return Ok(new
            {
                message = "Team user deleted successfully.",
                status = deleted
            });
        }
    }
}
