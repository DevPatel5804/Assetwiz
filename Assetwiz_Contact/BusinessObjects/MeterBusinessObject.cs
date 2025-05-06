namespace Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

public class MeterBusinessObject
{
    private readonly AppDbContext _context;

    public MeterBusinessObject(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MeterViewModel>> GetAllMeterAsync()
    {
        return await _context.Meter.ToListAsync();
    }

    public async Task<MeterViewModel?> GetMeterByIdAsync(long id)
    {
        return await _context.Meter.FindAsync(id);
    }

    public async Task<MeterViewModel> AddMeterAsync(MeterViewModel meter)
    {
        meter.CreatedOn = DateTime.UtcNow;
        _context.Meter.Add(meter);
        await _context.SaveChangesAsync();
        return meter;
    }

    public async Task<bool> DeleteMeterAsync(long id)
    {
        var meter = await _context.Meter.FindAsync(id);
        if (meter == null) return false;
        _context.Meter.Remove(meter);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<MeterViewModel?> UpdateMeterAsync(long id, MeterViewModel updatedMeter)
    {

        var existing = await _context.Meter.FindAsync(id);
        if (existing == null) return null;
        existing.MeterID = updatedMeter.MeterID;
        existing.MeterName = updatedMeter.MeterName;
        existing.ProductID = updatedMeter.ProductID;
        existing.ProductName = updatedMeter.ProductName;
        existing.AlarmType = updatedMeter.AlarmType;
        existing.AlarmValue = updatedMeter.AlarmValue;
        existing.LocationID = updatedMeter.LocationID;
        existing.LocationName = updatedMeter.LocationName;
        existing.CreatedBy = updatedMeter.CreatedBy;
        existing.CreatedByName = updatedMeter.CreatedByName;
        existing.ModifiedBy = updatedMeter.ModifiedBy;
        existing.ModifiedByName = updatedMeter.ModifiedByName;
        existing.ModifiedOn = updatedMeter.ModifiedOn;
        existing.UnitType = updatedMeter.UnitType;

        await _context.SaveChangesAsync();
        return existing;
    }

   
}
