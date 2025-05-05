namespace Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

public class SchedulerConfigBusinessObject
{
    private readonly AppDbContext _context;

    public SchedulerConfigBusinessObject(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<SchedulerConfigViewModel>> GetAllSchedulerConfigAsync()
    {
        return await _context.SchedulerConfig.ToListAsync();
    }

    public async Task<SchedulerConfigViewModel?> GetSchedulerConfigByIdAsync(long id)
    {
        return await _context.SchedulerConfig.FindAsync(id);
    }

    public async Task<SchedulerConfigViewModel> AddSchedulerConfigAsync(SchedulerConfigViewModel schedulerConfig)
    {
        schedulerConfig.CreatedOn = DateTime.UtcNow;
        _context.SchedulerConfig.Add(schedulerConfig);
        await _context.SaveChangesAsync();
        return schedulerConfig;
    }

    public async Task<bool> DeleteSchedulerConfigAsync(long id)
    {
        var schedulerConfig = await _context.SchedulerConfig.FindAsync(id);
        if (schedulerConfig == null) return false;
        _context.SchedulerConfig.Remove(schedulerConfig);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<SchedulerConfigViewModel?> UpdateSchedulerConfigAsync(long id, SchedulerConfigViewModel updatedSchedulerConfig)
    {
        var existing = await _context.SchedulerConfig.FindAsync(id);
        if (existing == null) return null;

        existing.SchedulerConfigID = updatedSchedulerConfig.SchedulerConfigID;
        existing.SchedulerID = updatedSchedulerConfig.SchedulerID;
        existing.LocationID = updatedSchedulerConfig.LocationID;
        existing.LocationName = updatedSchedulerConfig.LocationName;
        existing.Type = updatedSchedulerConfig.Type;
        existing.RepeatAt = updatedSchedulerConfig.RepeatAt;
        existing.RepeatMinutes = updatedSchedulerConfig.RepeatMinutes;
        existing.CreatedBy = updatedSchedulerConfig.CreatedBy;
        existing.CreatedByName = updatedSchedulerConfig.CreatedByName;
        existing.CreatedOn = updatedSchedulerConfig.CreatedOn;
        existing.ModifiedBy = updatedSchedulerConfig.ModifiedBy;
        existing.ModifiedByName = updatedSchedulerConfig.ModifiedByName;
        existing.ModifiedOn = updatedSchedulerConfig.ModifiedOn;

        await _context.SaveChangesAsync();
        return existing;
    }
}
