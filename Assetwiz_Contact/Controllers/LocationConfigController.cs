using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationConfigController : Controller
    {

        private readonly LocationConfigBusinessObject _contactBO;
        public LocationConfigController(LocationConfigBusinessObject contactBO)
        {
            _contactBO = contactBO;
        }

        [HttpGet("GetAllLocationConfig")]

        public async Task<IActionResult> GetAllLocationConfigAsync()
        {
            var location = await _contactBO.GetAllLocationConfigAsync();
            if (location == null || !location.Any())
            {
                return NotFound("No locations found.");
            }
            return Ok(location);
        }

        [HttpGet("GetLocationConfigById/{id}")]
        public async Task<IActionResult> GetLocationConfigById(long id)
        {
            var location = await _contactBO.GetLocationConfigByIdAsync(id);
            if (location == null)
            {
                return NotFound($"location with ID {id} not found.");
            }
            return Ok(location);
        }

        [HttpPost("AddLocationConfig")]
        public async Task<IActionResult> AddLocation([FromBody] LocationConfigViewModel location)
        {
            var createdLocation = await _contactBO.AddLocationConfigAsync(location);
            if (createdLocation == null)
            {
                return BadRequest("Error creating Location.");
            }
            return CreatedAtAction(nameof(GetLocationConfigById), new { id = createdLocation.LocationID }, createdLocation);
        }

        [HttpPut("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(long id, [FromBody] LocationConfigViewModel updatedlocationConfig)
        {
            var location = await _contactBO.UpdateLocationConfigAsync(id, updatedlocationConfig);
            if (location == null)
            {
                return NotFound($"Location with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Location Updated Successfully.",
                Data = location

            });
        }
        [HttpDelete("DeleteLocationConfig/{id}")]
        public async Task<IActionResult> DeleteLocation(long id)
        {
            var deleted = await _contactBO.DeleteLocationConfigAsync(id);
            if (!deleted)
            {
                return NotFound($"LocationConfig detail with ID {id} not found.");
            }
            return Ok(new
            {
                message = "LocationConfig Deleted Successfully",
                status = deleted
            });
        }
    }
}
