using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactBusinessObject _contactBO;
        public ContactController(ContactBusinessObject contactBO)
        {
            _contactBO = contactBO;
        }

        [HttpGet("GetAllContacts")]
        
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactBO.GetAllContactsAsync();
            if (contacts == null || !contacts.Any())
            {
                return NotFound("No contacts found.");
            }
            return Ok(contacts);
        }

        [HttpGet("GetContactById/{id}")]
        public async Task<IActionResult> GetContactById(long id)
        {
            var contact = await _contactBO.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            return Ok(contact);
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact([FromBody] ContactViewModel contact)
        {
            var createdContact = await _contactBO.AddContactAsync(contact);
            if (createdContact == null)
            {
                return BadRequest("Error creating contact.");
            }
            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.ContactID }, createdContact);
        }

        [HttpPut("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContact(long id, [FromBody] ContactViewModel updatedContact)
        {
            var contact = await _contactBO.UpdateContactAsync(id, updatedContact);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contect Updated Successfully.",
                Data = contact
           
            });
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var deleted = await _contactBO.DeleteContactAsync(id);
            if(!deleted)
            {
                return NotFound($"Contact detail with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Contact Deleted Successfully",
                status = deleted
            });
        }
    }
}
