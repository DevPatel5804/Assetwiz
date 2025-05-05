using Assetwiz_Contact.Data;
using Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerConfigController : ControllerBase
    {
        private readonly SchedulerConfigBusinessObject _schedulerConfigBo;

        public SchedulerConfigController( SchedulerConfigBusinessObject schedulerConfigBo)
        {
            _schedulerConfigBo  = schedulerConfigBo;
        }

        // GET: api/SchedulersConfig
        [HttpGet("GetAllSchedulerConfig")]
        public async Task<IActionResult> GetSchedulerConfig()
        {
            var schedulers = await _schedulerConfigBo.GetAllSchedulerConfigAsync();
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


        // GET: api/SchedulersConfig/5
        [HttpGet("GetSchedulerConfigById/{id}")]
        public async Task<IActionResult> GetSchedulerConfigById(long id)
        {
            var scheduler = await _schedulerConfigBo.GetSchedulerConfigByIdAsync(id);
            if (scheduler == null)
            {
                return NotFound($"Scheduler with ID {id} not found.");
            }
            return Ok(new
            {
                message = "SchedulerConfig fetched successfully.",
                data = scheduler
            });
        }


        // POST: api/SchedulersConfig
        [HttpPost("AddSchedulerConfig")]
        public async Task<IActionResult> AddSchedulerConfig(SchedulerConfigViewModel schedulerConfig)
        {

            var createdSchedulerConfig = await _schedulerConfigBo.AddSchedulerConfigAsync(schedulerConfig);
            if (createdSchedulerConfig == null)
            {
                return BadRequest("Error creating scheduler.");
            }
            return CreatedAtAction(nameof(GetSchedulerConfigById), new { id = createdSchedulerConfig.SchedulerConfigID }, createdSchedulerConfig);


        }


        [HttpPut("UpdateSchedulerConfig/{id}")]
        public async Task<IActionResult> UpdateSchedulerConfig(long id, SchedulerConfigViewModel updatedSchedulerConfig)
        {
            var existingSchedulerConfig = await _schedulerConfigBo.UpdateSchedulerConfigAsync(id, updatedSchedulerConfig);
            if (existingSchedulerConfig == null)
            {
                return NotFound($"Scheduler with ID {id} not found.");
            }
            return Ok(new
            {
                message = "SchedulerConfig updated successfully.",
                data = existingSchedulerConfig
            });
        }


        [HttpDelete("DeleteSchedulerConfig/{id}")]
        public async Task<IActionResult> DeleteSchedulerConfig(long id)
        {
            var deleted = await _schedulerConfigBo.DeleteSchedulerConfigAsync(id);
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
