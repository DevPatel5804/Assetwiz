using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
namespace Assetwiz_Contact.BusinessObjects
{

    public class MeterLogsBusinessObject
    {
        private readonly AppDbContext _context;

        public MeterLogsBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MeterLogsViewModel>> GetAllMeterLogsAsync()
        {
            return await _context.MeterLogs.ToListAsync();
        }

        public async Task<MeterLogsViewModel?> GetMeterLogsByIdAsync(long id)
        {
            return await _context.MeterLogs.FindAsync(id);
        }

        public async Task<MeterLogsViewModel> AddMeterLogsAsync(MeterLogsViewModel meterlogs)
        {
            meterlogs.CreatedOn = DateTime.UtcNow;
            _context.MeterLogs.Add(meterlogs);
            await _context.SaveChangesAsync();
            return meterlogs;
        }

        public async Task<bool> DeleteMeterLogsAsync(long id)
        {
            var meterlogs = await _context.Meter.FindAsync(id);
            if (meterlogs == null) return false;
            _context.Meter.Remove(meterlogs);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MeterLogsViewModel?> UpdateMeterLogsAsync(long id, MeterLogsViewModel updatedMeterLogs)
        {

            var existing = await _context.MeterLogs.FindAsync(id);
            if (existing == null) return null;
            existing.MeterLogsID = updatedMeterLogs.MeterLogsID;
            existing.WorkFlowItemID = updatedMeterLogs.WorkFlowItemID;
            existing.Value = updatedMeterLogs.Value;
            existing.LocationID = updatedMeterLogs.LocationID;
            existing.LocationName = updatedMeterLogs.LocationName;
            existing.IsConnected = updatedMeterLogs.IsConnected;
            existing.CreatedBy = updatedMeterLogs.CreatedBy;
            existing.CreatedByName = updatedMeterLogs.CreatedByName;
            existing.CreatedBy = updatedMeterLogs.CreatedBy;
            existing.CreatedOn = updatedMeterLogs.CreatedOn;
            existing.ModifiedBy = updatedMeterLogs.ModifiedBy;
            existing.ModifiedByName = updatedMeterLogs.ModifiedByName;
            existing.ModifiedOn = updatedMeterLogs.ModifiedOn;
            existing.MeterID = updatedMeterLogs.MeterID;
            existing.MeterName = updatedMeterLogs.MeterName;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
