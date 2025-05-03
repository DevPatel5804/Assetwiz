using Assetwiz_Contact.Data;
using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulersController : ControllerBase
    {
        private readonly SchedulerBusinessObject _schedulerBO;

        public SchedulersController(SchedulerBusinessObject schedulerBO)
        {
            _schedulerBO = schedulerBO;
        }

        // GET: api/Schedulers
        [HttpGet("GetAllScheduler")]
        public async Task<IActionResult> GetSchedulers()
        {
            var schedulers = await _schedulerBO.GetAllSchedulersAsync();
            if (schedulers == null || !schedulers.Any())
            {
                return NotFound("No schedulers found.");
            }
            return Ok(new
            {
                message = "Schedulers fetched successfully.",
                data = schedulers
            });
        }

        // GET: api/Schedulers/5
        [HttpGet("GetSchedulerById/{id}")]
        public async Task<IActionResult> GetSchedulerById(long id)
        {
            var scheduler = await _schedulerBO.GetSchedulerByIdAsync(id);
            if (scheduler == null)
            {
                return NotFound($"Scheduler with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Scheduler fetched successfully.",
                data = scheduler
            });
        }

     // POST: api/Schedulers
    [HttpPost("AddScheduler")]
        public async Task<IActionResult> AddScheduler(SchedulersViewModel scheduler)
        {

            var createdScheduler = await _schedulerBO.AddSchedulerAsync(scheduler);
            if (createdScheduler == null)
            {
                return BadRequest("Error creating scheduler.");
            }
            return CreatedAtAction(nameof(GetSchedulerById), new { id = createdScheduler.SchedulerID }, createdScheduler);


            //var currentUtcTime = DateTime.UtcNow;
            //var newScheduler = new scheduler
            //{
            //    SchedulerName = scheduler.SchedulerName,
            //    LocationID = scheduler.LocationID,
            //    LocationName = scheduler.LocationName,
            //    Type = scheduler.Type,
            //    Description = scheduler.Description,
            //    OtherInformation = scheduler.OtherInformation,
            //    CreatedBy = scheduler.CreatedBy,
            //    CreatedByName = scheduler.CreatedByName,
            //    CreatedOn = currentUtcTime,
            //    ModifiedOn = currentUtcTime
            //};

            //_context.Scheduler.Add(newScheduler);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetScheduler), new { id = newScheduler.SchedulerID }, newScheduler);
        }

        [HttpPut("UpdateScheduler/{id}")]
        public async Task<IActionResult> UpdateScheduler(long id, SchedulersViewModel updatedScheduler)
        {
            var existingScheduler = await _schedulerBO.UpdateSchedulerAsync(id, updatedScheduler);
            if (existingScheduler == null)
            {
                return NotFound($"Scheduler with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Scheduler updated successfully.",
                data = existingScheduler
            });
        }

        // DELETE: api/Schedulers/5
        [HttpDelete("DeleteScheduler/{id}")]
        public async Task<IActionResult> DeleteScheduler(long id)
        {
            var deleted = await _schedulerBO.DeleteSchedulerAsync(id);
            if (!deleted)
            {
                return NotFound($"Scheduler with ID {id} not found.");
            }
            return Ok(new
            {
                message = "Scheduler deleted successfully.",
                data = deleted
            });

        }
    }
}
