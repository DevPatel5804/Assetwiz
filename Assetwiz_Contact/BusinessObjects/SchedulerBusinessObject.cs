using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assetwiz_Contact.BusinessObjects;

public class SchedulerBusinessObject
{

    private readonly AppDbContext _context;

    public SchedulerBusinessObject(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SchedulersViewModel>> GetAllSchedulersAsync()
    {
        return await _context.Scheduler.ToListAsync();
    }

    public async Task<SchedulersViewModel?> GetSchedulerByIdAsync(long id)
    {
        return await _context.Scheduler.FindAsync(id);
    }

    public async Task<SchedulersViewModel> AddSchedulerAsync(SchedulersViewModel scheduler)
    {
        scheduler.CreatedOn = DateTime.UtcNow;
        _context.Scheduler.Add(scheduler);
        await _context.SaveChangesAsync();
        return scheduler;
    }

    public async Task<bool> DeleteSchedulerAsync(long id)
    {
        var scheduler = await _context.Scheduler.FindAsync(id);
        if (scheduler == null) return false;
        _context.Scheduler.Remove(scheduler);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<SchedulersViewModel?> UpdateSchedulerAsync(long id, SchedulersViewModel updatedScheduler)
    {
        var existing = await _context.Scheduler.FindAsync(id);
        if (existing == null) return null;

        existing.SchedulerName = updatedScheduler.SchedulerName;
        existing.LocationID = updatedScheduler.LocationID;
        existing.LocationName = updatedScheduler.LocationName;
        existing.Type = updatedScheduler.Type;
        existing.Description = updatedScheduler.Description;
        existing.OtherInformation = updatedScheduler.OtherInformation;
        existing.ModifiedBy = updatedScheduler.ModifiedBy;
        existing.ModifiedByName = updatedScheduler.ModifiedByName;
        existing.ModifiedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existing;
    }
}
