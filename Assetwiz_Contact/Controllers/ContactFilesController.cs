using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFilesController : ControllerBase
    {
        private readonly ContactFilesBusinessObject _contactFileBO;

        public ContactFilesController(ContactFilesBusinessObject contactFilesBO)
        {
            _contactFileBO = contactFilesBO;
        }

        [HttpGet("GetAllContactFiles")]
        public async Task<IActionResult> GetAllContactFiles()
        {
            var contactFiles = await _contactFileBO.GetAllContactFilesAsync();
            if (contactFiles == null || !contactFiles.Any())
            {
                return NotFound("No contact files found.");
            }
            return Ok(new
            {
                message = "Contact Files fetched successfully.",
                data = contactFiles
            });
        }

        [HttpGet("GetContactFileById/{id}")]
        public async Task<IActionResult> GetContactFileById(long id)
        {
            var contactFile = await _contactFileBO.GetContactFileByIdAsync(id);
            if (contactFile == null)
            {
                return NotFound($"Contact file with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact File fetched successfully.",
                data = contactFile
            });
        }

        [HttpPost("AddContactFile")]
        public async Task<IActionResult> AddContactFile([FromBody] ContactFilesViewModel ContactFile)
        {
            var createdContactFile = await _contactFileBO.AddContactFileAsync(ContactFile);
            if (createdContactFile == null)
            {
                return BadRequest("Error creating contact file.");
            }
            return CreatedAtAction(nameof(GetContactFileById), new { id = createdContactFile.ContactFilesID }, createdContactFile);
        }

        [HttpPut("UpdateContactFile/{id}")]
        public async Task<IActionResult> UpdateContactFile(long id, [FromBody] ContactFilesViewModel updatedContactFile)
        {
            if (updatedContactFile == null)
            {
                return BadRequest("Invalid contact file data.");
            }
            var existingContactFile = await _contactFileBO.UpdateContactFileAsync(id, updatedContactFile);
            if (existingContactFile == null)
            {
                return NotFound($"Contact file with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact File updated successfully.",
                data = existingContactFile
            });
        }

        [HttpDelete("DeleteContactFile/{id}")]
        public async Task<IActionResult> DeleteContactFile(long id)
        {
            var isDeleted = await _contactFileBO.DeleteContactFileAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Contact file with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact File Deleted Successfully.",
                status = isDeleted
            });
        }
    }
}
