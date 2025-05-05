using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        public readonly GroupBusinessObject _groupBO;

        public GroupController(GroupBusinessObject groupBO)
        {
            _groupBO = groupBO;
        }

        [HttpGet("GetAllGroups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupBO.GetAllGroupsAsync();
            if (groups == null || !groups.Any())
            {
                return NotFound("No groups found.");
            }
            return Ok(new
            {
                message = "Groups fetched successfully.",
                data = groups
            });
        }

        [HttpGet("GetGroupById/{id}")]
        public async Task<IActionResult> GetGroupById(long id)
        {
            var group = await _groupBO.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound($"Group with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Group fetched successfully.",
                data = group
            });
        }

        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroup([FromBody] GroupViewModel group)
        {
            var createdGroup = await _groupBO.AddGroupAsync(group);
            if (createdGroup == null)
            {
                return BadRequest("Error creating group.");
            }
            return CreatedAtAction(nameof(GetGroupById), new { id = createdGroup.GroupID }, createdGroup);
        }

        [HttpPut("UpdateGroup/{id}")]
        public async Task<IActionResult> UpdateGroup(long id, [FromBody] GroupViewModel updatedGroup)
        {
            var group = await _groupBO.UpdateGroupAsync(id, updatedGroup);
            if (group == null)
            {
                return NotFound($"Group with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Group updated successfully.",
                data = group
            });
        }

        [HttpDelete("DeleteGroup/{id}")]
        public async Task<IActionResult> DeleteGroup(long id)
        {
            var isDeleted = await _groupBO.DeleteGroupAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Group with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Group deleted successfully."
            });
        }
    }
}
