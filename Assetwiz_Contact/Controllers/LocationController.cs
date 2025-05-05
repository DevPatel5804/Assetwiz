using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly LocationBusinessObject _locationBO;
        public LocationController(LocationBusinessObject locationBO)
        {
            _locationBO = locationBO;     
        }

        [HttpGet("GetAllLocation")]

        public async Task<IActionResult> GetAllLocations()
        {
            var location = await _locationBO.GetAllLocationAsync();
            if (location == null || !location.Any())
            {
                return NotFound("No locations found.");
            }
            return Ok(location);
        }

        [HttpGet("GetLocationById/{id}")]
        public async Task<IActionResult> GetLocationById(long id)
        {
            var location = await _locationBO.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound($"location with ID {id} not found.");
            }
            return Ok(location);
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] LocationViewModel location)
        {
            var createdLocation = await _locationBO.AddLocationAsync(location);
            if (createdLocation == null)
            {
                return BadRequest("Error creating Location.");
            }
            return CreatedAtAction(nameof(GetLocationById), new { id = createdLocation.LocationID }, createdLocation);
        }

        [HttpPut("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(long id, [FromBody] LocationViewModel updatedLocation)
        {
            var location = await _locationBO.UpdateLocationAsync(id, updatedLocation);
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

        [HttpDelete("DeleteLocation/{id}")]
        public async Task<IActionResult> DeleteLocation(long id)
        {
            var deleted = await _locationBO.DeleteLocationAsync(id);
            if (!deleted)
            {
                return NotFound($"Location detail with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Location Deleted Successfully",
                status = deleted
            });
        }
    }
}
