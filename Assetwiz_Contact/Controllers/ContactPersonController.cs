using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly ContactPersonBusinessObject _contactPersonBO;
        public ContactPersonController(ContactPersonBusinessObject contactPersonBO)
        {
            _contactPersonBO = contactPersonBO;
        }

        [HttpGet("GetAllContactPerson")]
        public async Task<IActionResult> GetAllContactPerson()
        {
        var contactPersons = await _contactPersonBO.GetAllContactPersonsAsync();
            if (contactPersons == null || !contactPersons.Any())
            {
                return NotFound("No contact persons found.");
            }
            return Ok(new
            {
                message = "Contact Persons fetched successfully.",
                data = contactPersons
            });
        }

        [HttpGet("GetContactPersonById/{id}")]
        public async Task<IActionResult> GetContactPersonById(long id)
        {
            var contactPerson = await _contactPersonBO.GetContactPersonByIdAsync(id);
            if (contactPerson == null)
            {
                return NotFound($"Contact person with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact Person fetched successfully.",
                data = contactPerson
            });
        }

        [HttpPost("AddContactPerson")]
        public async Task<IActionResult> AddContactPerson([FromBody] ContactPersonViewModel contactPerson)
        {
            var createdContactPerson = await _contactPersonBO.AddContactPersonAsync(contactPerson);
            if (createdContactPerson == null)
            {
                return BadRequest("Error creating contact person.");
            }
            return CreatedAtAction(nameof(GetContactPersonById), new { id = createdContactPerson.ContactID }, createdContactPerson);
        }

        [HttpPut("UpdateContactPerson/{id}")]
        public async Task<IActionResult> UpdateContactPerson(long id, ContactPersonViewModel contactPerson)
        {
            var UpdateContactPerson = await _contactPersonBO.UpdateContactPersonAsync(id, contactPerson);
            if (UpdateContactPerson == null)
            {
                return NotFound($"Contact Person with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact Person Updated Successfully.",
                data = UpdateContactPerson
            });
        }

        [HttpDelete("DeleteContactPerson/{id}")]
        public async Task<IActionResult> DeleteContactPerson(long id)
        {
            var deletedContactPerson = await _contactPersonBO.DeleteContactPersonAsync(id);
            if (!deletedContactPerson)
            {
                return NotFound($"Contact Person with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact Person Deleted Successfully.",
                status = deletedContactPerson
            });
        }
    }
}
