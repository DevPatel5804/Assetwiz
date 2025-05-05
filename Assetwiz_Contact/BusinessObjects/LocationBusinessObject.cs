namespace Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;


public class LocationBusinessObject
{
    private readonly AppDbContext _context;

    public LocationBusinessObject(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<LocationViewModel>> GetAllLocationAsync()
    {
        return await _context.Location.ToListAsync();
    }

    public async Task<LocationViewModel?> GetLocationByIdAsync(long id)
    {
        return await _context.Location.FindAsync(id);
    }

    public async Task<LocationViewModel> AddLocationAsync(LocationViewModel location)
    {
        _context.Location.Add(location);
        await _context.SaveChangesAsync();
        return location;

    }

    public async Task<LocationViewModel?> UpdateLocationAsync(long id, LocationViewModel updatedLocation)
    {

        var existing = await _context.Location.FindAsync(id);
        if (existing == null) return null;

        existing.ModuleID = updatedLocation.ModuleID;
        existing.ModuleName = updatedLocation.ModuleName;
        existing.LocationName = updatedLocation.LocationName;
        existing.LocationAddress = updatedLocation.LocationAddress;
        existing.LocationCity = updatedLocation.LocationCity;
        existing.LocationState = updatedLocation.LocationState;
        existing.LocationZip = updatedLocation.LocationZip;
        existing.LocationCountry = updatedLocation.LocationCountry;
        existing.LocationPhone1 = updatedLocation.LocationPhone1;
        existing.LocationPhone2 = updatedLocation.LocationPhone2;
        existing.LocationMobile = updatedLocation.LocationMobile;
        existing.LocationCode = updatedLocation.LocationCode;
        existing.IsEnabled = updatedLocation.IsEnabled;
        existing.Description = updatedLocation.Description;
        existing.UserID = updatedLocation.UserID;
        existing.ModifiedOn = updatedLocation.ModifiedOn;
        existing.ModifiedBy = updatedLocation.ModifiedBy;
        existing.ModifiedByName = updatedLocation.ModifiedByName;
        existing.IsSync = updatedLocation.IsSync;
        existing.IsSubscriptionEnabled = updatedLocation.IsSubscriptionEnabled;
        existing.LocationConfig = updatedLocation.LocationConfig;
        existing.APIUrl = updatedLocation.APIUrl;

        await _context.SaveChangesAsync();

        return existing;
    }

    public async Task<bool> DeleteLocationAsync(long id)
    {
        var Location = await _context.Location.FindAsync(id);
        if (Location == null) return false;
        _context.Location.Remove(Location);
        await _context.SaveChangesAsync();
        return true;
    }
}
