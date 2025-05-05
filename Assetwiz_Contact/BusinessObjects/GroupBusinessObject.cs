using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class GroupBusinessObject
    {
        public readonly AppDbContext _context;

        public GroupBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GroupViewModel>> GetAllGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<GroupViewModel?> GetGroupByIdAsync(long id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<GroupViewModel> AddGroupAsync(GroupViewModel group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<GroupViewModel?> UpdateGroupAsync(long id, GroupViewModel updatedGroup)
        {
            var existing = await _context.Groups.FindAsync(id);
            if (existing == null) return null;
            existing.GroupName = updatedGroup.GroupName;
            existing.LocationID = updatedGroup.LocationID;
            existing.LocationName = updatedGroup.LocationName;
            existing.Description = updatedGroup.Description;
            existing.IsEnabled = updatedGroup.IsEnabled;
            existing.GroupType = updatedGroup.GroupType;
            existing.Url = updatedGroup.Url;
            existing.DisplayType = updatedGroup.DisplayType;
            existing.DisplayOrder = updatedGroup.DisplayOrder;
            existing.ReferenceGroupID = updatedGroup.ReferenceGroupID;
            existing.ExternalReferenceID = updatedGroup.ExternalReferenceID;
            existing.ModifiedOn = DateTime.UtcNow;
            existing.ModifiedBy = updatedGroup.ModifiedBy;
            existing.ModifiedByName = updatedGroup.ModifiedByName;
            await _context.SaveChangesAsync();
            return updatedGroup;
        }

        public async Task<bool> DeleteGroupAsync(long id)
        {
            var existing = await _context.Groups.FindAsync(id);
            if (existing == null) return false;
            _context.Groups.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
