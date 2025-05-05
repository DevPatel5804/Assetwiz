using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class LocationConfigBusinessObject
    {
        private readonly AppDbContext _context;
        public LocationConfigBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocationConfigViewModel>> GetAllLocationConfigAsync()
        {
            return await _context.LocationConfig.ToListAsync();
        }

        public async Task<LocationConfigViewModel?> GetLocationConfigByIdAsync(long id)
        {
            return await _context.LocationConfig.FindAsync(id);
        }

        public async Task<LocationConfigViewModel> AddLocationConfigAsync(LocationConfigViewModel locationConfig)
        {
            _context.LocationConfig.Add(locationConfig);
            await _context.SaveChangesAsync();
            return locationConfig;
        }

        public async Task<LocationConfigViewModel> UpdateLocationConfigAsync(long id, LocationConfigViewModel updatedlocationConfig)
        {
            try
            {
                var existing = await _context.LocationConfig.FindAsync(id);
                if (existing == null) return null;

                _context.Entry(existing).CurrentValues.SetValues(updatedlocationConfig);
                await _context.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error updating location with ID {id}: {ex.Message}", ex);
            }


        }

        public async Task<bool> DeleteLocationConfigAsync(long id)
        {
            var locationConfig = await _context.LocationConfig.FindAsync(id);
            if (locationConfig == null) return false;
            _context.LocationConfig.Remove(locationConfig);
            await _context.SaveChangesAsync();
            return true;
        }

        
        
    }
}
